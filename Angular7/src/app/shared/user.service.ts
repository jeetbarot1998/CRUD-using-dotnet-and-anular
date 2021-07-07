import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import {
  HttpClient,
  HttpHeaders,
  HttpClientModule,
} from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  // httpOptions = {
  //   headers: new HttpHeaders({
  //     'Access-Control-Allow-Origin': '*',
  //     Authorization: 'authkey',
  //     userid: '1',
  //   }),
  // };

  constructor(private fb: FormBuilder, private http: HttpClient) {}

  // https://localhost:44397/api/ApplicationUser/Register
  // http://localhost:4200/user/registeration
  formModel = this.fb.group({
    UserName: ['', Validators.required],
    Email: ['', [Validators.required, Validators.email]],
    FullName: [''],
    Passwords: this.fb.group(
      {
        Password: ['', [Validators.required, Validators.minLength(4)]],
        ConfirmPassword: ['', [Validators.required]],
      }
      // { validator: this.comparePasswords }
    ),
  });

  // comparePasswords(fb: FormGroup) {
  //   let confirmPswrdCtrl = fb.get('ConfirmPassword');
  //   //passwordMismatch
  //   //confirmPswrdCtrl.errors={passwordMismatch:true}
  //   if (
  //     confirmPswrdCtrl.errors == null ||
  //     'passwordMismatch' in confirmPswrdCtrl.errors
  //   ) {
  //     if (fb.get('Password').value != confirmPswrdCtrl.value)
  //       confirmPswrdCtrl.setErrors({ passwordMismatch: true });
  //     else confirmPswrdCtrl.setErrors(null);
  //   }
  // }
  readonly BaseURI = 'https://localhost:44397/api';
  register() {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    var body = {
      UserName: this.formModel.value.UserName,
      Email: this.formModel.value.Email,
      FullName: this.formModel.value.FullName,
      Password: this.formModel.value.Passwords.Password,
      // Discriminator: 'ApplicationUser',
    };
    return this.http.post(
      unescape(this.BaseURI + '/ApplicationUser/Register'),
      body
      // {
      //   headers: {
      //     'Content-Type': 'application/x-www-form-urlencoded;charset=UTF-8',
      //   },
      // }
    );
  }

  login(formData: any) {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    // let options = new RequestOptions({ headers: headers });
    return this.http.post(
      unescape(this.BaseURI + '/ApplicationUser/Login'),
      formData
      // {
      //   headers: {
      //     'Content-Type': 'application/x-www-form-urlencoded;charset=UTF-8',
      //   },
      // }
    );
  }
}
