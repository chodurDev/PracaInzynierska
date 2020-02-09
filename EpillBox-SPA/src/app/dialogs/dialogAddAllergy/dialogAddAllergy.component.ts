import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import {
  MatTableDataSource,
  MatPaginator,
  MatSort,
  MatDialogRef
} from '@angular/material';
import { SelectionModel } from '@angular/cdk/collections';
import { Allergies } from 'src/app/_model/Allergies';
import { MedicineService } from 'src/app/_services/medicine.service';
import { ActiveSubstance } from 'src/app/_model/ActiveSubstance';

@Component({
  selector: 'app-dialogAddAllergy',
  templateUrl: './dialogAddAllergy.component.html',
  styleUrls: ['./dialogAddAllergy.component.css']
})
export class DialogAddAllergyComponent implements AfterViewInit, OnInit {
  displayedColumns: string[] = ['name', 'select'];
  dataSource = new MatTableDataSource<ActiveSubstance>();

  nameFilter = new FormControl('');
  selection = new SelectionModel<ActiveSubstance>(true, []);

  filterValues = {
    name: ''
  };

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(
    public dialogRef: MatDialogRef<DialogAddAllergyComponent>,
    private medService: MedicineService
  ) {
    this.dataSource.filterPredicate = this.createFilter();
  }

  ngOnInit() {
    this.medService.GetAllAllergies().subscribe((allergies: ActiveSubstance[]) => {
      this.dataSource.data = allergies;
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

  onAddClick(): ActiveSubstance[]{
    return this.selection.selected;
  }
}
