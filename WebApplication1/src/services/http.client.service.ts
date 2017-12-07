import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs/Observable';

@Injectable()
export class HttpClientService {
  private headers = new HttpHeaders()
    .set('Content-Type', 'application/x-www-form-urlencoded');

  constructor(private http: HttpClient) {
  }

  public get<T>(url: string): Observable<T> {
    return this.http.get<T>(url, {headers: this.headers});
  }
  public post<T>(url: string, body: any): Observable<T> {

    return this.http.post<T>(url,body, {headers: this.headers});
  }

  // public errorHandler<T>(observable: Observable<T>): Observable<T>
  // {
  //   return observable.catch((error: HttpErrorResponse) =>
  //   {
  //     if (error.status === 401)
  //     {
  //       return this.accessTokenService.getAuthTokenAccess().flatMap(() => observable);
  //     }
  //     return Observable.throw(error);
  //   });
  // }
}
