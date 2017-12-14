import { Component, OnInit } from '@angular/core';
import { ProjectModel } from '../../../responce.models/project.model';
import { ProjectService } from '../../../../services/ProjectServices/project.service';
import { JsonRequestsService } from '../../../../services/InboxServices/json.requests.service';
import { FileRequestService } from '../../../../services/file.request.service';
import { HttpClientAttachService } from '../../../../services/http.client.attach.service';
import { isUndefined } from 'util';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClientService } from '../../../../services/http.client.service';
import { ProjectModelSmall } from '../../../request.models/project.model';
import { DatePipe } from '@angular/common';
import { DateModel } from '../../../responce.models/date.model';
import { FileVersionModel } from '../../../request.models/file.version.model';

@Component({
  selector: 'admin-projdet',
  templateUrl: './admin.projects.details.component.html',
  styleUrls: [
    '../../../../assets/css/all.css',
    '../../../../assets/css/font-awesome.min.css'
  ],
  providers: [ProjectService, JsonRequestsService, FileRequestService, HttpClientAttachService, HttpClientService, DatePipe]
})
export class AdminProjectDetailsComponent implements OnInit
{

  public password = '';

  private sub: any;

  private route: ActivatedRoute;

  private selectedId: string;

  public project: ProjectModelSmall = new ProjectModelSmall();

  private dateModel: DateModel = new DateModel();

  public fileVersionModel: FileVersionModel;

  public fileArray: Array<File> = [];

  public dateArray: Array<Date>;

  public nameDirectoryArray: Array<string>;

  public nameFileArray: Array<string>;

  public navigateRourer: Router;

  constructor(private http: ProjectService,
              private fileUpload: FileRequestService,
              private router: ActivatedRoute,
              private dataPipe: DatePipe,
              private navigateRoute: Router)
  {
    this.route = router;
    this.navigateRourer = navigateRoute;
  }

  ngOnInit(): void
  {
    this.sub = this.route.params.subscribe(params =>
    {
      this.selectedId = params['id'];
    });
    if (!isUndefined(this.selectedId))
    {
      this.GetProjectById();
    }
  }

  public InsertProject(items: ProjectModelSmall): void
  {
    if (!(this.fileArray.length === 1))
    {
      items.files = this.fileArray[0];
    }
    items.password = this.password;
    if (isUndefined(items.projectId))
    {
      items.projectId = this.GenerateHash();
    }
    this.http.InsertProject(items);
    this.fileUpload.ProjectFile(this.fileArray, items.url, items.projectId).subscribe(x =>
    {
      this.navigateRourer.navigate(['/Admin/Projects']);
    });
  }

  public UploadArchive(fileArchive: any): any
  {
    this.fileArray = fileArchive.target.files;
  }

  public GetProjectById(): void
  {
    this.http.GetProjectById(this.selectedId).subscribe(data =>
    {
      this.project = data;
      this.password = this.project.password;
      this.GetFilesById(this.project.projectId);
      this.GetDatesById(this.project.projectId);
    });
  }

  public GetFilesById(id: string): void
  {
    this.http.GetFilesById(id).subscribe(data =>
    {
      this.fileVersionModel = data;
      this.nameDirectoryArray = this.http.ParseDirectory(this.fileVersionModel.listFile);
      this.nameFileArray = this.http.ParseFiles(this.fileVersionModel.listFile);


    });

  }

  public GetDatesById(id: string): void
  {
    this.http.GetDatesById(id).subscribe(data =>
    {
      this.dateArray = data;
    });
  }

  public GenerateHash(): any
  {
    let chars = 'abcdefghijklmnopqrstuvwxyz.ABCDEFGHIJKLMNOP1234567890';
    let pass = '';
    for (let x = 0; x < 8; x++)
    {
      let i = Math.floor(Math.random() * chars.length);
      pass += chars.charAt(i);
    }
    this.password = pass;
    return pass;
  }

  public DataByDate(value: Date, id: string): any
  {
    this.dataPipe.transform(value, 'yyyy-MM-dd HH:mm:ss');
    this.dateModel.id = id;
    this.dateModel.dateTime = value;
    this.http.DataByDate(this.dateModel).subscribe(data =>
    {
      this.project = data;
      this.password = this.project.password;
    });
    this.http.FilesByDate(this.dateModel).subscribe(data =>
    {
      this.fileVersionModel.version = data.version;
      if (this.fileVersionModel.listFile != null)
      {
        this.nameDirectoryArray = this.http.ParseDirectory(data.listFile);
        this.nameFileArray = this.http.ParseFiles(data.listFile);
      }
    });

  }

  DeleteProject(projectId: string): any
  {
    this.http.DeleteProject(projectId).subscribe(x =>
    {
      this.navigateRourer.navigate(['/Admin/Projects']);
    });
  }
}
