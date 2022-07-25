import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { SharedService } from "../../../services/shared.service";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {

  searhValue: string;
  
  constructor(private router: Router, private route: ActivatedRoute, private sharedService: SharedService) { }

  searchProducts(){
    this.sharedService.getProductEvent(this.searhValue);
    this.router.navigate(['/products/products-list/' + this.searhValue]);
  }
}
