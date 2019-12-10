import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { UserFirstAidKit } from 'src/app/_model/UserFirstAidKit';

@Component({
  selector: 'app-dialogAddMedicineToFAK',
  templateUrl: './dialogAddMedicineToFAK.component.html',
  styleUrls: ['./dialogAddMedicineToFAK.component.css']
})
export class DialogAddMedicineToFAKComponent implements OnInit {

  defaultOption = '';
  constructor(
    public dialogRef: MatDialogRef<DialogAddMedicineToFAKComponent>,
    @Inject(MAT_DIALOG_DATA) public data: UserFirstAidKit[]
  ) {}

  onNoClick(): void {
    this.dialogRef.close();
  }
  ngOnInit() {
    console.log(this.data);
  }

}
