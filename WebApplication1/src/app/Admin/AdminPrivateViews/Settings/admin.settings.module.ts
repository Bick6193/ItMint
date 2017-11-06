import { NgModule } from '@angular/core';
import {AdminSettingsComponent} from './admin.settings.component';
import {routing} from './admin.settings.routing';
import {CommonModule} from '@angular/common';
import {FormsModule} from '@angular/forms';

@NgModule({
  imports: [routing, CommonModule, FormsModule],
  declarations: [AdminSettingsComponent]
})
export class LazyAdminSettingsModule {}
