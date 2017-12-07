import { Injectable } from '@angular/core';
import { HttpClientService } from './http.client.service';
import { Observable } from 'rxjs/Observable';
import { RequestFromModel } from '../app/request.models/request.model';
import { isUndefined } from 'util';
import { FileModel } from '../app/request.models/file.model';

@Injectable()
export class GetRequestService
{

  private urlData = '/api/Request/RequestToInbox';

  private urlDataById = '/api/Request/RequestIdToInbox';

  private urlSearchData = '/api/Request/RequestSearchToInbox';

  private urlFlag = '/api/Request/RequestFlagToInbox';

  private urlDelete = '/api/Request/Delete';

  private urlFile = 'api/Request/Files';

  constructor(private http: HttpClientService)
  {
  }

  public GetData(): Observable<RequestFromModel[]>
  {
    return this.http.get(this.urlData);
  }

  public GetDataById(id: number): Observable<RequestFromModel>
  {
    let tempId =
      'Id=' + id;
    return this.http.post(this.urlDataById, tempId);
  }

  public DeleteData(id: number): any
  {
    let tempId =
      'Id=' + id;
    return this.http.post(this.urlDelete, tempId);
  }

  public GetSearchData(line: string): Observable<RequestFromModel[]>
  {
    let tempLine = 'Line=' + line;
    return this.http.post(this.urlSearchData, tempLine);
  }

  public GetFlag(id: number): Observable<boolean>
  {
    let tempId =
      'Id=' + id;
    return this.http.post(this.urlFlag, tempId);
  }

  public GetFile(id: number): Observable<Array<FileModel>>
  {
    let tempId =
      'Id=' + id;
    return this.http.post(this.urlFile, tempId);
  }
}
