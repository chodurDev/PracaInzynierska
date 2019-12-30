import { Component, OnInit } from '@angular/core';
import { FirstAidKitMedicine } from '../_model/FirstAidKitMedicine';
import { MedicineService } from '../_services/medicine.service';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-medicineToBuy',
  templateUrl: './medicineToBuy.component.html',
  styleUrls: ['./medicineToBuy.component.css']
})
export class MedicineToBuyComponent implements OnInit {
  medicines: FirstAidKitMedicine[] = [];

  constructor(
    private medService: MedicineService,
    private authService: AuthService
  ) {}

  ngOnInit() {
    this.getMedicines();
  }

  getMedicines() {
    const actualUserId = this.authService.decodedToken.nameid;
    this.medService
      .GetMedicinesToShoppingBasket(actualUserId)
      .subscribe((medicines: FirstAidKitMedicine[]) => {
        this.medicines = medicines;
      });
  }
}
