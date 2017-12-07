import 'rxjs/add/operator/do';
import {HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse} from '@angular/common/http';
import {AuthenticateGuardService} from './authenticate.guard.service';
import {Observable} from 'rxjs/Observable';
import {Injectable} from '@angular/core';
import 'rxjs/add/operator/retryWhen';
import 'rxjs/add/operator/delay';

export const PING_URL: string = 'api/token';
export const PING_METHOD: string = 'POST';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  constructor(public auth: AuthenticateGuardService) {
  }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    return next.handle(request).do((event: HttpEvent<any>) => {
      if (event instanceof HttpResponse) {
      }
    }, (err: any) => {
      if (err instanceof HttpErrorResponse) {
        if (err.status === 401) {
          this.auth.cacheResult.push(request);
          // return this.ping(next).switchMap(() => {
          //   return next.handle(request);
          // });
        }
      }
    });
  }

  private ping(next: HttpHandler): Observable<boolean> {
    const subscription = next.handle(this.createPingRequest())
      .retryWhen((errors: Observable<any>): Observable<any> => {
        return errors.delay(5000);
      }).subscribe();
    return null;
  }

  private createPingRequest(): HttpRequest<any> {
    return new HttpRequest(PING_METHOD, PING_URL, {});
  }

}
