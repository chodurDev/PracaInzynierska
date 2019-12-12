import { Component, OnInit, AfterViewInit, OnChanges, Input, ViewChild } from '@angular/core';
import { FirstAidKitMedicine } from '../../_model/FirstAidKitMedicine';
import { MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-tableForMedicine',
  templateUrl: './tableForMedicine.component.html',
  styleUrls: ['./tableForMedicine.component.css']
})
export class TableForMedicineComponent implements AfterViewInit, OnChanges, OnInit {
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

  IsMedicineExpired(expirationDate: string): boolean {
    const currentDate: Date = new Date();
    return currentDate > new Date(expirationDate) ? true : false;
  }
}