import {
  Component,
  ViewChild,
  Input,
  AfterViewInit,
  OnChanges,
  OnInit,
  Output,
  EventEmitter
} from '@angular/core';
import { MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import { FirstAidKitMedicine } from '../_model/FirstAidKitMedicine';
import { SelectionModel } from '@angular/cdk/collections';
import { FormControl } from '@angular/forms';
import { FirstAidKitService } from '../_services/firstAidKit.service';
import { Router } from '@angular/router';

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
    'isTaken',
    'delete'
  ];
  dataSource = new MatTableDataSource<FirstAidKitMedicine>(this.medicines);
  selection = new SelectionModel<FirstAidKitMedicine>(true, []);
  nameFilter = new FormControl('');
  filterValues = {
    name: ''
  };
  checked = false;
  routePath = ['/myFirstAidKit'];

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(private fakService: FirstAidKitService, private router: Router) {
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
    const filterFunction = (data, filter): boolean => {
      const searchTerms = JSON.parse(filter);
      return data.name.toLowerCase().indexOf(searchTerms.name) !== -1;
    };
    return filterFunction;
  }

  IsClicked(row: FirstAidKitMedicine) {
    row.isTaken = !row.isTaken;
    this.fakService.UpdateFirstAidKitMedicine(row);
  }
  AreYouSure(row: FirstAidKitMedicine) {
    if (
      confirm(`Czy na pewno chcesz usunąć ${row.name} ze swojej apteczki ?`)
    ) {
      this.fakService.DeleteFAKMedicine(row.firstAidKitMedicineID);
      this.deleteRowFromTable(row);
    }
  }

  private deleteRowFromTable(row: FirstAidKitMedicine) {
    const index = this.dataSource.data.indexOf(row);
    this.dataSource.data.splice(index, 1);
    this.dataSource._updateChangeSubscription();
  }
}
