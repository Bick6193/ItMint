import {Injectable} from '@angular/core';
import {HttpClient, HttpEventType, HttpHeaders, HttpRequest, HttpResponse} from '@angular/common/http';

@Injectable()
export class HttpClientAttachService {
  private headers = new HttpHeaders();

  constructor(private http: HttpClient) {
  }

  public get (url: string): any{
    return this.http.get(url, {headers: this.headers});
  }

  public post(url: string, body: any): any {
    const req = new HttpRequest('POST', url, body, {
      reportProgress: true,
    });
    return this.http.request(req);
  }
}
