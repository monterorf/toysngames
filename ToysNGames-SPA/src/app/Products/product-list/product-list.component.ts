import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ProductService } from '../../_services/product.service';
import { Product } from '../../_models/product';
import { map } from 'rxjs/operators';
import { AlertifyService } from 'src/app/_services/alertify.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  products: Product[];

  constructor(private http: HttpClient, private productService: ProductService,
              private alertify: AlertifyService) { }

  ngOnInit() {
    this.loadProducts();
  }

  loadProducts() {
    this.productService.getProducts().subscribe((products: Product[]) => {
      this.products = products;
    })
  }

  deleteProduct(id: number) {
    this.alertify.confirm('Are you sure you want to remove this product?', () => {
      this.productService.deleteProduct(id).subscribe(() => {
        this.products.splice(this.products.findIndex(p => p.id === id), 1);
      }, error => {
        this.alertify.error('There has been an issue deleting the product');
      });
    });
  }

}
