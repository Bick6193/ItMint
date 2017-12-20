import {Injectable} from '@angular/core';
import {RequestModel} from '../app/responce.models/request.model';
import {HttpClientService} from './http.client.service';
import {Observable} from 'rxjs/Observable';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class RequestService {
  private url = '/api/Request/Form';

  private urlTypes = '/api/Request/Types';

  constructor(private http: HttpClientService, private httpClient: HttpClient) {
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
    this.GetIp().subscribe(
      data=>{
        console.log(data);
      }
    );
    return this.http.post(this.url, temp);
  }
  public GetTypes(): Observable<Array<string>> {
    return this.http.get(this.urlTypes);
  }
  private GetIp(): Observable<IpModel>
  {
    let json = 'http://ipv4.myexternalip.com/json';
    return this.httpClient.get(json);
  }
}
export class IpModel
{
  ip: string;
}

