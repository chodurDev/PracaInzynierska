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
import {
  MatTableDataSource,
  MatPaginator,
  MatSort,
  MatDialog
} from '@angular/material';
import { FirstAidKitMedicine } from '../../_model/FirstAidKitMedicine';
import { SelectionModel } from '@angular/cdk/collections';
import { FormControl } from '@angular/forms';
import { FirstAidKitService } from '../../_services/firstAidKit.service';
import { DialogSetScheduleComponent } from 'src/app/dialogs/dialogSetSchedule/dialogSetSchedule.component';
import { ScheduleSetting } from 'src/app/_model/scheduleSetting';
import { DATE } from 'ngx-bootstrap/chronos/units/constants';
import { error } from 'protractor';
import { AlertifyService } from 'src/app/_services/alertify.service';

const TOOLTIP_PANEL_CLASS = 'expiredMedicineTooltip';

@Component({
  selector: 'app-tableForFAKMedicine',
  templateUrl: './tableForFAKMedicine.component.html',
  styleUrls: ['./tableForFAKMedicine.component.css']
})
export class TableForFAKMedicineComponent
  implements AfterViewInit, OnChanges, OnInit {
  @Input() medicines: FirstAidKitMedicine[];
  @Output() addMedicines = new EventEmitter();

  displayedColumns: string[] = [];
  dataSource = new MatTableDataSource<FirstAidKitMedicine>(this.medicines);
  selection = new SelectionModel<FirstAidKitMedicine>(true, []);
  nameFilter = new FormControl('');
  filterValues = {
    name: ''
  };
  checked = false;

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(
    private fakService: FirstAidKitService,
    public dialog: MatDialog,
    private alertify: AlertifyService
  ) {
    this.dataSource.filterPredicate = this.createFilter();
  }
  ngOnInit() {
    this.nameFilter.valueChanges.subscribe(name => {
      this.filterValues.name = name;
      this.dataSource.filter = JSON.stringify(this.filterValues);
    });
  }

  ngOnChanges() {
    this.ColumntoDisplay(this.medicines);
    this.dataSource.data = this.medicines;
  }

  ColumntoDisplay(medicines: FirstAidKitMedicine[]) {
    if (medicines.length) {
      if (
        medicines[0].firstAidKitID ===
        medicines[medicines.length - 1].firstAidKitID
      ) {
        this.displayedColumns = [
          'name',
          'remainingQuantity',
          'expirationDate',
          'isTaken',
          'buttons'
        ];
      } else {
        this.displayedColumns = [
          'name',
          'remainingQuantity',
          'expirationDate',
          'isTaken',
          'fakName',
          'buttons'
        ];
      }
    }
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
    this.fakService.UpdateFirstAidKitMedicine(row).subscribe();
  }
  AreYouSure(row: FirstAidKitMedicine) {
    if (
      confirm(`Czy na pewno chcesz usunąć ${row.name} ze swojej apteczki ?`)
    ) {
      this.fakService.DeleteFAKMedicine(row.firstAidKitMedicineID).subscribe();
      this.deleteRowFromTable(row);
    }
  }

  private deleteRowFromTable(row: FirstAidKitMedicine) {
    const index = this.dataSource.data.indexOf(row);
    this.dataSource.data.splice(index, 1);
    this.dataSource._updateChangeSubscription();
  }

  OnAddMedicinesToFAK() {
    this.addMedicines.emit();
  }

  IsMedicineExpired(expirationDate: string | null): boolean {
    const currentDate: Date = new Date();
    if (expirationDate === null) {
      return false;
    } else {
      return currentDate > new Date(expirationDate) ? true : false;
    }
  }

  medicineDescription(row: FirstAidKitMedicine): string {
    const activeSubstance: string[] = [];
    if (row.activeSubstance.length === 0) {
      activeSubstance.push('brak substancji aktywnych');
    } else {
      row.activeSubstance.forEach(x => activeSubstance.push(x));
    }

    const returnText =
      '<span class="medicineDetails">Producent: </span>' +
      row.producer +
      '<br>' +
      '<span class="medicineDetails">Substancje aktywne: </span><br>' +
      activeSubstance;

    return returnText;
  }

  SetSchedule(row: FirstAidKitMedicine) {
    console.log('ustawiam harmonogram dla ' + row.name);
    const dialogRef = this.dialog.open(DialogSetScheduleComponent, {
      width: '400px',
      data: row
    });

    dialogRef.afterClosed().subscribe((result: ScheduleSetting) => {
      if (result) {
        const temp = result.firstServingAt.toString().split(':');
        row.firstServingAt = new Date(
          1,
          1,
          1,
          +temp[0],
          +temp[1]
        ).toLocaleString();
        row.numberOfServings = result.numberOfServings;
        row.servingSize = result.servingSize;
        this.fakService.SetSchedule(row).subscribe(
          null,
          error => {
            this.alertify.error(error);
          },
          () => {
            this.alertify.success('harmonogram ustawiony');
          }
        );
      }
    });
  }
}
