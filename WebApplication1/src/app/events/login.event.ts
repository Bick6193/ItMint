export class LoginEvent {
  constructor(LOGIN_RESULT: string) {

  }

  public static LOGIN_RESULT = 'loginResultEvent';

 public success: boolean;
 public message: string;

 public static failed(message?: string): LoginEvent {
   const event = new LoginEvent(LoginEvent.LOGIN_RESULT);
   event.message = message;
   event.success = false;
   return event;
 }
  public static success(): LoginEvent
  {
    const event = new LoginEvent(LoginEvent.LOGIN_RESULT);
    event.success = true;
    return event;
  }
}
