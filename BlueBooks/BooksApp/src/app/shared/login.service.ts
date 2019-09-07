import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Login } from './login.model';
import { Observable, throwError, BehaviorSubject } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { Route } from '@angular/compiler/src/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private loggedIn : BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  user:Login;
  
  get isLoggedIn() {
    return this.loggedIn.asObservable();
  }
  constructor(private http: HttpClient, private router: Router) { }
    
    
   

  userAuthentication(user: Login) {
  
      // var data = "username=" + user.username + "&password=" + user.password + "&grant_type=password";
      var data = user;
      var reqHeader = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8','No-Auth':'True' });
     
      return this.http.post(environment.ApiUrl + 'auth/login', data, { headers: reqHeader })
        .subscribe((data : any)=>{

          this.loggedIn.next(true);
          localStorage.setItem('userToken',data.token);
          this.router.navigate(['/book']);
        },
        (err : HttpErrorResponse)=>{
          
        });
      
    
    }
    
    
}
