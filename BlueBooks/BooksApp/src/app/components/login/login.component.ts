import { Component, OnInit } from '@angular/core';
import { LoginService } from 'src/app/shared/login.service';
import { HttpErrorResponse } from '@angular/common/http/http';
import { Router } from '@angular/router';
import { Login } from 'src/app/shared/login.model';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private loginService:LoginService, private router : Router) { }

  ngOnInit() {
  }

  OnSubmit(userName,password){
    debugger;
    var login = new Login(userName,password);

    this.loginService.userAuthentication(login).add();
    
    
 }

}
