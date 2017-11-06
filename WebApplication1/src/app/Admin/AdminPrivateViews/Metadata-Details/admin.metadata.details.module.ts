import { NgModule } from '@angular/core';
import {AdminMetadataDetailsComponent} from './admin.metadata.details.component';
import {routing} from './admin.metadata.details.routing';
import {CommonModule} from '@angular/common';
import {FormsModule} from '@angular/forms';

@NgModule({
  imports: [routing, CommonModule, FormsModule],
  declarations: [AdminMetadataDetailsComponent]
})
export class LazyAdminMetadataDetailsModule {}
