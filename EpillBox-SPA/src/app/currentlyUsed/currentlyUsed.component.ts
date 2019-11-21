import { Component, OnInit } from '@angular/core';
import { Medicine } from '../_model/Medicine';
import { FirstAidKitService } from '../_services/firstAidKit.service';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-currentlyUsed',
  templateUrl: './currentlyUsed.component.html',
  styleUrls: ['./currentlyUsed.component.css']
})
export class CurrentlyUsedComponent implements OnInit {
  medicines: Medicine[] = [];
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
      .GetuserMedicines(actualUserId)
      .subscribe((values: Medicine[]) => {
        this.medicines = values;
      });
  }
}
