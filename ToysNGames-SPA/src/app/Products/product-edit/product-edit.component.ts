import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from 'src/app/_services/product.service';
import { Product } from 'src/app/_models/product';
import { FormGroup, FormBuilder, Validators, ValidatorFn, AbstractControl } from '@angular/forms';


@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.scss']
})
export class ProductEditComponent implements OnInit {
  id: number;
  private sub: any;
  product: Product;
  editProductForm: FormGroup;

  constructor(private route: ActivatedRoute, private productService: ProductService,
              private fb: FormBuilder, private router: Router) { }

  ngOnInit() {
  //   this.sub = this.route.params.subscribe(params => {
  //     this.id = +params['id']; // (+) converts string 'id' to a number
  //  });

   this.id = +this.route.snapshot.paramMap.get('id');

   this.createProductForm();

   this.loadProduct(this.id);

  }


  loadProduct(id: number) {
    this.productService.getProduct(id).subscribe((product: Product) => {
      this.product = product;
    });    
  }

  createProductForm() {
    this.editProductForm = this.fb.group({
      name: ['', [Validators.required,Validators.maxLength(50)]],
      price: ['', [Validators.required, rangeNumberValidator(1, 1000)]],
      description: ['', Validators.maxLength(100)],
      ageRestriction: ['', rangeNumberValidator(0, 100)],
      company: ['', [Validators.required, Validators.maxLength(50)]],
    });
  }

  editProduct(product: Product) {
    this.productService.editProduct(this.id, product).subscribe(() => {
      console.log(product);
    });
    this.router.navigate(['home']).then(() => {
      window.location.reload();
    });
    }

}


export function rangeNumberValidator(min: number, max: number): ValidatorFn {
  let range = null;
  return (control: AbstractControl): {[key: string]: any} | null => {
    const invalid = (control.value >= min && control.value <= max) ? false  : true;
    return invalid ? {range: 'Number must be bentween ' + min + ' and ' + max } : null;
  };
}
