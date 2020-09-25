import { Routes } from '@angular/router';
import { ProductListComponent } from './Products/product-list/product-list.component';
import { ProductEditComponent } from './Products/product-edit/product-edit.component';
import { ProductNewComponent } from './Products/product-new/product-new.component';

export const appRoutes: Routes = [
    { path: 'home', component: ProductListComponent },
    { path: 'product-new', component: ProductNewComponent },
    { path: 'product-edit/:id', component: ProductEditComponent },
    { path: '**', redirectTo: 'home', pathMatch: 'full' }
];