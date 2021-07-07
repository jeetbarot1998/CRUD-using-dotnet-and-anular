import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './user/login/login.component';
import { RegisterationComponent } from './user/registeration/registeration.component';
import { UserComponent } from './user/user.component';

const routes: Routes = [
  // default
  {
    path: '',
    redirectTo: 'user/login',
    pathMatch: 'full',
  },
  {
    path: 'user',
    component: UserComponent,
    children: [
      { path: 'registration', component: RegisterationComponent },
      { path: 'login', component: LoginComponent },
    ],
  },
  { path: 'home', component: HomeComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
