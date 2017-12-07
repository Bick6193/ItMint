import {ModuleWithProviders} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';

import {AdminComponent} from './admin.component';
import {AdminInboxComponent} from '../AdminPrivateViews/Inbox/admin.inbox.component';
import {TemporaryAdminComponent} from '../temporary.admin.component';
import {AdminRequestsDetailsComponent} from '../AdminPrivateViews/Requests-Details/admin.requests.details.component';
import {AdminMetadataComponent} from '../AdminPrivateViews/Metadata/admin.metadata.component';
import {AdminProjectsComponent} from '../AdminPrivateViews/Projects/admin.projects.component';
import {AdminProjectDetailsComponent} from '../AdminPrivateViews/Projects-Details/admin.projects.details.component';
import {AdminMetadataDetailsComponent} from '../AdminPrivateViews/Metadata-Details/admin.metadata.details.component';
import {AdminSettingsComponent} from '../AdminPrivateViews/Settings/admin.settings.component';
import {AdminUserComponent} from '../AdminPrivateViews/User/admin.user.component';
import {AdminRequestsComponent} from '../AdminPrivateViews/Requests/admin.requests.component';
import {AuthenticateGuardService} from '../../../services/library/authenticate.guard.service';
import {RootAdminComponent} from '../AdminPrivateViews/RootAdmin/root.admin.component';

const routes: Routes = [
  {
    path: '',
    component: TemporaryAdminComponent,
    children: [
      {
        path: '',
        component: AdminComponent
      },
      {
        path: 'Inbox',
        component: AdminInboxComponent,
        canActivate: [AuthenticateGuardService]
      },
      {
        path: 'Metadata',
        component: AdminMetadataComponent,
        canActivate: [AuthenticateGuardService]
      },
      {
        path: 'Metadata-Details',
        component: AdminMetadataDetailsComponent,
        canActivate: [AuthenticateGuardService]
      },
      {
        path: 'Request-Details/:id',
        component: AdminRequestsDetailsComponent,
        canActivate: [AuthenticateGuardService]
      },
      {
        path: 'Projects',
        component: AdminProjectsComponent,
        canActivate: [AuthenticateGuardService]
      },
      {
        path: 'Projects-Details',
        component: AdminProjectDetailsComponent,
        canActivate: [AuthenticateGuardService]
      },
      {
        path: 'Settings',
        component: AdminSettingsComponent,
        canActivate: [AuthenticateGuardService]
      },
      {
        path: 'AddUser',
        component: AdminUserComponent,
        canActivate: [AuthenticateGuardService]
      },
      {
        path: 'AddUser/:id',
        component: AdminUserComponent,
        canActivate: [AuthenticateGuardService]
      },
      {
        path: 'Requests',
        component: AdminRequestsComponent,
        canActivate: [AuthenticateGuardService]
      }
    ]
  }];


export const routing: ModuleWithProviders = RouterModule.forChild(routes);
