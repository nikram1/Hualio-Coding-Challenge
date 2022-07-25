import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ProductsService } from "../../../services/products.service";
import { PagingService } from "../../../services/paging.service";
import { SharedService } from "../../../services/shared.service";
import { PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.scss']
})
export class ProductsListComponent implements OnInit {

  searchValue: string;
  dataTable = {
    searchValue: '',
    sortColumn: 'productID',
    sortOrder: 'desc',
    length: 0,
    pageSize: 10,
    pageNo: 0
  };

  dataSource: any[] = [];

  constructor(private router: Router, 
    private route: ActivatedRoute, 
    private productsService: ProductsService,
    private pagingService: PagingService,
    private sharedService: SharedService) { 

    }

  ngOnInit(): void {
    this.sharedService.currentApprovalStageMessage.subscribe((searchValue)=>{
      this.dataTable.searchValue = searchValue;
      this.getProducts();
    });

    this.searchValue = this.route.snapshot.paramMap.get('search');
    this.getProducts();
  }

  getProducts(){
    this.productsService.getProducts(this.dataTable).subscribe(res=>{
      if(res && res.length > 0){
        this.dataTable.length = res[0].totalRows;
        this.dataSource = res;
      }
    });
  }

  handlePage(event: PageEvent){
    console.log(event);
    this.dataTable.pageSize = event.pageSize;
    this.dataTable.pageNo = event.pageIndex;
    this.getProducts();
  }

  getPagingSizeIntervals(): number[]{
    return this.pagingService.getPagingSizeIntervals();
  }

  loadProduct(productId){
    this.router.navigate(['/products/product-details/' + productId]);
  }
}


