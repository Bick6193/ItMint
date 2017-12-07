import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {AppComponent} from './GetInToutchView/Home/app.component';
import {FormsModule} from '@angular/forms';
import {routing} from './app.routing';
import {AboutUsComponent} from './GetInToutchView/Home/about-us.component';
import {adminRouting} from './admin.routing';
import {AdminComponent} from './Admin/Login/admin.component';
import {MainAppComponent} from './main.app.component';
import {TemporaryAdminComponent} from './Admin/temporary.admin.component';
import {ContactsComponent} from './GetInToutchView/Contacts/contacts.component';
import {MobileApplicationDevelopmentComponent} from './GetInToutchView/Services/MobileApplicationDevelopment/mobile-application-development.component.html';
import {IndustriesComponent} from './GetInToutchView/Company/Industries/industries.component';
import {TechnologiesComponent} from './GetInToutchView/Company/Technologies/technologies.component';
import {DesignComponent} from './GetInToutchView/Services/UxUiDesign/design.component';
import {CustomSoftwareDevelopmentComponent} from './GetInToutchView/Services/CustomSoftwareDevelopment/custom-software-development.component';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import {HttpModule} from '@angular/http';
import {TokenInterceptor} from '../services/library/token.interceptor.library';
import {AuthenticateGuardService} from '../services/library/authenticate.guard.service';
import {JwtInterceptor} from '../services/library/jwt.interceptor.library';
import {RootAdminComponent} from './Admin/AdminPrivateViews/RootAdmin/root.admin.component';
import {ModalMessageComponent} from './GetInToutchView/ModalMessage/get-in-touch/modal.message.component';


@NgModule({
  declarations: [
    AppComponent,
    MainAppComponent,
    AboutUsComponent,
    ContactsComponent,
    MobileApplicationDevelopmentComponent,
    IndustriesComponent,
    TechnologiesComponent,
    DesignComponent,
    CustomSoftwareDevelopmentComponent,
    ModalMessageComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    HttpClientModule,
    routing
  ],
  providers: [
    AuthenticateGuardService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true
    }
  ],
  bootstrap: [MainAppComponent]
})
export class AppModule {
}
