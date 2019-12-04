import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { UserFirstAidKit } from '../../_model/UserFirstAidKit';

@Component({
  selector: 'app-dialogAddUserFAK',
  templateUrl: './dialogAddUserFAK.component.html',
  styleUrls: ['./dialogAddUserFAK.component.css']
})
export class DialogAddUserFAKComponent implements OnInit {
  constructor(
    public dialogRef: MatDialogRef<DialogAddUserFAKComponent>,
    @Inject(MAT_DIALOG_DATA) public data: UserFirstAidKit
  ) {}

  onNoClick(): void {
    this.data.name = '';
    this.dialogRef.close(this.data);
  }

  ngOnInit() {}
}
