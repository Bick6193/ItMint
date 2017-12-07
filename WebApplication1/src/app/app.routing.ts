import {ModuleWithProviders} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {AboutUsComponent} from './GetInToutchView/Home/about-us.component';
import {AppComponent} from './GetInToutchView/Home/app.component';
import {ContactsComponent} from './GetInToutchView/Contacts/contacts.component';
import {CustomSoftwareDevelopmentComponent} from './GetInToutchView/Services/CustomSoftwareDevelopment/custom-software-development.component';
import {IndustriesComponent} from './GetInToutchView/Company/Industries/industries.component';
import {MobileApplicationDevelopmentComponent} from './GetInToutchView/Services/MobileApplicationDevelopment/mobile-application-development.component.html';
import {TechnologiesComponent} from './GetInToutchView/Company/Technologies/technologies.component';
import {DesignComponent} from './GetInToutchView/Services/UxUiDesign/design.component';

const routes: Routes = [
  {
    path: '',
    component: AppComponent,
    children: [
      {
        path: '',
        component: AboutUsComponent
      },
      {
        path: 'Contacts',
        component: ContactsComponent
      },
      {
        path: 'CustomSoftwareDevelopment',
        component: CustomSoftwareDevelopmentComponent
      },
      {
        path: 'Industries',
        component: IndustriesComponent
      },
      {
        path: 'MobileApplicationDevelopment',
        component: MobileApplicationDevelopmentComponent
      },
      {
        path: 'Technologies',
        component: TechnologiesComponent
      },
      {
        path: 'UxUiDesign',
        component: DesignComponent
      },
    ]
  },
  {
    path: 'Admin',
    loadChildren: './Admin/Login/admin.module#LazyAdminModule'
  },
  {
    path: 'Reset/:id',
    loadChildren: './Admin/Login/MiddleFlour/middle.module#LazyMiddleModule'
  },
  {
    path: '**',
    redirectTo: ''
  }

];

export const routing: ModuleWithProviders = RouterModule.forRoot(routes, {useHash: false});
