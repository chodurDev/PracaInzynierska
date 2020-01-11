import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MatTableDataSource, MatPaginator, MatSort, MatDialog } from '@angular/material';
import { FormControl } from '@angular/forms';
import { UserService } from '../_services/user.service';
import { AuthService } from '../_services/auth.service';
import { Allergies } from '../_model/Allergies';
import { DialogAddMedicineToFAKComponent } from '../dialogs/dialogAddMedicineToFAK/dialogAddMedicineToFAK.component';
import { DialogAddAllergyComponent } from '../dialogs/dialogAddAllergy/dialogAddAllergy.component';

@Component({
  selector: 'app-editUser',
  templateUrl: './editUser.component.html',
  styleUrls: ['./editUser.component.css']
})
export class EditUserComponent implements AfterViewInit, OnInit {
  displayedColumns: string[] = ['name', 'delete'];
  dataSource = new MatTableDataSource<Allergies>();

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
    const actualUserId = this.authService.decodedToken.nameid;
    this.userService
      .GetUserAllergies(actualUserId)
      .subscribe((allergies: Allergies[]) => {
        this.dataSource.data = allergies;
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

  OnAddAllergies(){
  const dialogRef = this.dialog.open(DialogAddAllergyComponent, {
    width: '400px'
  });
  dialogRef.afterClosed().subscribe(result => {
    console.log(result);
  });
}

}
