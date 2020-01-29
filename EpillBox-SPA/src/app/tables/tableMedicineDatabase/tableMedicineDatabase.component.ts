import {
  Component,
  OnInit,
  Input,
  ViewChild,
  AfterViewInit,
  OnChanges
} from '@angular/core';
import { FirstAidKitMedicine } from 'src/app/_model/FirstAidKitMedicine';
import {
  MatTableDataSource,
  MatPaginator,
  MatSort,
  MatDialog
} from '@angular/material';
import { FormControl } from '@angular/forms';
import { DialogAddMedicineToDatabaseComponent } from 'src/app/dialogs/dialogAddMedicineToDatabase/dialogAddMedicineToDatabase.component';
import { MedicineToAdd } from 'src/app/_model/MedicineToAdd';
import { MedicineService } from 'src/app/_services/medicine.service';
import { AlertifyService } from 'src/app/_services/alertify.service';

@Component({
  selector: 'app-tableMedicineDatabase',
  templateUrl: './tableMedicineDatabase.component.html',
  styleUrls: ['./tableMedicineDatabase.component.css']
})
export class TableMedicineDatabaseComponent
  implements OnInit, AfterViewInit, OnChanges {
  @Input() medicines: FirstAidKitMedicine[];

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
    public dialog: MatDialog,
    private medService: MedicineService,
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

  OnAddMedicineToDatabase() {
    const dialogRef = this.dialog.open(DialogAddMedicineToDatabaseComponent, {
      width: '400px'
    });
    dialogRef.afterClosed().subscribe((result: MedicineToAdd) => {
      if (result) {
        this.medService.AddMedicineToDatabase(result).subscribe(
          null,
          error => {
            this.alertify.error(error);
          },
          () => {
            this.alertify.success('Lek Dodano');
          }
        );
      }
    });
  }
}
