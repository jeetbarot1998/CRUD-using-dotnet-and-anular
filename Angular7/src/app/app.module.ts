import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { UserService } from './shared/user.service';
import { HttpClientModule } from '@angular/common/http';
// import { NgForm } from '@angular/forms';
import { UrlSerializer } from '@angular/router';
import { CustomUrlSerializer } from './CustomUrlSerializer';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { RegisterationComponent } from './user/registeration/registeration.component';
import { LoginComponent } from './user/login/login.component';
import { HomeComponent } from './home/home.component';
import { PaymentDetailsComponent } from './payment-details/payment-details.component';
import { PayementDetailComponent } from './payment-details/payement-detail/payement-detail.component';
import { PayementDetailListComponent } from './payment-details/payement-detail-list/payement-detail-list.component';
import { PaymentDetailService } from './shared/payment-detail.service';
@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    RegisterationComponent,
    LoginComponent,
    HomeComponent,
    PaymentDetailsComponent,
    PayementDetailComponent,
    PayementDetailListComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
  ],
  providers: [
    UserService,
    PaymentDetailService,
    { provide: UrlSerializer, useClass: CustomUrlSerializer },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
