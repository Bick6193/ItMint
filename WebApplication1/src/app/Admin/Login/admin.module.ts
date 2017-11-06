import { NgModule } from '@angular/core';
import {AdminComponent} from './admin.component';
import {routing} from './admin.routing';
import {CommonModule} from '@angular/common';
import {FormsModule} from '@angular/forms';

@NgModule({
  imports: [routing, CommonModule, FormsModule],
  declarations: [AdminComponent]
})
export class LazyAdminModule {}
