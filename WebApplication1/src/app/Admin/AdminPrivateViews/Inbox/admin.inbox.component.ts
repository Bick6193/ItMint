import {Component, OnInit} from '@angular/core';
import {HttpClientService} from '../../../../services/http.client.service';
import {GetRequestService} from '../../../../services/get.request.service';
import {RequestFromModel} from '../../../request.models/request.model';
import 'rxjs/add/operator/switchMap';
import {TotalRequestsService} from '../../../../services/InboxServices/total.requests.service';
import {TotalServicesModel} from '../../../request.models/total.services.model';
import {TypesCss} from '../../../../services/InboxServices/types.css';
import {Router} from '@angular/router';

@Component({
  selector: 'admin-inbox',
  templateUrl: './admin.inbox.component.html',
  styleUrls: [
    '../../../../assets/css/all.css',
    '../../../../assets/css/font-awesome.min.css'
  ],
  providers: [
    GetRequestService,
    HttpClientService,
    TotalRequestsService,
    TypesCss
  ]
})
export class AdminInboxComponent implements OnInit {

  private count: TotalRequestsService;

  private service: GetRequestService;

  public reqModel: RequestFromModel[];

  public totalRequests: TotalServicesModel;

  public cssTypes: TypesCss;

  public baseSearchWord: string = null;

  router: Router;

  public constructor(http: GetRequestService, tempCount: TotalRequestsService, tempcss: TypesCss, private route: Router) {
    this.service = http;
    this.count = tempCount;
    this.cssTypes = tempcss;
    this.router = route;
  }

  public ngOnInit(): void {
    this.service.GetData().subscribe(data => {
      this.reqModel = data;
      for (let i = 0; i < data.length; i++) {
        this.reqModel[i].date = this.count.NormalRequestParseData(this.reqModel[i].date);
      }
    });
    this.count.CountRequests().subscribe(data => {
      this.totalRequests = data;
      this.totalRequests.latestRequest = this.count.LatestRequestParseData(this.totalRequests.latestRequest);
    });
  }

  public SearchMethod(line: string): any {
    this.baseSearchWord = line;
    this.service.GetSearchData(this.baseSearchWord).subscribe(data => {
      this.reqModel = data;
    });
  }

  public getCssClass(flag: any): any {
    return this.cssTypes.getCssClass(flag);
  }

  public flagRequest(flag: boolean, viewed: boolean): any {
    return this.cssTypes.flagRequest(flag, viewed);
  }
  public logout(): any {
    localStorage.removeItem('access_token');
    localStorage.removeItem('refresh_token');
    this.router.navigate(['/Admin']);
  }
}

