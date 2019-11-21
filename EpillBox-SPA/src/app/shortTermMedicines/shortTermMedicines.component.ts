import { Component, OnInit } from '@angular/core';
import { Medicine } from '../_model/Medicine';
import { FirstAidKitService } from '../_services/firstAidKit.service';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-shortTermMedicines',
  templateUrl: './shortTermMedicines.component.html',
  styleUrls: ['./shortTermMedicines.component.css']
})
export class ShortTermMedicinesComponent implements OnInit {

  medicines: Medicine[] = [];
  
  constructor(
    private fakService: FirstAidKitService,
    private authService: AuthService
  ) {}

  ngOnInit() {
    this.getMedicines();
  }

  getMedicines() {
    const actualUserId = this.authService.decodedToken.nameid;

    this.fakService
      .GetExpiredMedicines(actualUserId)
      .subscribe((values: Medicine[]) => {
        this.medicines = values;
      });
  }
}
