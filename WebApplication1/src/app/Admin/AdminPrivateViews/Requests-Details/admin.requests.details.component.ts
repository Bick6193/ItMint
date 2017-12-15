import { Component, OnInit } from '@angular/core';
import { HttpClientService } from '../../../../services/http.client.service';
import { RequestFromModel } from '../../../request.models/request.model';
import { GetRequestService } from '../../../../services/get.request.service';
import { ActivatedRoute } from '@angular/router';
import { TotalRequestsService } from '../../../../services/InboxServices/total.requests.service';
import { TypesCss } from '../../../../services/InboxServices/types.css';
import { FileModel } from '../../../request.models/file.model';

@Component({
  selector: 'admin-reqdet',
  templateUrl: './admin.requests.details.component.html',
  styleUrls: [
    '../../../../assets/css/all.css',
    '../../../../assets/css/font-awesome.min.css'
  ],
  providers: [GetRequestService,
    HttpClientService,
    TotalRequestsService,
    TypesCss
  ]
})
export class AdminRequestsDetailsComponent implements OnInit
{

  private sub: any;

  private route: ActivatedRoute;

  private selectedId: number;

  private service: GetRequestService;

  public reqModel: RequestFromModel;

  public fileModel: Array<FileModel>;

  private count: TotalRequestsService;

  protected flag: boolean;

  public cssType: TypesCss;

  constructor(httpGetService: GetRequestService,
              tempRoute: ActivatedRoute,
              tempCount: TotalRequestsService,
              tempcss: TypesCss)
  {
    this.service = httpGetService;
    this.route = tempRoute;
    this.count = tempCount;
    this.cssType = tempcss;
  }

  private GetRequestById(id: number): void
  {
    this.service.GetDataById(id).subscribe(data =>
    {
      this.reqModel = data;
      this.reqModel.date = this.count.NormalRequestParseData(this.reqModel.date);
    });
  }

  private GetFilesById(id: number): void
  {
    this.service.GetFile(id).subscribe(data =>
    {
      this.fileModel = data;
      console.log(this.fileModel);
    });
  }

  ngOnInit(): void
  {
    this.sub = this.route.params.subscribe(params =>
    {
      this.selectedId = +params['id'];
      this.GetRequestById(this.selectedId);
      this.GetFilesById(this.selectedId);
    });
  }

  public CheckingFlag(id: number): any
  {
    this.service.GetFlag(id).subscribe();
  }

  public getCssClass(flag: any): any
  {
    return this.cssType.getCssClass(flag);
  }

  public DeleteRequest(id: number): any
  {
    this.service.DeleteData(id).subscribe();
  }

  protected fileClasses(type: string): string
  {
    if (type === 'application/pdf')
    {
      return 'fa fa-file-pdf-o';
    }
    if (type === 'text/plain')
    {
      return 'fa fa-file-text-o';
    }
    if (type === 'application/vnd.openxmlformats-officedocument.wordprocessingml.document')
    {
      return 'fa fa-file-word-o';
    }
    if (type === 'application/x-zip-compressed')
    {
      return 'fa fa-file-zip-o';
    }
    if (type === 'image/png')
    {
      return 'fa fa-file-photo-o';
    }
    if (type === 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet')
    {
      return 'fa fa-file-excel-o';
    }
    if (type === 'application/vnd.openxmlformats-officedocument.presentationml.presentation')
    {
      return 'fa fa-file-powerpoint-o';
    }
    return 'fa file';
  }

  public DownloadFileById(id: number): any
  {
   this.service.GetFileById(id).subscribe();
  }
}
