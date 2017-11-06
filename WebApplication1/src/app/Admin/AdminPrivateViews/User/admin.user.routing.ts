import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {AdminUserComponent} from './admin.user.component';

const routes: Routes = [
  { path: '', component: AdminUserComponent}
];

export const routing: ModuleWithProviders = RouterModule.forChild(routes);
