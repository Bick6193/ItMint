import {NgModule} from '@angular/core';
import {AdminComponent} from './admin.component';
import {routing} from './admin.routing';
import {CommonModule} from '@angular/common';
import {FormsModule} from '@angular/forms';
import {AdminInboxComponent} from '../AdminPrivateViews/Inbox/admin.inbox.component';
import {TemporaryAdminComponent} from '../temporary.admin.component';
import {AdminRequestsDetailsComponent} from '../AdminPrivateViews/Requests-Details/admin.requests.details.component';
import {AdminMetadataComponent} from '../AdminPrivateViews/Metadata/admin.metadata.component';
import {AdminRequestsComponent} from '../AdminPrivateViews/Requests/admin.requests.component';
import {AdminUserComponent} from '../AdminPrivateViews/User/admin.user.component';
import {AdminSettingsComponent} from '../AdminPrivateViews/Settings/admin.settings.component';
import {AdminMetadataDetailsComponent} from '../AdminPrivateViews/Metadata-Details/admin.metadata.details.component';
import {AdminProjectsComponent} from '../AdminPrivateViews/Projects/admin.projects.component';
import {AdminProjectDetailsComponent} from '../AdminPrivateViews/Projects-Details/admin.projects.details.component';
import {TokenInterceptor} from '../../../services/library/token.interceptor.library';
import {HTTP_INTERCEPTORS} from '@angular/common/http';
import {RootAdminComponent} from '../AdminPrivateViews/RootAdmin/root.admin.component';

@NgModule({
  imports: [routing, CommonModule, FormsModule],
  declarations: [
    RootAdminComponent,
    AdminComponent,
    AdminInboxComponent,
    TemporaryAdminComponent,
    AdminRequestsDetailsComponent,
    AdminMetadataComponent,
    AdminRequestsComponent,
    AdminUserComponent,
    AdminSettingsComponent,
    AdminMetadataDetailsComponent,
    AdminProjectsComponent,
    AdminProjectDetailsComponent
  ]
})
export class LazyAdminModule {
}
