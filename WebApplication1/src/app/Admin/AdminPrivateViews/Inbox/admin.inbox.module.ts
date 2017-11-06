import { NgModule } from '@angular/core';
import {AdminInboxComponent} from './admin.inbox.component';
import {routing} from './admin.inbox.routing';
import {CommonModule} from '@angular/common';
import {FormsModule} from '@angular/forms';

@NgModule({
  imports: [routing, CommonModule, FormsModule],
  declarations: [AdminInboxComponent]
})
export class LazyAdminInboxModule {}
