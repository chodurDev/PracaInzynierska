import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { UserFirstAidKit } from '../../_model/UserFirstAidKit';

@Component({
  selector: 'app-dialogAddUserFAK',
  templateUrl: './dialogAddUserFAK.component.html',
  styleUrls: ['./dialogAddUserFAK.component.css']
})
export class DialogAddUserFAKComponent implements OnInit {
  nameFAK: string;
  constructor(public dialogRef: MatDialogRef<DialogAddUserFAKComponent>) {}

  onNoClick(): void {
    this.dialogRef.close();
  }

  ngOnInit() {}
}
