import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {AdminService} from '../../../../services/admin.service';
import {AddUsersModel} from '../../../responce.models/add.users.model';
import {JsonRequestsService} from '../../../../services/InboxServices/json.requests.service';
import { HttpClientService } from '../../../../services/http.client.service';

@Component({
  selector: 'app-middle',
  templateUrl: './middle.component.html',
  styleUrls: [
    '../../../../assets/css/all.css',
    '../../../../assets/css/font-awesome.min.css'
  ],
  providers: [AdminService, JsonRequestsService, HttpClientService]
})
export class MiddleComponent implements OnInit{
  private sub: any;

  modelUser: AddUsersModel = new AddUsersModel();

  private route: ActivatedRoute;

  public selectedId: number;

  constructor(private tempRoute: ActivatedRoute, private http: AdminService) {
    this.route = tempRoute;
  }

  ngOnInit(): void {
    this.sub = this.route.params.subscribe(params => { //Сделать проверку на пароль в базе. Если есть, то менять нельзя
      this.selectedId = +params['id'];
      this.modelUser.id = this.selectedId;
    });
  }
  public Reset(): any {
    console.log(this.modelUser);
    this.http.SetPassword(this.modelUser);
  }
}
