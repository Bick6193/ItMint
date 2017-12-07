import {Injectable} from '@angular/core';
import {LoginModel} from '../app/responce.models/login.model';
import 'rxjs/add/operator/map';
import {HttpClientService} from './http.client.service';
import {TokenInterceptor} from './library/token.interceptor.library';
import {Router} from '@angular/router';
export class AuthRequest {
  username: string;
  password: string;
  grant_type = 'password';
  client_id = 'ngApp';

  constructor(username:string, password:string)
  {
    this.username = username;
    this.password = password;
  }
}

@Injectable()
export class LoginService {

  public token: string;

  public urlLogin = 'api/token';

  router: Router;

  constructor(private http: HttpClientService, private route: Router) {
    this.router = route;
  }

  public login(obj: LoginModel) {
    const body = new AuthRequest(obj.Login, obj.Password);
    console.log(body);
    this.http.post(this.urlLogin, body)
      .subscribe(resp => {
        console.log(resp);
        this.token = resp['object'];
        localStorage.setItem('access_token', this.token['accessToken']);
        localStorage.setItem('refresh_token', this.token['refreshToken']);
        this.router.navigate(['/Admin/Inbox']);
      });


  }

  logout(): void {
    this.token = null;
    localStorage.removeItem('access_token');
  }
}
