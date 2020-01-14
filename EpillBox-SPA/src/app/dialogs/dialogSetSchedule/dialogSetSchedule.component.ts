import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { FirstAidKitMedicine } from '../../_model/FirstAidKitMedicine';
import { ScheduleSetting } from 'src/app/_model/scheduleSetting';
import { Scheduler } from 'rxjs';

@Component({
  selector: 'app-dialogSetSchedule',
  templateUrl: './dialogSetSchedule.component.html',
  styleUrls: ['./dialogSetSchedule.component.css']
})
export class DialogSetScheduleComponent implements OnInit {
  scheduleSetting: ScheduleSetting;
  constructor(
    public dialogRef: MatDialogRef<DialogSetScheduleComponent>,
    @Inject(MAT_DIALOG_DATA) public data: FirstAidKitMedicine
  ) {
    this.scheduleSetting = {
      firstAidKitMedicineID: this.data.firstAidKitMedicineID,
      firstServingAt: this.setTime(),
      numberOfServings: this.data.numberOfServings,
      servingSize: this.data.servingSize
    };
  }

  ngOnInit() {}

  OnSetSchedule(): ScheduleSetting {
    return this.scheduleSetting;
  }

  setTime(): string {
    const temp = new Date(this.data.firstServingAt.toString());
    return temp.getHours().toString() + ':' + temp.getMinutes().toString();
  }
}
