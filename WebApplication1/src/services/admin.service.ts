import { Injectable } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { LoginModel } from '../app/responce.models/login.model';
import { LoginService } from './login.service';
import 'rxjs/add/operator/map';
import { HttpClientService } from './http.client.service';
import { AddUsersModel } from '../app/responce.models/add.users.model';
import { JsonRequestsService } from './InboxServices/json.requests.service';
import { CreateRequestModel } from '../app/responce.models/create.request.model';
import { UserModel } from '../app/request.models/user.model';

@Injectable()
export class AdminService
{

  private urlRequestUser = 'api/Users/RequestUser';

  private urlUpdateUser = 'api/Users/UpdateUser';

  private urlSetPassword = 'api/Users/SetPassword';

  private urlSaveRequest = 'api/Users/SaveRequest';

  private urlGetUser = '/api/Users/GetUser';

  private urlDeleteUser = '/api/Users/DeleteUser';

  private urlGetRequest = '/api/Users/GetRequest';

  private urlUpdateRequest = '/api/Users/UpdateRequest';

  constructor(private http: JsonRequestsService,
              private httpCliend: HttpClientService)
  {

  }

  public RequestUser(items: AddUsersModel): any
  {
    console.log(items);
    this.http.post(this.urlRequestUser, items).subscribe();
  }

  public UpdateUser(items: AddUsersModel): any
  {
    this.http.post(this.urlUpdateUser, items).subscribe();
  }

  public DeleteUser(id: number): any
  {
    let tempId =
      'Id=' + id;
    this.httpCliend.post(this.urlDeleteUser, tempId).subscribe(x =>
    {
      console.log(x);
    });
  }

  public SetPassword(items: AddUsersModel): any
  {
    this.http.post(this.urlSetPassword, items).subscribe(data =>
    {
      if (data)
      {
        console.log('OK');
      }
    });
  }

  public SaveRequest(items: CreateRequestModel): any
  {
    this.http.post(this.urlSaveRequest, items).subscribe();
  }

  public GetUser(id: number): Observable<AddUsersModel>
  {
    let tempId =
      'Id=' + id;
    return this.httpCliend.post(this.urlGetUser, tempId);
  }

  public GetRequest(id: number): Observable<CreateRequestModel>
  {
    let tempId =
      'Id=' + id;
    return this.httpCliend.post(this.urlGetRequest, tempId);
  }
  public UpdateRequest(items: CreateRequestModel): any
  {
    return this.http.post(this.urlUpdateRequest, items).subscribe();
  }
}
