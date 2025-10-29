import { Component } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { Product } from '../../models/product.model';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { AlertService } from '../../../../core/services/alert.service';

@Component({
  selector: 'app-products-update',
  standalone: true,
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    RouterModule,
    ReactiveFormsModule,
  ],
  templateUrl: './products-update.html',
  styleUrl: './products-update.css',
  providers: [ProductService]
})
export class ProductsUpdate {
  productForm!: FormGroup;
  product?: Product;
  constructor(
    private productService: ProductService,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private alertSevice: AlertService
  ) { }

  ngOnInit(): void {
    this.productForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      description: ['', [Validators.maxLength(300)]],
      price: [0, [Validators.required, Validators.min(0.01)]],
    });

    this.route.data.subscribe(({ product }) => {
      this.product = product;
      if (this.product != undefined) {
        this.productForm.patchValue({
          name: this.product.name,
          description: this.product.description,
          price: this.product.price,
        });
      }
    });
  }

  submitForm() {
    if (this.productForm.valid) {
      const id = Number(this.product?.id);
      const product: Product = {
        id: id,
        name: this.productForm.get('name')?.value,
        price: this.productForm.get('price')?.value,
        description: this.productForm.get('description')?.value,
      };
      this.productService.update(product.id, product).subscribe({
        next: (ret) => {
          this.alertSevice.success("Produto atualizado com sucesso!", "Sucesso!");
        },
        error: (err) => {
          this.alertSevice.error(err, "Erro ao atualizar!");
          console.log(err)
        }
      });
    } else {
      this.alertSevice.show(
        "Preencha todos os campos obrigatórios",
        "Aviso!"
      );
    }
  }
  get name() {
    return this.productForm.get('name');
  }

  get price() {
    return this.productForm.get('price');
  }
}
