import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ProductService } from '../../services/product.service';
import { Product } from '../../models/product.model';
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
      name: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      description: ['', [Validators.maxLength(300)]],
      price: [0, [Validators.required, Validators.min(0.01)]],
    });
  }

  submitForm() {
    if (this.productForm.valid) {
      const product: Product = {
        id: 0,
        name: this.productForm.get('name')?.value,
        price: this.productForm.get('price')?.value,
        description: this.productForm.get('description')?.value,
      };
      this.productService.create(product).subscribe({
        next: (ret) => {
          this.productForm.reset();
          this.alertSevice.success("Produto cadastrado com sucesso!", "Sucesso!");
        },
        error: (err) => {
          this.alertSevice.error(err, "Erro ao cadastrar!");
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

  get preco() {
    return this.productForm.get('price');
  }
}
