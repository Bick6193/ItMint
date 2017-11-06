import {Injectable} from '@angular/core';
import {RequestModel} from '../app/models/request.model';
import {HttpClient} from '@angular/common/http';
import {HttpClientService} from './http.client.service';
@Injectable()
export class RequestService {
  private url = '/api/Request/Form';
  constructor(private http: HttpClient) {}
  public requestToServer(obj: RequestModel) {
    let httpCS = new HttpClientService(this.http);
    let temp =
      'Name=' + obj.Name +
      '&Phone=' + obj.Phone +
      '&Email=' + obj.Email +
      '&Description=' + obj.Description +
      '&RequestTypeInString=' + obj.RequestTypeInString;
    return httpCS.post(this.url, temp);
  }
}

