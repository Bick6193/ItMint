import {Injectable} from '@angular/core';
import {JsonRequestsService} from '../InboxServices/json.requests.service';
import {ProjectModel} from '../../app/responce.models/project.model';

@Injectable()
export class ProjectService {
  private urlInsert = '/api/Project/Insert';

  constructor(private http: JsonRequestsService) {
  }

  public InsertProject(items: ProjectModel): any {
    this.http.post(this.urlInsert, items).subscribe();
  }
}
