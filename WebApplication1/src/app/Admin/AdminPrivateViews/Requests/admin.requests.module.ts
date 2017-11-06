import { NgModule } from '@angular/core';
import {AdminRequestsComponent} from './admin.requests.component';
import {routing} from './admin.requests.routing';
import {CommonModule} from '@angular/common';
import {FormsModule} from '@angular/forms';

@NgModule({
  imports: [routing, CommonModule, FormsModule],
  declarations: [AdminRequestsComponent]
})
export class LazyAdminRequestsModule {}
