import { Component, ViewChild, Input, AfterViewInit, OnChanges } from '@angular/core';
import { MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import { Medicine } from '../_model/Medicine';

@Component({
  selector: 'app-tableForMedicine',
  templateUrl: './tableForMedicine.component.html',
  styleUrls: ['./tableForMedicine.component.css']
})
export class TableForMedicineComponent implements AfterViewInit,OnChanges {
  @Input() medicines: Medicine[];

  displayedColumns: string[] = ['name'];
  dataSource = new MatTableDataSource<Medicine>();

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor() {}


  
  ngOnChanges() {
    console.log(this.medicines);
    this.dataSource.data = this.medicines;
  }

  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLocaleLowerCase();
  }
}
