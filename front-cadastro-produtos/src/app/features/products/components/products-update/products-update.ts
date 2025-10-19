import { Component } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { Produto } from '../../models/product.model';
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
  product?: Produto;
  constructor(
    private productService: ProductService,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private alertSevice: AlertService
  ) { }

  ngOnInit(): void {
    this.productForm = this.fb.group({
      nome: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      descricao: ['', [Validators.maxLength(300)]],
      preco: [0, [Validators.required, Validators.min(0.01)]],
    });

    this.route.data.subscribe(({ product }) => {
      this.product = product;
      if (this.product != undefined) {
        this.productForm.patchValue({
          nome: this.product.nome,
          descricao: this.product.descricao,
          preco: this.product.preco,
        });
      }
    });
  }

  submitForm() {
    if (this.productForm.valid) {
      const id = Number(this.product?.id);
      const product: Produto = {
        id: id,
        nome: this.productForm.get('nome')?.value,
        preco: this.productForm.get('preco')?.value,
        descricao: this.productForm.get('descricao')?.value,
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
  get nome() {
    return this.productForm.get('nome');
  }

  get preco() {
    return this.productForm.get('preco');
  }
}
