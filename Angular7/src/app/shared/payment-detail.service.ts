import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PayementDetailComponent } from '../payment-details/payement-detail/payement-detail.component';
import { PaymentDetail } from './payment-detail.model';

@Injectable({
  providedIn: 'root',
})
export class PaymentDetailService {
  formData: PaymentDetail | undefined;

  list: PaymentDetail[] | undefined;

  readonly URL = 'https://localhost:44397/api';
  constructor(public http: HttpClient) {}

  postTaskDetail(fromData: PaymentDetail) {
    return this.http.post(this.URL + '/Detail', fromData);
  }

  putTaskDetail() {
    return this.http.put(
      this.URL + '/Detail/' + this.formData?.PMId,
      this.formData
    );
  }

  refreshList() {
    this.http
      .get(this.URL + '/Detail')
      .toPromise()
      .then((res) => (this.list = res as PaymentDetail[]));
  }

  DelTaskDetail(id_in: any) {
    return this.http.delete(this.URL + '/Detail/' + id_in);
  }
}
