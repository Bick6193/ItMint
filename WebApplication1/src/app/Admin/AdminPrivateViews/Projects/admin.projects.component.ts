import { Component, OnInit } from '@angular/core';
import { ProjectService } from '../../../../services/ProjectServices/project.service';
import { JsonRequestsService } from '../../../../services/InboxServices/json.requests.service';
import { ProjectModelSmall } from '../../../request.models/project.model';
import { HttpClientService } from '../../../../services/http.client.service';

@Component({
  selector: 'admin-project',
  templateUrl: './admin.projects.component.html',
  styleUrls: [
    '../../../../assets/css/all.css',
    '../../../../assets/css/font-awesome.min.css'
  ],
  providers: [ProjectService, JsonRequestsService, HttpClientService]
})
export class AdminProjectsComponent implements OnInit
{

  public projects: ProjectModelSmall[];


  constructor(private http: ProjectService) {}

  ngOnInit(): void
  {
    this.http.GetProjects().subscribe(data =>
    {
      this.projects = data;
      console.log(this.projects);
    });
  }

}
