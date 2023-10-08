import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';
import {AppComponent} from './app.component';
import {SideNavInnerToolbarModule, SideNavOuterToolbarModule, SingleCardModule} from './layouts';
import {
  ChangePasswordFormModule,
  CreateAccountFormModule,
  FooterModule,
  LoginFormModule,
  ResetPasswordFormModule
} from './shared/components';
import {AppInfoService, AuthService, ScreenService} from './shared/services';
import {UnauthenticatedContentModule} from './unauthenticated-content';
import {AppRoutingModule} from './app-routing.module';
import {ConfigService} from './shared/services/config.service'
import {AuthCallbackComponent} from "./pages/auth-callback/auth-callback.component";
import {ModulesService} from "./pages/modules/modules.service";
import {DataService} from "./shared/services/data.service";
import {ThemeService} from './shared/services/theme.service';

@NgModule({
  declarations: [
    AppComponent,
    AuthCallbackComponent,
  ],
  imports: [
    BrowserModule,
    SideNavOuterToolbarModule,
    SideNavInnerToolbarModule,
    SingleCardModule,
    FooterModule,
    ResetPasswordFormModule,
    CreateAccountFormModule,
    ChangePasswordFormModule,
    LoginFormModule,
    UnauthenticatedContentModule,
    AppRoutingModule,
    HttpClientModule,
  ],
  providers: [
    AuthService,
    ScreenService,
    AppInfoService,
    ConfigService,
    ModulesService,
    DataService,
    ThemeService
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
