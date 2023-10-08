import {Component, Inject, ViewEncapsulation, ViewChild} from '@angular/core';
import {DxDataGridComponent} from 'devextreme-angular';
import {DataService} from '../../shared/services/data.service';
import {Title} from "@angular/platform-browser";

@Component({
  selector: 'factory-component',
  encapsulation: ViewEncapsulation.None,
  styleUrls: [
    "./factory.component.css"  ],
  templateUrl: './factory.component.html'
})
export class FactoryComponent {
  @ViewChild(DxDataGridComponent, {static: false}) grid: DxDataGridComponent | undefined;
  selectedRowData: any;
  dataSource: any;
  readonly allowedPageSizes = [50, 100, 'all'];

  constructor(@Inject('BASE_URL') public baseUrl: string, public dataService: DataService, private titleService:Title) {
    this.titleService.setTitle("Заводы");
    this.dataSource = this.dataService.getGridDataSource(`api/uom/`, 'id');
  }

  onFocusedRowChanged(e: any) {
    this.selectedRowData = e.row.data;
  }
  gridHeight(){
    return window.innerHeight -100;
  }
}
