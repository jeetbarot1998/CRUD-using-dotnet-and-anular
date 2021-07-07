import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { PaymentDetailService } from 'src/app/shared/payment-detail.service';

@Component({
  selector: 'app-payement-detail',
  templateUrl: './payement-detail.component.html',
  // styleUrls: ['./payement-detail.component.css'],
})
export class PayementDetailComponent implements OnInit {
  constructor(public service: PaymentDetailService) {}

  ngOnInit(): void {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null) {
      form.resetForm();
    }

    this.service.formData = {
      PMId: 0,
      Name: '',
      TaskName: '',
      TaskId: '',
    };
  }
  insertrecord(form: NgForm) {
    this.service.postTaskDetail(form.value).subscribe(
      (res) => {
        this.resetForm(form);
        alert('Success');
      },
      (err) => {
        console.log(err);
      }
    );
  }
  // This method is used for update and insert both
  // If Employee Id Exists then, it means that the process is of update.
  // If employee Id doesnt exist then it is new entry.
  onSubmit(form: NgForm) {
    if (this.service.formData?.PMId == 0) {
      this.insertrecord(form);
      this.resetForm(form);
    } else {
      this.service.putTaskDetail().subscribe(
        (res) => {
          this.resetForm(form);
          alert('Success');
        },
        (err) => {
          console.log(err);
        }
      );
    }
  }
}
