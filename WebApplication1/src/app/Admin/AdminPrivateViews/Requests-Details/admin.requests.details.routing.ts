import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {AdminRequestsDetailsComponent} from './admin.requests.details.component';

const routes: Routes = [
  { path: '', component: AdminRequestsDetailsComponent}
];

export const routing: ModuleWithProviders = RouterModule.forChild(routes);
