import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder, ValidatorFn, AbstractControl } from '@angular/forms';
import { ProductService } from 'src/app/_services/product.service';
import { Product } from 'src/app/_models/product';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-new',
  templateUrl: './product-new.component.html',
  styleUrls: ['./product-new.component.scss']
})
export class ProductNewComponent implements OnInit {
  product: Product;
  productForm: FormGroup;
  constructor(private productService:ProductService, private fb: FormBuilder,
    private router: Router) { }

  ngOnInit() {
    this.createProductForm();
  }

  createProductForm() {
    this.productForm = this.fb.group({
      name: ['', [Validators.required,Validators.maxLength(50)]],
      price: ['', [Validators.required, rangeNumberValidator(1, 1000)]],
      description: ['', Validators.maxLength(100)],
      ageRestriction: ['', rangeNumberValidator(0, 100)],
      company: ['', [Validators.required, Validators.maxLength(50)]],
    });
  }

  createProduct() {
    this.product = Object.assign({}, this.productForm.value);
    this.productService.addProduct(this.product).subscribe(() => {
      console.log('Product has been created successfully');
    }, error => {
        console.log('There has been an issue creating the product');
    });

    this.router.navigate(['home']).then(() => {
      window.location.reload();
    });
  }


}

/** A hero's name can't match the given regular expression */
export function rangeNumberValidator(min: number, max: number): ValidatorFn {
  let range = null;
  return (control: AbstractControl): {[key: string]: any} | null => {
    const invalid = (control.value >= min && control.value <= max) ? false  : true;
    return invalid ? {range: 'Number must be bentween ' + min + ' and ' + max } : null;
  };
}
