import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { ProductListComponent } from './Products/product-list/product-list.component';
import { ProductService } from './_services/product.service';
import { appRoutes } from './routes';
import { ProductNewComponent } from './Products/product-new/product-new.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ProductEditComponent } from './Products/product-edit/product-edit.component';
import { AlertifyService } from './_services/alertify.service';


@NgModule({
  declarations: [
    AppComponent,
    ProductListComponent,
    ProductNewComponent,
    ProductEditComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [
    ProductService,
    AlertifyService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
