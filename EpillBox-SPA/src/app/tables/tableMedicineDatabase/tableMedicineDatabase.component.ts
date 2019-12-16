import { Component, OnInit, Input, ViewChild, AfterViewInit, OnChanges } from '@angular/core';
import { FirstAidKitMedicine } from 'src/app/_model/FirstAidKitMedicine';
import { MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-tableMedicineDatabase',
  templateUrl: './tableMedicineDatabase.component.html',
  styleUrls: ['./tableMedicineDatabase.component.css']
})
export class TableMedicineDatabaseComponent implements OnInit,AfterViewInit,OnChanges {

  @Input() medicines: FirstAidKitMedicine[];

  displayedColumns: string[] = [
    'name',
    'remainingQuantity',
    'expirationDate'
  ];
  dataSource = new MatTableDataSource<FirstAidKitMedicine>(this.medicines);
  nameFilter = new FormControl('');
  filterValues = {
    name: ''
  };

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor() {
    this.dataSource.filterPredicate = this.createFilter();
  }
  ngOnInit() {
    this.nameFilter.valueChanges.subscribe(name => {
      this.filterValues.name = name;
      this.dataSource.filter = JSON.stringify(this.filterValues);
    });
  }

  ngOnChanges() {
    this.dataSource.data = this.medicines;
  }

  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  createFilter(): (data: any, filter: string) => boolean {
    const filterFunction = (data, filter): boolean =>{
      const searchTerms = JSON.parse(filter);
      return data.name.toLowerCase().indexOf(searchTerms.name) !== -1;
    };
    return filterFunction;
  }

}
