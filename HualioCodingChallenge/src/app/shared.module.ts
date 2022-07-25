import { NgModule } from "@angular/core";
import { ReactiveFormsModule } from "@angular/forms";
import { FormsModule }   from '@angular/forms';
import { MaterialModule } from "./material.module";
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { PagingService } from './services/paging.service';
import { ProductsService } from "./services/products.service";
import { SharedService } from "./services/shared.service";

import { HeaderComponent } from './components/layout/header/header.component';

@NgModule({
  imports:[
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    MaterialModule,
    CommonModule,
  ],
  declarations: [HeaderComponent],
  providers: [PagingService, ProductsService, SharedService],
  exports:[ReactiveFormsModule, FormsModule, MaterialModule,  CommonModule, HeaderComponent]
})

export default class SharedModule { };