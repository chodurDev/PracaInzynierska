import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { FirstAidKitService } from '../_services/firstAidKit.service';
import { AuthService } from '../_services/auth.service';
import { FirstAidKitMedicine } from '../_model/FirstAidKitMedicine';
import { MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-medicinesUserCantTake',
  templateUrl: './medicinesUserCantTake.component.html',
  styleUrls: ['./medicinesUserCantTake.component.css']
})
export class MedicinesUserCantTakeComponent implements OnInit, AfterViewInit {
  medicines: FirstAidKitMedicine[] = [];

  displayedColumns: string[] = [
    'name',
    'producer',
    'quantityInPackage',
    'form',
    'activeSubstance'
  ];
  dataSource = new MatTableDataSource<FirstAidKitMedicine>(this.medicines);
  nameFilter = new FormControl('');
  filterValues = {
    name: ''
  };

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(
    private fakService: FirstAidKitService,
    private authService: AuthService
  ) {
    this.dataSource.filterPredicate = this.createFilter();
  }
  ngOnInit() {
    const actualUserId = this.authService.decodedToken.nameid;
    this.fakService
      .GetMedicinesUserCantTake(actualUserId)
      .subscribe((result: FirstAidKitMedicine[]) => {
        this.dataSource.data = result;
      });

    this.nameFilter.valueChanges.subscribe(name => {
      this.filterValues.name = name;
      this.dataSource.filter = JSON.stringify(this.filterValues);
    });
  }

  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  createFilter(): (data: any, filter: string) => boolean {
    const filterFunction = (data, filter): boolean => {
      const searchTerms = JSON.parse(filter);
      return data.name.toLowerCase().indexOf(searchTerms.name) !== -1;
    };
    return filterFunction;
  }
}
