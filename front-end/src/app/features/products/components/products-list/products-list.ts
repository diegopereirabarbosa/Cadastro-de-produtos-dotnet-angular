import { Component } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { Product } from '../../models/product.model';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { AlertService } from '../../../../core/services/alert.service';

@Component({
  selector: 'app-products-list',
  standalone: true,
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    RouterModule
  ],
  templateUrl: './products-list.html',
  styleUrl: './products-list.css',
  providers: [ProductService]
})
export class ProductsList {

  constructor(
    private productService: ProductService,
    private alertSevice: AlertService
  ) { }
  products: Product[] = [];
  searchText = '';
  currentPage = 1;
  pageSize = 10;
  sortColumn: keyof Product | '' = '';
  sortDirection: 'asc' | 'desc' = 'asc';

  ngOnInit(): void {
    this.getAllproducts();
  }

  getAllproducts() {
    this.productService.getAll().subscribe({
      next: (ret) => {
        this.products = ret;
      },
      error: (erro) => {
        console.log(erro)
      }
    });
  }

  deletProduct(id: number) {
    this.alertSevice.confirm("Tem certeza que deseja seguir?", "Deletar produto!").then((resp) => {
      if (resp) {
        this.productService.delete(id).subscribe({
          next: (ret) => {
            this.alertSevice.success("Produto excluído com sucesso!", "Sucesso!")
            this.getAllproducts();
          },
          error: (erro) => {
            this.alertSevice.error(erro, "Erro ao excluír!")
            console.log(erro)
          }
        });
      }
    });
  }


  get filteredProducts() {
    const text = this.searchText.toLowerCase();
    return this.products.filter(
      p =>
        p.name?.toLowerCase().includes(text) ||
        p.id?.toString().includes(text) ||
        p.price?.toString().includes(text)
    );
  }

  get sortedProducts() {
    if (!this.sortColumn) return this.filteredProducts;

    const sortKey: keyof Product = this.sortColumn;

    return [...this.filteredProducts].sort((a, b) => {
      const valA = a[sortKey];
      const valB = b[sortKey];

      if (valA < valB) return this.sortDirection === 'asc' ? -1 : 1;
      if (valA > valB) return this.sortDirection === 'asc' ? 1 : -1;
      return 0;
    });
  }

  get productsPaginated() {
    const start = (this.currentPage - 1) * this.pageSize;
    return this.sortedProducts.slice(start, start + this.pageSize);
  }

  nextPage() {
    if (this.currentPage * this.pageSize < this.sortedProducts.length) this.currentPage++;
  }

  prevPage() {
    if (this.currentPage > 1) this.currentPage--;
  }

  sortBy(column: keyof Product) {
    if (this.sortColumn === column) {
      this.sortDirection = this.sortDirection === 'asc' ? 'desc' : 'asc';
    } else {
      this.sortColumn = column;
      this.sortDirection = 'asc';
    }
  }
  get totalPages(): number {
    return Math.ceil(this.sortedProducts.length / this.pageSize);
  }
}
