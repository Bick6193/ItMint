import {Injectable} from '@angular/core';
import {getRandomString} from 'selenium-webdriver/safari';

@Injectable()
export class TokenRequestService {
  public GenerateToken(): string {
    let token = Math.random().toString();
    console.log(token);
    return token;
  }
}
