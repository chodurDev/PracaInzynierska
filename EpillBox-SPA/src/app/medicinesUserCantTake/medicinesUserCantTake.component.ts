import { Component, OnInit } from '@angular/core';
import { FirstAidKitService } from '../_services/firstAidKit.service';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-medicinesUserCantTake',
  templateUrl: './medicinesUserCantTake.component.html',
  styleUrls: ['./medicinesUserCantTake.component.css']
})
export class MedicinesUserCantTakeComponent implements OnInit {
  constructor(
    private fakService: FirstAidKitService,
    private authService: AuthService
  ) {}

  ngOnInit() {
    const actualUserId = this.authService.decodedToken.nameid;
    this.fakService.GetMedicinesUserCantTake(actualUserId).subscribe(result => {
      console.log(result);
    });
  }
}
