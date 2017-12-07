import {Component} from '@angular/core';
import {CreateMetadataModel} from '../../../responce.models/create.metadata.model';
import {MetadataService} from '../../../../services/MetadataServices/metadata.service';
import {JsonRequestsService} from '../../../../services/InboxServices/json.requests.service';

@Component({
  selector: 'admin-metadet',
  templateUrl: './admin.metadata.details.component.html',
  styleUrls: [
    '../../../../assets/css/all.css',
    '../../../../assets/css/font-awesome.min.css'
  ],
  providers: [MetadataService, JsonRequestsService]
})
export class AdminMetadataDetailsComponent {

  metadata: CreateMetadataModel = new CreateMetadataModel();

  constructor(private http: MetadataService) {
  }


  public SendMetadata(metadata: CreateMetadataModel): any {
    this.http.SendMetadata(metadata);
  }
}
