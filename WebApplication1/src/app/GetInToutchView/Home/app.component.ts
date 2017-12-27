///<reference path="../../../services/file.request.service.ts"/>
import { Component, OnInit } from '@angular/core';
import { RequestConfig, RequestService } from '../../../services/request.service';
import { RequestModel } from '../../responce.models/request.model';
import { FileRequestService } from '../../../services/file.request.service';
import { HttpClientService } from '../../../services/http.client.service';
import { HttpClientAttachService } from '../../../services/http.client.attach.service';
import { TokenRequestService } from '../../../services/token.request.service';
import { HttpClient, HttpEventType } from '@angular/common/http';
import { AuthenticateGuardService } from '../../../services/library/authenticate.guard.service';
import { ArrayJsonFlag, JsonFlagModel } from '../../../assets/json/model';

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
export class AppComponent implements OnInit
{

  public EMAIL_PATTERN = '[a-zA-Z_]+@[a-zA-Z_]+?\\.[a-zA-Z]{2,3}';

  req: RequestModel = new RequestModel();

  token: string;

  public filesToUpload: Array<File>;

  types: RequestConfig = new RequestConfig();

  public barInPersent: number;

  Flags: ArrayJsonFlag;


  constructor(private httpService: RequestService,
              private fileUpload: FileRequestService,
              private tokenService: TokenRequestService)
  {
    this.req.Name = '';
    this.req.Phone = '';
    this.httpService.GetFlag('../../../assets/json/phonesCode.json').subscribe(x =>
    {
      this.Flags = x;
    });
  }

  ngOnInit(): void
  {
    this.token = this.tokenService.GenerateToken();
    this.httpService.GetRequestConfig().subscribe(data =>
    {
      this.types = data;
      this.req.Phone = this.types.code;
    });
  }

  public submit(req): any
  {
    this.httpService.requestToServer(req, this.token).subscribe();
  }

  public fileDownload(fileInput: any): void
  {
    this.filesToUpload = <Array<File>> fileInput.target.files;
    this.fileUpload.makeFileRequest(this.filesToUpload, this.token).subscribe(event =>
    {
      if (event.type === HttpEventType.UploadProgress)
      {
        this.barInPersent = Math.round(100 * event.loaded / event.total);
      }
    });
  }

  public ProgressBar(): string
  {
    if (this.barInPersent == 100)
    {
      return 'file-load-success';
    }
    if (this.barInPersent < 100)
    {
      return 'file-downloaded';
    }
  }

  protected DeleteFromFileArray(name: string): any
  {
    for (let i = 0; i < this.filesToUpload.length; i++)
    {
      if (this.filesToUpload[i].name === name)
      {
        //this.filesToUpload.splice(i, 1);
        console.log(this.filesToUpload.length);
      }
    }

  }

  public OnChange(item: string)
  {
    console.log(item);
  }

  public GetFlag(code: string): any
  {
    let valueFlag: JsonFlagModel = new JsonFlagModel();

    let valueShort: JsonFlagModel = new JsonFlagModel();
    valueFlag.code = code;
    if (code.length >= 3)
    {
      valueFlag = this.Flags.countries.find(item => item.code == code);
      this.httpService.GetFlag('../../../assets/json/shortCountry.json').subscribe(data =>
        {
          console.log(data);
        }
      );
    }
    console.log(valueShort);
    return 'by.png';
  }
}

