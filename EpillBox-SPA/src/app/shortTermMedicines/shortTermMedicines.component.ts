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
  expiredMedicines: FirstAidKitMedicine[] = [];
  shortTermMedicines: FirstAidKitMedicine[] = [];
  defaultValue = '7';
  actualUserId: any;
  constructor(
    private fakService: FirstAidKitService,
    private authService: AuthService
  ) {
    this.actualUserId = this.authService.decodedToken.nameid;
  }

  ngOnInit() {
    this.getShortTerm();
    this.getExpired();
  }

  getShortTerm() {
    this.fakService
      .GetShortTermMedicines(this.actualUserId, +this.defaultValue)
      .subscribe((values: FirstAidKitMedicine[]) => {
        this.shortTermMedicines = values.slice(0);
      });
  }
  getExpired() {
    this.fakService
      .GetExpiredMedicines(this.actualUserId)
      .subscribe((values: FirstAidKitMedicine[]) => {
        this.expiredMedicines = values;
      });
  }
}
