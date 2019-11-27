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
  }

  getUserFirstAidKits() {
    this.actualUserId = this.authService.decodedToken.nameid;

    this.fakService.GetUserFirstAidKits(this.actualUserId).subscribe(values => {
      console.log(values);
      this.firstAidKits = values;
    });
  }

  getUserMedicines() {
    this.fakService
      .GetuserMedicines(this.actualUserId)
      .subscribe((values: FirstAidKitMedicine[]) => {
        console.log(values);
        this.medicines = values.slice(0);
        this.isChosen = true;
      });
  }

  onFirstAidKitClick(id: number) {
    if (id === 0) {
      this.isChosen = false;
    }
    this.getUserChosenFirstAidKitMedicines(id);
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
