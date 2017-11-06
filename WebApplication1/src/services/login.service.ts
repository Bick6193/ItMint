import {Injectable} from '@angular/core';
import {Response} from '@angular/http';
import {LoginModel} from '../app/models/login.model';
import 'rxjs/add/operator/map';
import {isUndefined} from 'util';
import {HttpClient, HttpHeaders} from '@angular/common/http';
@Injectable()
export class LoginService {
  public token: string;
  constructor(private http: HttpClient) { }
  public login(obj: LoginModel) {
    let temp = 'Login=' + obj.Login + '&Password=' + obj.Password;
    if (isUndefined(obj.Login) || isUndefined(obj.Password)) {
      obj.Login = '';
      obj.Password = '';
    }
    else {
      return this.http.post('/api/authenticate', temp, {headers: new HttpHeaders().set('Content-type', 'application/x-www-form-urlencoded')})
        .subscribe(resp => {
        if (!isUndefined(resp)) {
          this.token = resp['access_token'];
          localStorage.setItem('adm_token', this.token);
          return this.token;
        }
      });
    }
  }
  logout(): void {
    this.token = null;
    localStorage.removeItem('adm_token');
  }
}
