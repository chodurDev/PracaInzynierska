import {
  Component,
  ViewChild,
  Input,
  AfterViewInit,
  OnChanges,
  OnInit
} from '@angular/core';
import { MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import { FirstAidKitMedicine } from '../_model/FirstAidKitMedicine';
import { SelectionModel } from '@angular/cdk/collections';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-tableForFAKMedicine',
  templateUrl: './tableForFAKMedicine.component.html',
  styleUrls: ['./tableForFAKMedicine.component.css']
})
export class TableForFAKMedicineComponent
  implements AfterViewInit, OnChanges, OnInit {
  @Input() medicines: FirstAidKitMedicine[];

  displayedColumns: string[] = [
    'name',
    'remainingQuantity',
    'expirationDate',
    'select'
  ];
  dataSource = new MatTableDataSource<FirstAidKitMedicine>(this.medicines);
  selection = new SelectionModel<FirstAidKitMedicine>(true, []);
  nameFilter = new FormControl('');
  filterValues = {
    name: ''
  };

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  /** The label for the checkbox on the passed row */
  checkboxLabel(row?: FirstAidKitMedicine): string {
    return `${
      this.selection.isSelected(row) ? 'deselect' : 'select'
    } row ${row.firstAidKitMedicineID + 1}`;
  }

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
    console.log(this.medicines);
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
