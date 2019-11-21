import { Component, OnInit} from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { FirstAidKitService } from '../_services/firstAidKit.service';
import { Medicine } from '../_model/Medicine';

@Component({
  selector: 'app-myFirstAidKit',
  templateUrl: './myFirstAidKit.component.html',
  styleUrls: ['./myFirstAidKit.component.css']
})
export class MyFirstAidKitComponent implements OnInit {
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
