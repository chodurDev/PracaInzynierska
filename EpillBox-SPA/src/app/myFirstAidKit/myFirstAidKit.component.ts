import { Component, OnInit, ViewChild, AfterViewInit} from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { FirstAidKitService } from '../_services/firstAidKit.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource, MatTable } from '@angular/material/table';
import { MatSort } from '@angular/material';

@Component({
  selector: 'app-myFirstAidKit',
  templateUrl: './myFirstAidKit.component.html',
  styleUrls: ['./myFirstAidKit.component.css']
})
export class MyFirstAidKitComponent implements OnInit,AfterViewInit {
  displayedColumns: string[] = ['name'];
  dataSource = new MatTableDataSource<Medicine>();

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  // @ViewChild('table', { static: true }) table: MatTable<any>;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(
    private fakService: FirstAidKitService,
    private authService: AuthService
  ) {}

  ngOnInit() {
    this.getUserMedicines();
  }

  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  getUserMedicines() {
    const actualUserId = this.authService.decodedToken.nameid;

    this.fakService.GetuserMedicines(actualUserId).subscribe(
      (values: Medicine[]) => {
        console.log(values);
        this.dataSource.data = values;
        
      });
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLocaleLowerCase();
    // this.table.renderRows();
  }
}

export interface Medicine {
  medicineID: number;
  name: string;
  firstAidKitMedicines?: any;
}
