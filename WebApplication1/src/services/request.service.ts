import {Injectable} from '@angular/core';
import {RequestModel} from '../app/responce.models/request.model';
import {HttpClientService} from './http.client.service';
import {Observable} from 'rxjs/Observable';

@Injectable()
export class RequestService {
  private url = '/api/Request/Form';

  private urlTypes = '/api/Request/Types';

  constructor(private http: HttpClientService) {
  }

  public requestToServer(obj: RequestModel, token: string) {
    let temp =
      'Name=' + obj.Name +
      '&Phone=' + obj.Phone +
      '&Email=' + obj.Email +
      '&Description=' + obj.Description +
      '&RequestTypeInString=' + obj.RequestTypeInString +
      '&UserId=' + token;

    // let temp2 = JSON.stringify({
      //   Name: obj.Name,
      //   Phone: obj.Phone,
    //   Email: obj.Email,
    //   Description: obj.Description,
      //   RequestTypeInString: obj.RequestTypeInString,
     //   UserId: token
      // });
    return this.http.post(this.url, temp);
  }
  public GetTypes(): Observable<Array<string>> {
    return this.http.get(this.urlTypes);
  }
}

