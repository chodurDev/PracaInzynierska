import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { FirstAidKitMedicine } from '../../_model/FirstAidKitMedicine';
import { ScheduleSetting } from 'src/app/_model/scheduleSetting';

@Component({
  selector: 'app-dialogSetSchedule',
  templateUrl: './dialogSetSchedule.component.html',
  styleUrls: ['./dialogSetSchedule.component.css']
})
export class DialogSetScheduleComponent implements OnInit {
  scheduleSetting: ScheduleSetting = {
    firstAidKitMedicineID: this.data.firstAidKitMedicineID,
    firstServingAt: this.setTime(),
    numberOfServings: 3,
    servingSize: 1
  };
  constructor(
    public dialogRef: MatDialogRef<DialogSetScheduleComponent>,
    @Inject(MAT_DIALOG_DATA) public data: FirstAidKitMedicine
  ) {}

  ngOnInit() {}

  OnSetSchedule(): ScheduleSetting {
    return this.scheduleSetting;
  }

  setTime(): string {
    const temp = new Date(this.data.firstServingAt.toString());
    return temp.getHours().toString() + ':' + temp.getMinutes().toString();
  }
}
