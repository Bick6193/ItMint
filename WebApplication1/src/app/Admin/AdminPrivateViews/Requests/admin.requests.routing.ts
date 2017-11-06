import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {AdminRequestsComponent} from './admin.requests.component';

const routes: Routes = [
  { path: '', component: AdminRequestsComponent}
];

export const routing: ModuleWithProviders = RouterModule.forChild(routes);
