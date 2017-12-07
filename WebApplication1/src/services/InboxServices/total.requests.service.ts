import {Injectable} from '@angular/core';
import {HttpClientService} from '../http.client.service';
import {Observable} from 'rxjs/Observable';
import {TotalServicesModel} from '../../app/request.models/total.services.model';
@Injectable()
export class TotalRequestsService {

  private url = '/api/Request/RequestToInboxInfo';

  constructor(private http: HttpClientService) {}

  public CountRequests(): Observable<TotalServicesModel> {
     return this.http.get(this.url);
  }
  public NormalRequestParseData(requestDate: Date): any {
    requestDate = new Date(requestDate);
    return requestDate;
  }

  public LatestRequestParseData(requestDate: Date): any {
    requestDate = new Date(requestDate);
    let nowDate = new Date();
    let range = new Date(nowDate.getTime() - requestDate.getTime()).getTime() / (3600 * 1000);
    return Math.round(range);
  }
}
