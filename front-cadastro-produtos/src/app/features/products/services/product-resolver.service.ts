// product-resolver.service.ts
import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ProductService } from './product.service';
import { Observable } from 'rxjs';
import { Produto } from '../models/product.model';

@Injectable({ providedIn: 'root' })
export class ProductResolver implements Resolve<Produto> {
  constructor(private productService: ProductService) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Produto> {
    const id = Number(route.paramMap.get('id'));
    return this.productService.getById(id);
  }
}
