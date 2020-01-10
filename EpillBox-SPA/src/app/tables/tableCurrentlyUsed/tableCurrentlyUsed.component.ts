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
import { MedicineService } from 'src/app/_services/medicine.service';
import { AuthService } from 'src/app/_services/auth.service';
import { AlertifyService } from 'src/app/_services/alertify.service';

@Component({
  selector: 'app-tableCurrentlyUsed',
  templateUrl: './tableCurrentlyUsed.component.html',
  styleUrls: ['./tableCurrentlyUsed.component.css']
})
export class TableCurrentlyUsedComponent
  implements AfterViewInit, OnChanges, OnInit {
  @Input() medicines: FirstAidKitMedicine[];
  actualUserId: number;
  selection = new SelectionModel<FirstAidKitMedicine>(true, []);

  displayedColumns: string[] = [
    'name',
    'remainingQuantity',
    'expirationDate',
    'buttons'
  ];
  dataSource = new MatTableDataSource<FirstAidKitMedicine>(this.medicines);
  nameFilter = new FormControl('');
  filterValues = {
    name: ''
  };

  color: string = 'PillImageGreen';

  changeStyle($event) {
    this.color =
      $event.type == 'mouseover' ? 'PillImageWhite' : 'PillImageGreen';
  }

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(
    private fakService: FirstAidKitService,
    private medService: MedicineService,
    private authService: AuthService,
    private alertify: AlertifyService
  ) {
    this.dataSource.filterPredicate = this.createFilter();
  }
  ngOnInit() {
    this.actualUserId = this.authService.decodedToken.nameid;
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
      this.updateRow(row);
      this.deleteRowFromTable(row);
    }
  }

  takeMedicine(row: FirstAidKitMedicine) {
    if (row.remainingQuantity > 0) {
      if (confirm(`Czy na pewno chcesz zażyć ${row.name}?`)) {
        if (row.remainingQuantity === 1) {
          if (
            confirm(
              `Została ci ostatnia porcja ${row.name}.\nCzy chcesz zamówić następne opakowanie?`
            )
          ) {
            this.medService
              .AddMedicineToShoppingBasket(this.actualUserId, row.medicineID)
              .subscribe(null, null, () => {
                this.alertify.message('Lek został dodany do zamówienia');
              });
          }
        }
        row.remainingQuantity -= 1;
        this.updateRow(row);
      }
    }
  }

  private updateRow(row) {
    this.fakService.UpdateFirstAidKitMedicine(row).subscribe();
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
