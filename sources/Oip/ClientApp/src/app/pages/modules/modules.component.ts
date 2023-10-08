import {Component, OnInit} from '@angular/core';
import {ModulesService} from './modules.service';

@Component({
  templateUrl: 'modules.component.html'
})

export class ModulesComponent implements OnInit {
  dataSource: any;
  priority: any[] = []

  constructor(private modulesService: ModulesService) {
  }

  ngOnInit(): void {
    this.modulesService.getModules().subscribe(
      (data) => {
        this.dataSource = data;
      }
    );
  }
}
