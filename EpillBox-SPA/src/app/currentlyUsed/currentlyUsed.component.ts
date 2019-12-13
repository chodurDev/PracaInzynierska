import { Component, OnInit } from '@angular/core';
import { Medicine } from '../_model/Medicine';
import { FirstAidKitService } from '../_services/firstAidKit.service';
import { AuthService } from '../_services/auth.service';
import { FirstAidKitMedicine } from '../_model/FirstAidKitMedicine';

@Component({
  selector: 'app-currentlyUsed',
  templateUrl: './currentlyUsed.component.html',
  styleUrls: ['./currentlyUsed.component.css']
})
export class CurrentlyUsedComponent implements OnInit {
  medicines: FirstAidKitMedicine[] = [];
  constructor(
    private fakService: FirstAidKitService,
    private authService: AuthService
  ) {}

  ngOnInit() {
    this.getUserMedicines();
  }

  getUserMedicines() {
    const actualUserId = this.authService.decodedToken.nameid;

    this.fakService
      .GetUserTakenMedicines(actualUserId)
      .subscribe((values: FirstAidKitMedicine[]) => {
        this.medicines = values;
      });
  }
}
