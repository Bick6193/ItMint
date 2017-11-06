import {Injectable} from '@angular/core';
import { CanActivate} from '@angular/router';

@Injectable()
export class AuthenticateGuardService implements CanActivate{
  canActivate() {
    console.log('Active#canActivate called');
    return true;
  }

}
