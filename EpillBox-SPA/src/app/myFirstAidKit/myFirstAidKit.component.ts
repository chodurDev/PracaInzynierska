import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { FirstAidKitService } from '../_services/firstAidKit.service';
import { FirstAidKitMedicine } from '../_model/FirstAidKitMedicine';
import { MatDialog } from '@angular/material/dialog';
import { DialogAddUserFAKComponent } from '../dialogs/dialogAddUserFAK/dialogAddUserFAK.component';
import { UserFirstAidKit } from '../_model/UserFirstAidKit';
import { DialogDeleteUserFAKComponent } from '../dialogs/dialogDeleteUserFAK/dialogDeleteUserFAK.component';

@Component({
  selector: 'app-myFirstAidKit',
  templateUrl: './myFirstAidKit.component.html',
  styleUrls: ['./myFirstAidKit.component.css']
})
export class MyFirstAidKitComponent implements OnInit {
  medicines: FirstAidKitMedicine[] = [];
  defaultOption = '';
  firstAidKits: UserFirstAidKit[] = [];
  isChosen = false;
  actualUserId: number;

  constructor(
    private fakService: FirstAidKitService,
    private authService: AuthService,
    public dialog: MatDialog
  ) {}

  ngOnInit() {
    this.getUserFirstAidKits();
    if (localStorage.getItem('chosenFAK')) {
      this.defaultOption = localStorage.getItem('chosenFAK');
      if (parseInt(this.defaultOption) === -1) {
        this.getUserMedicines();
      } else {
        // tslint:disable-next-line: radix
        this.onFirstAidKitClick(parseInt(this.defaultOption));
      }
    }
  }

  getUserFirstAidKits() {
    this.actualUserId = this.authService.decodedToken.nameid;

    this.fakService.GetUserFirstAidKits(this.actualUserId).subscribe(values => {
      this.firstAidKits = values;
    });
  }

  getUserMedicines() {
    this.fakService
      .GetuserMedicines(this.actualUserId)
      .subscribe((values: FirstAidKitMedicine[]) => {
        this.medicines = values.slice(0);
        this.isChosen = true;
      });
  }

  onFirstAidKitClick(id: number) {
    if (id === 0) {
      this.isChosen = false;
    }
    localStorage.setItem('chosenFAK', id.toString());
    if (id === -1) {
      this.getUserMedicines();
    } else {
      this.getUserChosenFirstAidKitMedicines(id);
    }
  }

  getUserChosenFirstAidKitMedicines(id: number) {
    this.fakService
      .GetUserChosenFirstAidKitMedicines(id)
      .subscribe((values: FirstAidKitMedicine[]) => {
        console.log(values);

        this.medicines = values.slice(0);
        this.isChosen = true;
      });
  }

  addUFAK(): void {
    const dialogRef = this.dialog.open(DialogAddUserFAKComponent, {
      width: '250px'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        const uFAK: UserFirstAidKit = {
          firstAidKitID: 0,
          userID: this.actualUserId,
          name: result
        };
        this.fakService.AddUFAK(uFAK).subscribe(() => {
          this.getUserFirstAidKits();
        });
      }
    });
    
  }
  deleteUFAK(): void {
    const dialogRef = this.dialog.open(DialogDeleteUserFAKComponent, {
      width: '250px',
      data: this.firstAidKits
    });

    dialogRef.afterClosed().subscribe(result => { 
      // result it's userFirstAidKitID to delete or just empty string
      if (result) {
        localStorage.setItem('chosenFAK', '');
        this.defaultOption = '';
        this.isChosen = false;
        this.fakService.DeleteFAK(result).subscribe(() => {
          this.getUserFirstAidKits();
        });
      }
    });
  }

  OnAddMedicinesToFAK(){
    console.log('choose medicines to add');
    console.log(this.firstAidKits);
    console.log(this.medicines);
    this.deleteUFAK();
  }
}
