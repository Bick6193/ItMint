import { NgModule } from '@angular/core';
import {AdminUserComponent} from './admin.user.component';
import {routing} from './admin.user.routing';
import {CommonModule} from '@angular/common';
import {FormsModule} from '@angular/forms';

@NgModule({
  imports: [routing, CommonModule, FormsModule],
  declarations: [AdminUserComponent]
})
export class LazyAdminUserModule {}
