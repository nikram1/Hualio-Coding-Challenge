import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {

  productId: number;
  product: any;
  constructor(private route: ActivatedRoute,
    private productsService: ProductsService) { 
  }

  ngOnInit(): void {
    this.productId = parseInt(this.route.snapshot.paramMap.get('productId'));
    this.getProduct(this.productId);
  }

  getProduct(productId){
    this.productsService.getProducts(productId).subscribe(res=>{
      this.product = res
    });
  }
}


