import { NgModule } from '@angular/core';
import {AdminProjectDetailsComponent} from './admin.projects.details.component';
import {routing} from './admin.projects.details.routing';
import {CommonModule} from '@angular/common';
import {FormsModule} from '@angular/forms';

@NgModule({
  imports: [routing, CommonModule, FormsModule],
  declarations: []
})
export class LazyAdminProjectsDetailsModule {}
