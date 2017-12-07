import {AuthenticateGuardService} from '../services/library/authenticate.guard.service';
import {RouterModule, Routes} from '@angular/router';
import {ModuleWithProviders} from '@angular/core';
import {AdminComponent} from './Admin/Login/admin.component';
import {TemporaryAdminComponent} from './Admin/temporary.admin.component';

const adminRoutes: Routes = [
  {
    path: 'Admins',
    component: TemporaryAdminComponent,
    canActivate: [AuthenticateGuardService],
    children: [
      {
        path: 'Inbox',
        loadChildren: './Admin/AdminPrivateViews/Inbox/admin.inbox.module#LazyAdminInboxModule'
      },
      {
        path: 'Metadata',
        loadChildren: './Admin/AdminPrivateViews/Metadata/admin.metadata.module#LazyAdminMetadataModule'
      },
      {
        path: 'Projects',
        loadChildren: './Admin/AdminPrivateViews/Projects/admin.projects.module#LazyAdminProjectsModule'
      },
      {
        path: 'Projects-Details',
        loadChildren: './Admin/AdminPrivateViews/Projects-Details/admin.projects.details.module#LazyAdminProjectsDetailsModule'
      },
      {
        path: 'Metadata-Details',
        loadChildren: './Admin/AdminPrivateViews/Metadata-Details/admin.metadata.details.module#LazyAdminMetadataDetailsModule'
      },
      {
        path: 'Settings',
        loadChildren: './Admin/AdminPrivateViews/Settings/admin.settings.module#LazyAdminSettingsModule'
      },
      {
        path: 'AddUser',
        loadChildren: './Admin/AdminPrivateViews/User/admin.user.module#LazyAdminUserModule'
      },
      {
        path: 'Requests',
        loadChildren: './Admin/AdminPrivateViews/Requests/admin.requests.module#LazyAdminRequestsModule',

      },
      {
        path: 'Requests-Details/:id',
        loadChildren: './Admin/AdminPrivateViews/Requests-Details/admin.requests.details.module#LazyAdminRequestsDetailsModule'
      }

    ]
  }
];
export const adminRouting: ModuleWithProviders = RouterModule.forRoot(adminRoutes);
