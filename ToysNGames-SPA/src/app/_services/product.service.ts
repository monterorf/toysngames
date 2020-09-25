import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from '../_models/product';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
baseUrl = 'http://localhost:58264/api/products/'
products: Product[];

constructor(private http: HttpClient) { }

getProducts() {
  return this.http.get<Product[]>(this.baseUrl);
  }

getProduct(id: number)   {
  return this.http.get<Product>(this.baseUrl + id);
}

addProduct(product: Product) {
  return this.http.post(this.baseUrl, product);
}

deleteProduct(id) { 
  return this.http.delete(this.baseUrl + id);
}

editProduct(id: number, product: Product) {
  console.log(id);
  console.log(product)
  return this.http.put<Product>(this.baseUrl + id, product);
}
}
