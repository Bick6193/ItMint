import {Injectable} from '@angular/core';
import {CreateMetadataModel} from '../../app/responce.models/create.metadata.model';
import {JsonRequestsService} from '../InboxServices/json.requests.service';

@Injectable()
export class MetadataService {

  private url = 'api/Metadata/Insert';

  constructor(private http:JsonRequestsService) {}

  public SendMetadata(items: CreateMetadataModel): any {
    this.http.post(this.url, items).subscribe();
  }
}
