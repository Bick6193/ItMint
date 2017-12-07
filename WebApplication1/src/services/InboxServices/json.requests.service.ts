import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs/Observable';

@Injectable()
export class JsonRequestsService {
  private headers = new HttpHeaders()
    .set('Content-Type', 'application/x-www-form-urlencoded')
    .set('Content-Type', 'application/json');

  constructor(private http: HttpClient) {
  }

  public get <T>(url: string): Observable<T> {
    return this.http.get<T>(url, {headers: this.headers});
  }

  public post<T>(url: string, body: any): Observable<T> {

    return this.http.post<T>(url, JSON.stringify(body), {headers: this.headers});
  }
}
