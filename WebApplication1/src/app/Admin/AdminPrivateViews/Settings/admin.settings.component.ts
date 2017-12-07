import {Component, OnInit} from '@angular/core';
import {UsersService} from '../../../../services/SettingsServices/users.service';
import {JsonRequestsService} from '../../../../services/InboxServices/json.requests.service';
import {AddUsersModel} from '../../../responce.models/add.users.model';
import {RequestUsersModel} from '../../../request.models/Request.users.model';
import {RequestTypesModel} from '../../../request.models/request.types.model';

@Component({
  selector: 'admin-settings',
  templateUrl: 'admin.settings.component.html',
  styleUrls: [
    '../../../../assets/css/all.css',
    '../../../../assets/css/font-awesome.min.css'
  ],
  providers: [UsersService, JsonRequestsService]
})
export class AdminSettingsComponent implements OnInit{

  public users: RequestUsersModel[];

  public requests: RequestTypesModel[];

  constructor(private http: UsersService) {

  }
  public ngOnInit(): void {
    this.http.GetUsers().subscribe(
      data => {
        this.users = data;
        console.log(this.users);
      }
    );
    this.http.GetRequests().subscribe(data=>{
      this.requests = data;
      console.log(this.requests);
    });
  }

}
