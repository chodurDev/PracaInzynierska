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
import { MedicineService } from 'src/app/_services/medicine.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-tableMedicineToBuy',
  templateUrl: './tableMedicineToBuy.component.html',
  styleUrls: ['./tableMedicineToBuy.component.css']
})
export class TableMedicineToBuyComponent
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
    private authService: AuthService
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

  OnSendShoppingList() {
    console.log('eloelo');
    const actualUserId = this.authService.decodedToken.nameid;
    this.medService.SendShoppingList(actualUserId).subscribe();
  }
}
