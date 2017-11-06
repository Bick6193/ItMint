import {Component} from '@angular/core';
import {RequestService} from '../../services/request.service';
import {RequestModel} from '../models/request.model';
import {FileRequestService} from '../../services/file.request.service';

@Component({
  selector: 'menu-root',
  templateUrl: 'app.component.html',
  providers: [RequestService]
})
export class AppComponent {
req: RequestModel = new RequestModel();
requestType: string[] = [
    'Web Development',
    'Design',
    'QA',
    'Testing'
  ];
constructor(private httpService: RequestService) {}
submit(req) {
  console.log(req);
  this.httpService.requestToServer(req)
    .subscribe();
}
fileDownload(event) {
  let fileList: FileList = event.target.files;
  if (fileList.length > 0) {
    console.log(fileList);
    let file: File = fileList[0];
    let formData: FormData = new FormData();
    formData.append('uploadFile', file, file.name);
  }
  }
}
