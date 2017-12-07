import { NgModule } from '@angular/core';
import {AdminMetadataComponent} from './admin.metadata.component';
import {routing} from './admin.metadata.routing';
import {CommonModule} from '@angular/common';
import {FormsModule} from '@angular/forms';

@NgModule({
  imports: [routing, CommonModule, FormsModule],
  declarations: []
})
export class LazyAdminMetadataModule {}
