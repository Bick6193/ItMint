import { Component, OnInit } from '@angular/core';
import { ProjectService } from '../../../../services/ProjectServices/project.service';
import { JsonRequestsService } from '../../../../services/InboxServices/json.requests.service';
import { ProjectModel } from '../../../request.models/project.model';

@Component({
  selector: 'admin-project',
  templateUrl: './admin.projects.component.html',
  styleUrls: [
    '../../../../assets/css/all.css',
    '../../../../assets/css/font-awesome.min.css'
  ],
  providers: [ProjectService, JsonRequestsService]
})
export class AdminProjectsComponent implements OnInit
{

  public projects: ProjectModel[];


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
