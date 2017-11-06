import {Injectable} from '@angular/core';
import {Http, Headers, Response} from '@angular/http';
import {Observable} from 'rxjs/Observable';
import {LoginModel} from '../app/models/login.model';
import {LoginService} from './login.service';
import 'rxjs/add/operator/map';
@Injectable()
export class AdminService {

  constructor(private http: Http, private authenticate: LoginService) {

  }

}
