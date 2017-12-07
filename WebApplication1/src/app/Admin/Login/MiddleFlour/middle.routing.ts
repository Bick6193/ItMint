import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {MiddleComponent} from './middle.component';

const routes: Routes = [
  { path: '', component: MiddleComponent}
];

export const routing: ModuleWithProviders = RouterModule.forChild(routes);
