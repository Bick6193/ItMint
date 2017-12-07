import {Injectable} from '@angular/core';
import {tokenNotExpired} from 'angular2-jwt';
import {HttpRequest} from '@angular/common/http';
import {CanActivate} from '@angular/router';
import {Router} from '@angular/router';

@Injectable()
export class AuthenticateGuardService implements CanActivate {

  router: Router;

  constructor(private route: Router) {
    this.router = route;
  }

  canActivate() {
    if (this.isAuthenticated()) {
      return true;
    }
    else {
      this.router.navigate(['/Admin']);
    }
  }

  cacheResult: Array<HttpRequest<any>> = [];

  public getToken(): string {
    return localStorage.getItem('access_token');
  }

  public isAuthenticated(): boolean {
    const token = this.getToken();
    return tokenNotExpired(null, token);
  }


}
