import { Component, OnInit } from '@angular/core';
import { Medicine } from '../_model/Medicine';
import { FirstAidKitService } from '../_services/firstAidKit.service';
import { AuthService } from '../_services/auth.service';
import { FirstAidKitMedicine } from '../_model/FirstAidKitMedicine';

@Component({
  selector: 'app-shortTermMedicines',
  templateUrl: './shortTermMedicines.component.html',
  styleUrls: ['./shortTermMedicines.component.css']
})
export class ShortTermMedicinesComponent implements OnInit {

  medicines: FirstAidKitMedicine[] = [];
  
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
      .subscribe((values: FirstAidKitMedicine[]) => {
        this.medicines = values;
      });
  }
}
