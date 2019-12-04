import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { UserFirstAidKit } from 'src/app/_model/UserFirstAidKit';

@Component({
  selector: 'app-dialogDeleteUserFAK',
  templateUrl: './dialogDeleteUserFAK.component.html',
  styleUrls: ['./dialogDeleteUserFAK.component.css']
})
export class DialogDeleteUserFAKComponent implements OnInit {
  defaultOption = '';
  constructor(
    public dialogRef: MatDialogRef<DialogDeleteUserFAKComponent>,
    @Inject(MAT_DIALOG_DATA) public data: UserFirstAidKit[]
  ) {}

  onNoClick(): void {
    this.dialogRef.close('');
  }
  ngOnInit() {
  }
}
