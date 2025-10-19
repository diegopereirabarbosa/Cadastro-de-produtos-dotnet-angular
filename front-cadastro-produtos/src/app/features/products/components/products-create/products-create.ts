import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ProductService } from '../../services/product.service';
import { Produto } from '../../models/product.model';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AlertService } from '../../../../core/services/alert.service';

@Component({
  selector: 'app-products-create',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule,
  ],
  templateUrl: './products-create.html',
  styleUrl: './products-create.css',
  providers: [ProductService]
})
export class ProductsCreate {

  productForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private productService: ProductService,
    private alertSevice: AlertService
  ) { }

  ngOnInit(): void {
    this.productForm = this.fb.group({
      nome: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      descricao: ['', [Validators.maxLength(300)]],
      preco: [0, [Validators.required, Validators.min(0.01)]],
    });
  }

  submitForm() {
    if (this.productForm.valid) {
      const product: Produto = {
        id: 0,
        nome: this.productForm.get('nome')?.value,
        preco: this.productForm.get('preco')?.value,
        descricao: this.productForm.get('descricao')?.value,
      };
      this.productService.create(product).subscribe({
        next: (ret) => {
          this.productForm.reset();
          this.alertSevice.success("Produto cadastrado com sucesso!", "Sucesso!");
        },
        error: (err) => {
          this.alertSevice.error(err, "Erro ao cadastrar!");
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
