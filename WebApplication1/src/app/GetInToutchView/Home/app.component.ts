///<reference path="../../../services/file.request.service.ts"/>
import {Component, OnInit} from '@angular/core';
import {RequestService} from '../../../services/request.service';
import {RequestModel} from '../../responce.models/request.model';
import {FileRequestService} from '../../../services/file.request.service';
import {HttpClientService} from '../../../services/http.client.service';
import {HttpClientAttachService} from '../../../services/http.client.attach.service';
import {TokenRequestService} from '../../../services/token.request.service';
import {HttpEventType} from '@angular/common/http';
import {AuthenticateGuardService} from '../../../services/library/authenticate.guard.service';

@Component({
  selector: 'menu-root',
  templateUrl: 'app.component.html',
  styleUrls: [
    '../../../assets/css/main.css',
    '../../../assets/css/services.css'
  ],
  providers: [RequestService,
    FileRequestService,
    HttpClientService,
    HttpClientAttachService,
    TokenRequestService
  ]
})
export class AppComponent implements OnInit {


  public EMAIL_PATTERN = '[a-zA-Z_]+@[a-zA-Z_]+?\\.[a-zA-Z]{2,3}';

  req: RequestModel = new RequestModel();

  token: string;

  public filesToUpload: Array<File>;

  requestType: string[] = [
    'Web Development',
    'Design',
    'QA',
    'Testing'
  ];

  types: Array<string>;

  public barInPersent: number;

  constructor(private httpService: RequestService,
              private fileUpload: FileRequestService,
              private tokenService: TokenRequestService) {
    this.req.Name = '';
    this.req.Phone = '';
  }

  ngOnInit(): void {
    this.token = this.tokenService.GenerateToken();
    this.httpService.GetTypes().subscribe(data => {
      this.types = data;
    });
  }

  public submit(req): any {
    this.httpService.requestToServer(req, this.token).subscribe();
  }

  public fileDownload(fileInput: any): void {
    this.filesToUpload = <Array<File>> fileInput.target.files;
    this.fileUpload.makeFileRequest(this.filesToUpload, this.token).subscribe(event => {
      if (event.type === HttpEventType.UploadProgress) {
        this.barInPersent = Math.round(100 * event.loaded / event.total);
      }
    });
  }

  public ProgressBar(): string {
    if (this.barInPersent == 100) {
      return 'file-load-success';
    }
    if (this.barInPersent < 100) {
      return 'file-downloaded';
    }
  }

  protected DeleteFromFileArray(name: string): any {
    for (let i = 0; i < this.filesToUpload.length; i++) {
      if (this.filesToUpload[i].name === name) {
        //this.filesToUpload.splice(i, 1);
        console.log(this.filesToUpload.length);
      }
    }

  }

  public OnChange(item: string) {
    console.log(item);
  }
}
