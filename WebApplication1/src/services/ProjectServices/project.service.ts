import { Injectable } from '@angular/core';
import { JsonRequestsService } from '../InboxServices/json.requests.service';
import { ProjectModel } from '../../app/responce.models/project.model';

import { ProjectModelSmall } from '../../app/request.models/project.model';
import { Observable } from 'rxjs/Observable';
import { HttpClientService } from '../http.client.service';
import { DateModel } from '../../app/responce.models/date.model';
import { isNumber } from 'util';
import { FileVersionModel } from '../../app/request.models/file.version.model';

@Injectable()
export class ProjectService
{
  private urlInsert = '/api/Project/Insert';

  private urlGetProjects = '/api/Project/GetProjects';

  private urlGetProjectById = '/api/Project/GetProjectById';

  private urlGetFilesById = '/api/Project/GetFilesById';

  private urlGetDatesById = '/api/Project/GetDatesById';

  private urlDataByDate = '/api/Project/GetDataByDate';

  private urlFilesByDate = '/api/Project/GetFilesByDate';

  private urlDeleteProject = '/api/Project/DeleteProject';


  newDirectory: Array<string> = [];
  newFiles: Array<string> = [];

  constructor(private http: JsonRequestsService, private httpClient: HttpClientService)
  {
  }

  public GetProjects(): Observable<Array<ProjectModelSmall>>
  {
    return this.http.get(this.urlGetProjects);

  }

  public GetProjectById(id: string): Observable<ProjectModelSmall>
  {
    let tempId =
      'Id=' + id;
    return this.httpClient.post(this.urlGetProjectById, tempId);
  }

  public GetFilesById(id: string): Observable<FileVersionModel>
  {
    let tempId =
      'Id=' + id;
    return this.httpClient.post(this.urlGetFilesById, tempId);
  }

  public GetDatesById(id: string): Observable<Array<Date>>
  {
    let tempId =
      'Id=' + id;
    return this.httpClient.post(this.urlGetDatesById, tempId);
  }

  public DataByDate(item: DateModel): Observable<ProjectModelSmall>
  {
    return this.http.post(this.urlDataByDate, item);
  }

  public FilesByDate(item: DateModel): Observable<FileVersionModel>
  {
    return this.http.post(this.urlFilesByDate, item);
  }

  public InsertProject(items: ProjectModelSmall): any
  {
    this.http.post(this.urlInsert, items).subscribe();
  }

  public DeleteProject(id: string): any
  {
    let tempId =
      'Id=' + id;
    return this.httpClient.post(this.urlDeleteProject, tempId);
  }

  public ParseDirectory(items: Array<string>): any
  {
    this.newDirectory = [];
    let temp: string;
    for (let i = 0; i < items.length; i++)
    {
      if (!(items[i].indexOf('.') > -1) && (items[i].indexOf('/') > -1))
      {
        temp = items[i].substring(0, items[i].indexOf('/'));

        if (!this.newDirectory.includes(temp))
        {
          this.newDirectory.push(temp);
        }
      }
    }
    return this.newDirectory;
  }

  public ParseFiles(items: Array<string>): any
  {
    this.newFiles = [];
    for (let i = 0; i < items.length; i++)
    {
      if (!(items[i].indexOf('/') > -1) && (items[i].indexOf('.') > -1))
      {
        this.newFiles.push(items[i]);

      }
    }
    return this.newFiles;
  }
}
