import {
  Component,
  OnInit,
  ViewChild,
  AfterViewInit,
  OnChanges
} from '@angular/core';
import {
  MatTableDataSource,
  MatPaginator,
  MatSort,
  MatDialog
} from '@angular/material';
import { FormControl } from '@angular/forms';
import { UserService } from '../_services/user.service';
import { AuthService } from '../_services/auth.service';
import { Allergies } from '../_model/Allergies';
import { DialogAddMedicineToFAKComponent } from '../dialogs/dialogAddMedicineToFAK/dialogAddMedicineToFAK.component';
import { DialogAddAllergyComponent } from '../dialogs/dialogAddAllergy/dialogAddAllergy.component';
import { User } from '../_model/User';

@Component({
  selector: 'app-editUser',
  templateUrl: './editUser.component.html',
  styleUrls: ['./editUser.component.css']
})
export class EditUserComponent implements AfterViewInit, OnInit {
  displayedColumns: string[] = ['name', 'delete'];
  dataSource = new MatTableDataSource<Allergies>();

  actualUserId: number;
  nameFilter = new FormControl('');

  filterValues = {
    name: ''
  };

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(
    private userService: UserService,
    private authService: AuthService,
    public dialog: MatDialog
  ) {
    this.dataSource.filterPredicate = this.createFilter();
  }

  ngOnInit() {
    this.GetUserAllergies();

    this.nameFilter.valueChanges.subscribe(name => {
      this.filterValues.name = name;
      this.dataSource.filter = JSON.stringify(this.filterValues);
    });
  }
  GetUserAllergies() {
    this.actualUserId = this.authService.decodedToken.nameid;
    this.userService
      .GetUserAllergies(this.actualUserId)
      .subscribe((allergies: Allergies[]) => {
        this.dataSource.data = allergies;
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

  OnAddAllergies() {
    const dialogRef = this.dialog.open(DialogAddAllergyComponent, {
      width: '400px'
    });
    dialogRef.afterClosed().subscribe((result: Allergies[]) => {
      if (result) {
        if (result.length > 0) {
          this.userService
            .AddAllergyToUserAllergies(this.actualUserId, result)
            .subscribe(null, null, () => {
              this.GetUserAllergies();
            });
        }
      }
    });
  }

  OnDeleteUserAllergy(allergy: Allergies) {
    this.userService
      .DeleteUserAllergy(allergy.allergiesID, this.actualUserId)
      .subscribe(null, null, () => {
        this.GetUserAllergies();
      });
    this.deleteRowFromTable(allergy);
  }

  private deleteRowFromTable(row: Allergies) {
    const index = this.dataSource.data.indexOf(row);
    this.dataSource.data.splice(index, 1);
    this.dataSource._updateChangeSubscription();
  }
}
