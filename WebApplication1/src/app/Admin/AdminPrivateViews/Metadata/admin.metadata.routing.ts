import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {AdminMetadataComponent} from './admin.metadata.component';

const routes: Routes = [
  { path: '', component: AdminMetadataComponent}
];

export const routing: ModuleWithProviders = RouterModule.forChild(routes);
