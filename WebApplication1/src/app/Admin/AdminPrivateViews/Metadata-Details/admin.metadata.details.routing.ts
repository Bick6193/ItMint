import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {AdminMetadataDetailsComponent} from './admin.metadata.details.component';

const routes: Routes = [
  { path: '', component: AdminMetadataDetailsComponent}
];

export const routing: ModuleWithProviders = RouterModule.forChild(routes);
