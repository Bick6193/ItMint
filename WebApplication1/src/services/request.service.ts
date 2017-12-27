import { Injectable } from '@angular/core';
import { RequestModel } from '../app/responce.models/request.model';
import { HttpClientService } from './http.client.service';
import { Observable } from 'rxjs/Observable';
import { ArrayJsonFlag, JsonFlagModel } from '../assets/json/model';

export class RequestConfig
{
  public types: Array<string>;

  public code: string;
}

@Injectable()
export class RequestService
{
  private url = '/api/Request/Form';

  private urlConfig = '/api/Request/RequestConfig';

  constructor(private http: HttpClientService)
  {
  }

  public requestToServer(obj: RequestModel, token: string)
  {
    let temp =
      'Name=' + obj.Name +
      '&Phone=' + obj.Phone +
      '&Email=' + obj.Email +
      '&Description=' + obj.Description +
      '&RequestTypeInString=' + obj.RequestTypeInString +
      '&UserId=' + token;

    return this.http.post(this.url, temp);
  }

  public GetRequestConfig(): Observable<RequestConfig>
  {
    return this.http.get(this.urlConfig);
  }
  public GetFlag(url: string): Observable<ArrayJsonFlag>
  {
    return this.http.get(url);
  }
}

