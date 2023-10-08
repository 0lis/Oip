import {Injectable} from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot} from '@angular/router';
import {catchError} from 'rxjs/operators';
import {HttpClient} from '@angular/common/http';
import {User, UserManager, UserManagerSettings} from 'oidc-client';
import {BehaviorSubject} from 'rxjs';
import {BaseService} from "./base.service";
import {ConfigService} from './config.service';

export interface IUser {
  name: string;
  avatarUrl?: string
}

const defaultPath = '/';
const defaultUser = {
  name: 'bug',
  avatarUrl: 'https://js.devexpress.com/Demos/WidgetsGallery/JSDemos/images/employees/06.png'
};

@Injectable()
export class AuthService extends BaseService {
  private _user: IUser | null = defaultUser;
  // Observable navItem source
  private _authNavStatusSource = new BehaviorSubject<boolean>(false);
  // Observable navItem stream
  authNavStatus$ = this._authNavStatusSource.asObservable();
  private manager = new UserManager(getClientSettings());
  private user: User | null | undefined;

  constructor(private http: HttpClient, private configService: ConfigService, private router: Router) {
    super();

    this.manager.getUser().then(user => {
      this.user = user;
      this._authNavStatusSource.next(this.isAuthenticated());
    });
  }

  get loggedIn(): boolean {
    return !!this.user;
  }

  private _lastAuthenticatedPath: string = defaultPath;

  set lastAuthenticatedPath(value: string) {
    this._lastAuthenticatedPath = value;
  }

  get authorizationHeaderValue(): string {
    return `${this.user?.token_type} ${this.user?.access_token}`;
  }

  get name(): string {
    let profile = this.user?.profile;
    if (profile != undefined && profile.name != undefined)
      return profile.name;
    else
      return '';
  }

  async getUser() {
    try {
      if (this.isAuthenticated()) {
        let name: string = "";
        let url: string = "";
        let profile = this.user?.profile;
        if (this.user?.profile?.name != null)
          name = this.user?.profile?.name;
        if (this.user?.profile?.picture != null)
          url = this.user?.profile?.picture;
        return {
          isOk: true,
          data: {
            name: name,
            avatarUrl: url
          }
        }
      }
    } catch {

    }
    return {
      isOk: false,
      data: defaultUser
    };
  }

  async createAccount(email: string, password: string) {
    try {
      // Send request
      console.log(email, password);

      this.router.navigate(['/create-account']);
      return {
        isOk: true
      };
    } catch {
      return {
        isOk: false,
        message: "Failed to create account"
      };
    }
  }

  async changePassword(email: string, recoveryCode: string) {
    try {
      // Send request
      console.log(email, recoveryCode);

      return {
        isOk: true
      };
    } catch {
      return {
        isOk: false,
        message: "Failed to change password"
      }
    }
  }

  async resetPassword(email: string) {
    try {
      // Send request
      console.log(email);

      return {
        isOk: true
      };
    } catch {
      return {
        isOk: false,
        message: "Failed to reset password"
      };
    }
  }

  async logOut() {
    this._user = null;
    await this.manager.signoutRedirect();
  }

  login() {
    return this.manager.signinRedirect();
  }

  async completeAuthentication() {
    this.user = await this.manager.signinRedirectCallback();
    this._authNavStatusSource.next(this.isAuthenticated());
  }

  register(userRegistration: any) {
    return this.http.post(this.configService.authApiURI + '/account', userRegistration).pipe(catchError(this.handleError));
  }

  isAuthenticated(): boolean {
    return this.user != null && !this.user.expired;
  }

  async signout() {
    await this.manager.signoutRedirect();
  }


}

@Injectable()
export class AuthGuardService implements CanActivate {
  constructor(private router: Router, private authService: AuthService) {
  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    if (this.authService.isAuthenticated()) {
      return true;
    }
    const isLoggedIn = this.authService.loggedIn;
    const isAuthForm = [
      'login-form',
      'reset-password',
      'create-account',
      'auth-callback',
      'change-password/:recoveryCode'
    ].includes(route.routeConfig?.path || defaultPath);

    if (isLoggedIn && isAuthForm) {
      this.authService.lastAuthenticatedPath = defaultPath;
      this.router.navigate([defaultPath]);
      return false;
    }

    if (!isLoggedIn && !isAuthForm) {
      this.authService.login();
    }


    if (isLoggedIn) {
      this.authService.lastAuthenticatedPath = route.routeConfig?.path || defaultPath;
    }

    return isLoggedIn || isAuthForm;
  }
}

export function getClientSettings(): UserManagerSettings {
  return {
    authority: 'https://localhost:44310/',
    client_id: 'spa',
    redirect_uri: 'http://localhost:44418/auth-callback',
    post_logout_redirect_uri: 'http://localhost:44418/',
    response_type: "id_token token",
    scope: "openid profile email",
    filterProtocolClaims: true,
    loadUserInfo: true,
    automaticSilentRenew: true,
    silent_redirect_uri: 'http://localhost:44418/silent-refresh.html',
  };
}
