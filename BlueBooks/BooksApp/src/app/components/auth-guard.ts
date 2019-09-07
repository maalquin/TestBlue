import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { LoginService } from '../shared/login.service';
import { take, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class AuthGuard implements CanActivate {
  constructor(private router : Router, 
    private loginService: LoginService){}
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot):  Observable<boolean> {
      return this.loginService.isLoggedIn.pipe(
        take(1),
        map((isLoggedIn: boolean) => {
          if (!isLoggedIn && localStorage.getItem('userToken') == null) {
            this.router.navigate(['/login']);
            return false;
          }
          return true;
        })
      );
  
}
}
