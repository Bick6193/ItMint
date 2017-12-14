export class AddUsersModel {
  id: number;
  fullName: string;
  login: string;
  email: string;
  position: string;
  phoneNumber: string;
  active: boolean;
  password: string;
  isAdministrative: boolean = false;
}
