import {Injectable} from '@angular/core';
import {HttpClientService} from './http.client.service';
import {HttpClientAttachService} from './http.client.attach.service';

@Injectable()
export class FileRequestService {
  private url = 'api/Request/Doc';
  private urlProj = 'api/Project/Doc';
  constructor(private http: HttpClientAttachService) {
  }

  public makeFileRequest(files: Array<File>, token: string) {
    console.log(files);
    let formData = new FormData();
    for (const value of files) {
      formData.append('files', value, value.name);
    }
    formData.append(token, token);
    return this.http.post(this.url, formData);
  }

  public ProjectFile(file: Array<File>, name: string, id: string) {
    console.log(file);
    let formData = new FormData();
    for (const value of file) {
      formData.append('files', value, value.name);
    }
    formData.append(name, name);
    formData.append(id, id);
    return this.http.post(this.urlProj, formData);
  }
}
