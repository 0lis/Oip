import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable()
export class ModulesService {
  configUrl = 'api/module/get-all'

  constructor(private http: HttpClient) {
  }

  getModules() {
    return this.http.get(this.configUrl);
  }
}
