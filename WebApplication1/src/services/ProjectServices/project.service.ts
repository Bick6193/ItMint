import { Injectable } from '@angular/core';
import { JsonRequestsService } from '../InboxServices/json.requests.service';
import { ProjectModel } from '../../app/responce.models/project.model';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class ProjectService
{
  private urlInsert = '/api/Project/Insert';

  private urlGetProjects = '/api/Project/GetProjects';

  constructor(private http: JsonRequestsService)
  {
  }

  public GetProjects(): Observable<Array<ProjectModel>>
  {
    return this.http.get(this.urlGetProjects);

  }

  public InsertProject(items: ProjectModel): any
  {
    this.http.post(this.urlInsert, items).subscribe();
  }
}
