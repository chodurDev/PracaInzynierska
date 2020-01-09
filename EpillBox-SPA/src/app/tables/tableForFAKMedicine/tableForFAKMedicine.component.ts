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
import { FirstAidKitMedicine } from '../../_model/FirstAidKitMedicine';
import { SelectionModel } from '@angular/cdk/collections';
import { FormControl } from '@angular/forms';
import { FirstAidKitService } from '../../_services/firstAidKit.service';

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
    this.ColumntoDisplay(this.medicines);
    this.dataSource.data = this.medicines;
  }

  ColumntoDisplay(medicines: FirstAidKitMedicine[]) {
    console.log(medicines.length);
    if (
      medicines[0].firstAidKitID === medicines[medicines.length - 1].firstAidKitID
    ) {
      this.displayedColumns = [
        'name',
        'remainingQuantity',
        'expirationDate',
        'isTaken',
        'delete',
        'info'
      ];
    } else {
      this.displayedColumns = [
        'name',
        'remainingQuantity',
        'expirationDate',
        'isTaken',
        'fakName',
        'delete',
        'info'
      ];
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
}
