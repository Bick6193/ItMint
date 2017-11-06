import {Component} from '@angular/core';
import {LoginModel} from '../../models/login.model';
import {LoginService} from '../../../services/login.service';

@Component({
  selector: 'admin-root',
  templateUrl: 'login.admin.component.html',
  providers: [LoginService]
})
export class AdminComponent {
  user: LoginModel = new LoginModel();
  done = false;
  constructor(private httpService: LoginService) {
  }
  submit(user) {
    this.httpService.login(user);
  }
}
