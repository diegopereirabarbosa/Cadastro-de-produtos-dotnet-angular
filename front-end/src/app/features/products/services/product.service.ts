import { Injectable } from '@angular/core';
import { baseService } from '../../../core/services/base.service';
import { Product } from '../models/product.model';
import { environment } from '../../../../environments/environments';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class ProductService extends baseService<Product> {
  constructor(http: HttpClient) {
    super(http, environment.apiUrl+'/products'); // passa URL da API
  }
 
}