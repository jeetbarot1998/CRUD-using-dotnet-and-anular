import { HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-registeration',
  templateUrl: './registeration.component.html',
  styleUrls: ['./registeration.component.css'],
})
export class RegisterationComponent implements OnInit {
  constructor(public service: UserService) {}

  ngOnInit(): void {}
  // headers = new HttpHeaders();
  // headers = headers.set('Content-Type', 'application/json; charset=utf-8');

  onSubmit() {
    this.service.register().subscribe(
      (res: any) => {
        if (res.succeeded) {
          this.service.formModel.reset();
          console.log('New User Created');
          console.log(res);
        } else {
          console.log('Some issue is there');
          console.log(res);

          // res.errors.forEach((element: any) => {
          //   switch (element.code) {
          //     case 'DuplicateUserName':
          //       console.log('DuplicateUserName');
          //       break;

          //     default:
          //       console.log('Registration failed.');
          //       break;
          //   }
          // });
        }
      },
      (err) => {
        console.log(err);
      }
    );
  }
}
