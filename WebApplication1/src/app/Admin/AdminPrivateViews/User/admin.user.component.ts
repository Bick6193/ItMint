import { Component, OnInit } from '@angular/core';
import { AddUsersModel } from '../../../responce.models/add.users.model';
import { AdminService } from '../../../../services/admin.service';
import { HttpClientService } from '../../../../services/http.client.service';
import { JsonRequestsService } from '../../../../services/InboxServices/json.requests.service';
import { ActivatedRoute } from '@angular/router';
import { UserModel } from '../../../request.models/user.model';

@Component({
  selector: 'admin-user',
  templateUrl: './admin.user.component.html',
  styleUrls: [
    '../../../../assets/css/all.css',
    '../../../../assets/css/font-awesome.min.css'
  ],
  providers: [AdminService,
    JsonRequestsService,
    HttpClientService]
})
export class AdminUserComponent implements OnInit
{
  private sub: any;
  private route: ActivatedRoute;
  public selectedId: number;


  public userModel: AddUsersModel = new AddUsersModel();

  constructor(private service: AdminService, tempRoute: ActivatedRoute)
  {

    this.route = tempRoute;
  }

  ngOnInit(): void
  {
    this.sub = this.route.params.subscribe(params =>
    {
      this.selectedId = +params['id'];
    });
    console.log(this.selectedId);
    if (!isNaN(this.selectedId))
    {
      this.GetUser();
    }
  }

  public ChooseMethod(items: AddUsersModel): any
  {
    if (isNaN(this.selectedId))
    {
      this.RequestUser(items);
    }
    else
    {
      this.UpdateUser(items);
    }
  }

  public RequestUser(items: AddUsersModel): any
  {
    items.login = items.email;
    this.service.RequestUser(items);
  }

  public UpdateUser(items: AddUsersModel): any
  {
    items.login = items.email;
    this.service.UpdateUser(items);
  }
  public GetUser(): any
  {
    this.service.GetUser(this.selectedId).subscribe(data =>
    {
      this.userModel = data;
    });
  }

  public DeleteUser(): any
  {
    this.service.DeleteUser(this.selectedId);
  }
}
