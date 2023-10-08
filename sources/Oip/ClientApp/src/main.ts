import themes from 'devextreme/ui/themes';
import {enableProdMode} from '@angular/core';
import {platformBrowserDynamic} from '@angular/platform-browser-dynamic';

import {AppModule} from './app/app.module';
import {environment} from './environments/environment';

if (environment.production) {
  enableProdMode();
}

export function getBaseUrl() {
  return document.getElementsByTagName('base')[0].href;
}

export function getAuthSettings() {
  return false;
}

const providers = [
  { provide: 'BASE_URL', useFactory: getBaseUrl, deps: [] },
  { provide: 'AUTH_ENABLE', useFactory: getAuthSettings, deps: [] }
];

themes.initialized(() => {
  platformBrowserDynamic(providers).bootstrapModule(AppModule)
    .catch(err => console.error(err));
});
