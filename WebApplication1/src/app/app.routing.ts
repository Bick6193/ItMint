import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {AboutUsComponent} from './Home/about-us.component';
import {AppComponent} from './Home/app.component';
import {ContactsComponent} from './Contacts/contacts.component';
import {CustomSoftwareDevelopmentComponent} from './Services/CustomSoftwareDevelopment/custom-software-development.component';
import {IndustriesComponent} from './Company/Industries/industries.component';
import {MobileApplicationDevelopmentComponent} from './Services/MobileApplicationDevelopment/mobile-application-development.component.html';
import {TechnologiesComponent} from './Company/Technologies/technologies.component';
import {DesignComponent} from './Services/UxUiDesign/design.component';
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
    }
  ]
  }
  ];

export const routing: ModuleWithProviders = RouterModule.forRoot(routes);
