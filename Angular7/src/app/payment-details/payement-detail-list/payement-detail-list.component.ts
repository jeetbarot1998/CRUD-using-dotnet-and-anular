import { Component, OnInit } from '@angular/core';
import { PaymentDetail } from 'src/app/shared/payment-detail.model';
import { PaymentDetailService } from 'src/app/shared/payment-detail.service';

@Component({
  selector: 'app-payement-detail-list',
  templateUrl: './payement-detail-list.component.html',
  // styleUrls: ['./payement-detail-list.component.css']
})
export class PayementDetailListComponent implements OnInit {
  constructor(public service: PaymentDetailService) {}

  ngOnInit(): void {
    this.service.refreshList();
  }
  PopulateForm(pd: PaymentDetail) {
    this.service.formData = Object.assign({}, pd);
  }

  Delete(id: any) {
    this.service.DelTaskDetail(id).subscribe(
      (res) => {
        alert('Deleted');
        this.service.refreshList();
      },
      (err) => {
        console.log(err);
      }
    );
  }
}
