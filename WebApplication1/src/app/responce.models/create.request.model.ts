export class CreateRequestModel {
  id: number;
  type: string;
  employeesName: string;
  employeesEmail: string;
  messageToCustomer: string;
  messageBodyToCustomer: string
  isDefault: boolean;
  isEnabled: boolean;
  color: string;
}
