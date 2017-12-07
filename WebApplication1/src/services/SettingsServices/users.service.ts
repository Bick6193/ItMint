import {Injectable} from '@angular/core';
import 'rxjs/add/operator/map';
import {JsonRequestsService} from '../InboxServices/json.requests.service';
import {Observable} from 'rxjs/Observable';
import {RequestUsersModel} from '../../app/request.models/Request.users.model';
import {RequestTypesModel} from '../../app/request.models/request.types.model';

@Injectable()
export class UsersService {

  private urlUsers = '/api/Users/GetUsersSettings';

  private urlRequests = '/api/Users/GetRequestTypes';

  constructor(private http: JsonRequestsService) {

  }
  public GetUsers(): Observable<RequestUsersModel[]> {
    return this.http.get(this.urlUsers);
  }
  public GetRequests(): Observable<RequestTypesModel[]> {
    return this.http.get(this.urlRequests);
  }
}
