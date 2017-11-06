import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {AdminProjectsComponent} from './admin.projects.component';

const routes: Routes = [
  { path: '', component: AdminProjectsComponent}
];

export const routing: ModuleWithProviders = RouterModule.forChild(routes);
