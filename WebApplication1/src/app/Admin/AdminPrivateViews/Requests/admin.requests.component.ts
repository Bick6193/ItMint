import { Component, OnInit } from '@angular/core';
import { CreateRequestModel } from '../../../responce.models/create.request.model';
import { AdminService } from '../../../../services/admin.service';
import { JsonRequestsService } from '../../../../services/InboxServices/json.requests.service';
import { HttpClientService } from '../../../../services/http.client.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'admin-requests',
  templateUrl: './admin.requests.component.html',
  styleUrls: [
    '../../../../assets/css/all.css',
    '../../../../assets/css/font-awesome.min.css'
  ],
  providers: [AdminService, JsonRequestsService, HttpClientService]
})
export class AdminRequestsComponent implements OnInit
{


  public colors = [
    'label-color label-green',
    'label-color label-green02',
    'label-color label-blue',
    'label-color label-blue02',
    'label-color label-purple',
    'label-color label-green03',
    'label-color label-green04',
    'label-color label-blue03',
    'label-color label-blue04',
    'label-color label-purple02',
    'label-color label-orange',
    'label-color label-orange02',
    'label-color label-red',
    'label-color',
    'label-color label-gray',
    'label-color label-orange03',
    'label-color label-orange04',
    'label-color label-red02',
    'label-color label-gray02',
    'label-color label-gray03'
  ];

  public selectedColor: string = 'btn-color btn-open';

  status: boolean = false;

  request: CreateRequestModel = new CreateRequestModel();

  private sub: any;
  private route: ActivatedRoute;
  public selectedId: number;

  constructor(private http: AdminService, private router: ActivatedRoute)
  {
    this.route = router;
  }

  ngOnInit(): void
  {
    this.sub = this.route.params.subscribe(params =>
    {
      this.selectedId = +params['id'];
    });
    if (!isNaN(this.selectedId))
    {
      this.GetRequest();
    }
  }

  public EventIcons(): any
  {
    this.status = !this.status;
  }

  public ChangeColor(item: string): any
  {
    this.selectedColor = item;
    this.request.color = item;
  }

  public SaveRequest(request: CreateRequestModel): any
  {
    this.http.SaveRequest(request);
  }

  public GetRequest(): any
  {
    this.http.GetRequest(this.selectedId).subscribe(data =>
    {
      this.request = data;
    });
  }
}
