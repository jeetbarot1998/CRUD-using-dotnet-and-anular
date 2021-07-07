import { UserService } from './../shared/user.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: [],
})
export class HomeComponent implements OnInit {
  userDetails: any;

  constructor(private router: Router, private service: UserService) {}

  ngOnInit() {}

  onLogout() {
    localStorage.removeItem('token');
    this.router.navigate(['/user/login']);
  }
}
