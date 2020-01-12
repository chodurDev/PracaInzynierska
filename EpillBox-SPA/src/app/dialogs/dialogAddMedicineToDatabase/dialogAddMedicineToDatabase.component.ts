import { Component, OnInit } from '@angular/core';
import { MedicineToAdd } from 'src/app/_model/MedicineToAdd';

@Component({
  selector: 'app-dialogAddMedicineToDatabase',
  templateUrl: './dialogAddMedicineToDatabase.component.html',
  styleUrls: ['./dialogAddMedicineToDatabase.component.css']
})
export class DialogAddMedicineToDatabaseComponent implements OnInit {
  model: MedicineToAdd = {
    name: '',
    producer: '',
    activeSubstance: '',
    quantityInPackage: null,
    form: null
  };
  constructor() {}

  ngOnInit() {}

  onAddClick(): MedicineToAdd {
    return this.model;
  }
}
