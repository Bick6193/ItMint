import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {FileRequestModel} from '../app/models/file.request.model';
import {HttpClientService} from './http.client.service';

@Injectable()
export class FileRequestService {
  private url = '/api/Request/Form/Doc';
  constructor(private http: HttpClient) {}
  public requestFileToServer(obj: FileRequestModel) {
    let httpCS = new HttpClientService(this.http);
    let temp = [
      'FileName=' + obj.FileName +
      '&CreatedDay=' + obj.CreatedDay +
      '&FileSize=' + obj.FileSize
    ];
    return httpCS.post(this.url, temp);
  }
}
