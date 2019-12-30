import { Component, OnInit } from '@angular/core';
import { FirstAidKitMedicine } from '../_model/FirstAidKitMedicine';
import { MedicineService } from '../_services/medicine.service';
import { Medicine } from '../_model/Medicine';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-medicineDatabase',
  templateUrl: './medicineDatabase.component.html',
  styleUrls: ['./medicineDatabase.component.css']
})
export class MedicineDatabaseComponent implements OnInit {
  medicines: FirstAidKitMedicine[] = [];
 

  constructor(private medService: MedicineService,private  authService: AuthService) {}

  ngOnInit() {
    this.getMedicines();
  }

  getMedicines() {
    this.medService.GetAllMedicines().subscribe((medicines: FirstAidKitMedicine[]) => {
      this.medicines = medicines;
    });
  }
}
