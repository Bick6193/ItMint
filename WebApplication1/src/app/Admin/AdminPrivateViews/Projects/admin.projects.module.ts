import { NgModule } from '@angular/core';
import {AdminProjectsComponent} from './admin.projects.component'
import {routing} from './admin.projects.routing';
import {CommonModule} from '@angular/common';
import {FormsModule} from '@angular/forms';

@NgModule({
  imports: [routing, CommonModule, FormsModule],
  declarations: []
})
export class LazyAdminProjectsModule {}
