import {
  Component,
  OnInit,
  Inject,
  ViewChild,
  AfterViewInit
} from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { UserFirstAidKit } from 'src/app/_model/UserFirstAidKit';
import { MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import { SelectionModel } from '@angular/cdk/collections';
import { FormControl } from '@angular/forms';
import { MedicineService } from 'src/app/_services/medicine.service';
import { Medicine } from 'src/app/_model/Medicine';
import { FirstAidKitMedicine } from 'src/app/_model/FirstAidKitMedicine';

@Component({
  selector: 'app-dialogAddMedicineToFAK',
  templateUrl: './dialogAddMedicineToFAK.component.html',
  styleUrls: ['./dialogAddMedicineToFAK.component.css']
})
export class DialogAddMedicineToFAKComponent implements AfterViewInit, OnInit {
  chosenDate: Date | null = null;
  displayedColumns: string[] = ['name', 'quantityInPackage', 'select'];
  dataSource = new MatTableDataSource<Medicine>();

  selection = new SelectionModel<Medicine>(false, []);

  nameFilter = new FormControl('');

  filterValues = {
    name: ''
  };

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(
    public dialogRef: MatDialogRef<DialogAddMedicineToFAKComponent>,
    @Inject(MAT_DIALOG_DATA) public data: UserFirstAidKit[],
    private medService: MedicineService
  ) {
    this.dataSource.filterPredicate = this.createFilter();
  }

  ngOnInit() {
    this.medService.GetAllMedicines().subscribe((medicines: Medicine[]) => {
      this.dataSource.data = medicines;
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
  onAddClick(): FirstAidKitMedicine {
    if (this.selection.selected.length > 0) {
      const chosenMedicine: FirstAidKitMedicine = {
        medicineID: this.selection.selected[0].medicineID,
        name: this.selection.selected[0].name,
        remainingQuantity: this.selection.selected[0].quantityInPackage,
        expirationDate: this.chosenDate
      };
      return chosenMedicine;
    }
    return null;
  }
}
