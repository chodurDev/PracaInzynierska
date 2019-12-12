import {
  Component,
  OnInit,
  AfterViewInit,
  OnChanges,
  Input,
  ViewChild
} from '@angular/core';
import { FirstAidKitMedicine } from '../../_model/FirstAidKitMedicine';
import { MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import { FormControl } from '@angular/forms';
import { SelectionModel } from '@angular/cdk/collections';
import { FirstAidKitService } from 'src/app/_services/firstAidKit.service';

@Component({
  selector: 'app-tableCurrentlyUsed',
  templateUrl: './tableCurrentlyUsed.component.html',
  styleUrls: ['./tableCurrentlyUsed.component.css']
})
export class TableCurrentlyUsedComponent
  implements AfterViewInit, OnChanges, OnInit {
  @Input() medicines: FirstAidKitMedicine[];

  selection = new SelectionModel<FirstAidKitMedicine>(true, []);

  displayedColumns: string[] = [
    'name',
    'remainingQuantity',
    'expirationDate',
    'delete',
    'take'
  ];
  dataSource = new MatTableDataSource<FirstAidKitMedicine>(this.medicines);
  nameFilter = new FormControl('');
  filterValues = {
    name: ''
  };

  color: string = 'PillImageGreen';

  changeStyle($event) {
    this.color = $event.type == 'mouseover' ? 'PillImageWhite' : 'PillImageGreen';
  }

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(private fakService: FirstAidKitService) {
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
  AreYouSure(row: FirstAidKitMedicine) {
    if (
      confirm(`Czy na pewno chcesz usunąć ${row.name} z Aktualnie zażywanych?`)
    ) {
      row.isTaken = !row.isTaken;
      this.fakService.UpdateFirstAidKitMedicine(row).subscribe();
      this.deleteRowFromTable(row);
    }
  }

  private deleteRowFromTable(row: FirstAidKitMedicine) {
    const index = this.dataSource.data.indexOf(row);
    this.dataSource.data.splice(index, 1);
    this.dataSource._updateChangeSubscription();
  }

  IsMedicineExpired(expirationDate: string): boolean {
    const currentDate: Date = new Date();
    return currentDate > new Date(expirationDate) ? true : false;
  }
}
