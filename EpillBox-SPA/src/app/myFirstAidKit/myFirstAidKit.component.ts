import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { FirstAidKitService } from '../_services/firstAidKit.service';

@Component({
  selector: 'app-myFirstAidKit',
  templateUrl: './myFirstAidKit.component.html',
  styleUrls: ['./myFirstAidKit.component.css']
})
export class MyFirstAidKitComponent implements OnInit {
  medicines: any = [];
  constructor(
    private fakService: FirstAidKitService,
    private authService: AuthService
  ) {}

  ngOnInit() {
    const actualUserId = this.authService.decodedToken.nameid;

    this.fakService.GetuserMedicines(actualUserId).subscribe(values => {
      this.medicines = values;
    });
  }
}
