import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {AdminSettingsComponent} from './admin.settings.component'

const routes: Routes = [
  { path: '', component: AdminSettingsComponent}
];

export const routing: ModuleWithProviders = RouterModule.forChild(routes);
