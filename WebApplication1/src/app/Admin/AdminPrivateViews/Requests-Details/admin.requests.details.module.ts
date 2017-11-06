import { NgModule } from '@angular/core';
import {AdminRequestsDetailsComponent} from './admin.requests.details.component';
import {routing} from './admin.requests.details.routing';
import {CommonModule} from '@angular/common';
import {FormsModule} from '@angular/forms';

@NgModule({
  imports: [routing, CommonModule, FormsModule],
  declarations: [AdminRequestsDetailsComponent]
})
export class LazyAdminRequestsDetailsModule {}
