import {Component} from '@angular/core';
import {LoginModel} from '../../responce.models/login.model';
import {LoginService} from '../../../services/login.service';
import {HttpClientService} from '../../../services/http.client.service';
import {Router} from '@angular/router';
import {AuthenticateGuardService} from '../../../services/library/authenticate.guard.service';
import { JsonRequestsService } from '../../../services/InboxServices/json.requests.service';

@Component({
  selector: 'admin-root',
  templateUrl: 'login.admin.component.html',
  styleUrls: [
    '../../../assets/css/all.css',
    '../../../assets/css/font-awesome.min.css'
  ],
  providers: [LoginService,
    HttpClientService,
  JsonRequestsService]
})
export class AdminComponent {
  user: LoginModel = new LoginModel();
  done = false;
  router: Router;

  constructor(private httpService: LoginService, private route: Router, private auth: AuthenticateGuardService) {
    this.router = route;
    if (auth.isAuthenticated()) {
      this.router.navigate(['/Admin/Inbox']);
    }

  }

  public submit(user): any {
    this.httpService.login(user);
  }
}
