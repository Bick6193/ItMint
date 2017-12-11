import { Component, OnInit } from '@angular/core';
import { ProjectModel } from '../../../responce.models/project.model';
import { ProjectService } from '../../../../services/ProjectServices/project.service';
import { JsonRequestsService } from '../../../../services/InboxServices/json.requests.service';
import { FileRequestService } from '../../../../services/file.request.service';
import { HttpClientAttachService } from '../../../../services/http.client.attach.service';

@Component({
  selector: 'admin-projdet',
  templateUrl: './admin.projects.details.component.html',
  styleUrls: [
    '../../../../assets/css/all.css',
    '../../../../assets/css/font-awesome.min.css'
  ],
  providers: [ProjectService, JsonRequestsService, FileRequestService, HttpClientAttachService]
})
export class AdminProjectDetailsComponent implements OnInit
{


  project: ProjectModel = new ProjectModel();

  public fileArray: Array<File>;

  constructor(private http: ProjectService,
              private fileUpload: FileRequestService)
  {

  }

  ngOnInit(): void
  {

  }

  public InsertProject(items: ProjectModel): void
  {
    items.Files = this.fileArray[0];
    this.fileUpload.ProjectFile(this.fileArray, items.Name).subscribe();
    //this.http.InsertProject(items);
  }

  public UploadArchive(fileArchive: any): any
  {
    this.fileArray = fileArchive.target.files;
  }
}
