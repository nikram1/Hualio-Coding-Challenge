import { EventEmitter, Injectable, Output } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable()
export class SharedService {
  
  public searchValue: string = "";
  private approvalStageMessage = new BehaviorSubject(this.searchValue);
  currentApprovalStageMessage = this.approvalStageMessage.asObservable();

  @Output() getProductsEvent: EventEmitter<string> = new EventEmitter();

  getProductEvent(searchValue: string) {
    this.approvalStageMessage.next(searchValue)
  }
}