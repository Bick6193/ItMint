import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {AdminInboxComponent} from './admin.inbox.component';

const routes: Routes = [
  { path: '', component: AdminInboxComponent}
];

export const routing: ModuleWithProviders = RouterModule.forChild(routes);
