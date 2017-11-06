import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {AppComponent} from './Home/app.component';
import { FormsModule } from '@angular/forms';
import {routing} from './app.routing';
import {AboutUsComponent} from './Home/about-us.component';
import {adminRouting} from './admin.routing';
import {AdminComponent} from './Admin/Login/admin.component';
import {MainAppComponent} from './main.app.component';
import {TemporaryAdminComponent} from './Admin/temporary.admin.component';
import {ContactsComponent} from './Contacts/contacts.component';
import {MobileApplicationDevelopmentComponent} from './Services/MobileApplicationDevelopment/mobile-application-development.component.html';
import {IndustriesComponent} from './Company/Industries/industries.component';
import {TechnologiesComponent} from './Company/Technologies/technologies.component';
import {DesignComponent} from './Services/UxUiDesign/design.component';
import {CustomSoftwareDevelopmentComponent} from './Services/CustomSoftwareDevelopment/custom-software-development.component';
import {HttpClientModule} from '@angular/common/http';
import {HttpModule} from '@angular/http';



@NgModule({
    declarations: [
        AppComponent,
        MainAppComponent,
        AboutUsComponent,
        AdminComponent,
        TemporaryAdminComponent,
        ContactsComponent,
        MobileApplicationDevelopmentComponent,
        IndustriesComponent,
        TechnologiesComponent,
        DesignComponent,
        CustomSoftwareDevelopmentComponent
    ],
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        HttpClientModule,
        routing,
        adminRouting
    ],
    providers: [],
    bootstrap: [MainAppComponent]
})
export class AppModule { }
