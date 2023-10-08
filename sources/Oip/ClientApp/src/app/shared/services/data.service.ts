import {Inject, Injectable} from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import CustomStore from 'devextreme/data/custom_store';
import {lastValueFrom} from 'rxjs';

@Injectable()
export class DataService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    // do nothing
  }

  getGridDataSource(controllerUrl: string, key: string = 'id'): CustomStore {
    function isNotEmpty(value: any): boolean {
      return value !== undefined && value !== null && value !== '';
    }

    controllerUrl = `${this.baseUrl}${controllerUrl}`;
    return new CustomStore({
      key: key,
      load: (loadOptions: any) => {
        let params: HttpParams = new HttpParams();
        [
          'skip',
          'take',
          'requireTotalCount',
          'requireGroupCount',
          'sort',
          'filter',
          'totalSummary',
          'group',
          'groupSummary',
        ].forEach((i) => {
          if (i in loadOptions && isNotEmpty(loadOptions[i])) {
            params = params.set(i, JSON.stringify(loadOptions[i]));
          }
        });
        return lastValueFrom(this.http.get(`${controllerUrl}get-all`, {params}))
          .then((data: any) => ({
            data: data.data,
            totalCount: data.totalCount,
            summary: data.summary,
            groupCount: data.groupCount,
          }))
          .catch((error) => {
            throw new Error('Data Loading Error');
          });
      },

      insert: (values) => this.sendRequest(`${controllerUrl}insert-grid`, 'POST', {
        values: JSON.stringify(values),
      }),
      update: (key, values) => this.sendRequest(`${controllerUrl}update-grid`, 'PUT',
        {id: key, values: JSON.stringify(values),}
      ),
      remove: (key) => this.sendRequest(`${controllerUrl}delete-grid?id=${key}`, 'DELETE', {
        key,
      }),
    });
  }

  sendRequest(url: string, method = 'GET', data: any = {}): any {
    const httpParams = new HttpParams({fromObject: data});
    const httpOptions = {withCredentials: true, body: httpParams};
    let result;

    switch (method) {
      case 'GET':
        result = this.http.get(url, httpOptions);
        break;
      case 'PUT':
        result = this.http.put(url, data, httpOptions);
        break;
      case 'POST':
        result = this.http.post(url, data, httpOptions);
        break;
      case 'DELETE':
        result = this.http.delete(url, httpOptions);
        break;
    }

    if (result != undefined) {
      return lastValueFrom(result)
        .then((data: any) => {
          return data;
        })
        .catch((e) => {
          throw e && e.error && e.error.Message;
        });
    }
  }

  sendRequestBase(url: string, method = 'GET', data: any = {}): any {
    return this.sendRequest(`${this.baseUrl}${url}`, method, data);
  }
}
