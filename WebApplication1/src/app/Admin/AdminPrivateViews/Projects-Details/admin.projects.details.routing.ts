import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {AdminProjectDetailsComponent} from './admin.projects.details.component'

const routes: Routes = [
  { path: '', component: AdminProjectDetailsComponent}
];

export const routing: ModuleWithProviders = RouterModule.forChild(routes);
