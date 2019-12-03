import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { FirstAidKitService } from '../_services/firstAidKit.service';
import { Medicine } from '../_model/Medicine';
import { FirstAidKitMedicine } from '../_model/FirstAidKitMedicine';

@Component({
  selector: 'app-myFirstAidKit',
  templateUrl: './myFirstAidKit.component.html',
  styleUrls: ['./myFirstAidKit.component.css']
})
export class MyFirstAidKitComponent implements OnInit {
  medicines: FirstAidKitMedicine[] = [];
  defaultOption = '';
  firstAidKits: any = [];
  isChosen = false;
  actualUserId: number;

  constructor(
    private fakService: FirstAidKitService,
    private authService: AuthService
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
}
