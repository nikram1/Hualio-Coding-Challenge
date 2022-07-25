import { NgModule } from "@angular/core";
import { Router, RouterModule, Routes } from "@angular/router";

import { ProductsListComponent } from "./products-list/products-list.component";
import { ProductDetailsComponent } from "./product-details/products-details.component";
import { ProductsSidebarComponent } from "./products-sidebar/products-sidebar.component";
import SharedModule from "../../shared.module";


const routes: Routes = [
  {
    path: 'products-list',
    component: ProductsListComponent
  },
  {
    path: 'products-list/:search',
    component: ProductsListComponent
  },
  {
    path: 'product-detail/:productId',
    component: ProductDetailsComponent
  }
]

@NgModule({
  imports: [SharedModule, RouterModule.forChild(routes)],
  declarations: [ProductsListComponent, ProductDetailsComponent, ProductsSidebarComponent],
  exports: [RouterModule]
})
export default class ProductModule { }