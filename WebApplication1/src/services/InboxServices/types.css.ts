export class TypesCss {
  public getCssClass(flag: any): string {
    if (flag === 'QA') {
      return 'text-type gray-type';
    }
    if (flag === 'Design') {
      return 'text-type orange-type';
    }
    if (flag === 'Web Development') {
      return 'text-type';
    }
    if (flag === 'Testing') {
      return 'text-type green-type';
    }
    return 'text-type';
  }
  public flagRequest(flag: boolean, viewed: boolean) {
    if (!flag && !viewed) {
      return 'odd';
    }
    if (!flag && viewed) {
      return null;
    }
    if (flag && viewed) {
      return 'odd odd-orange';
    }
    return 'odd';
  }
}
