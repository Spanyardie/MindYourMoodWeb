import { Component } from '@angular/core';
import { ActivityTime, IActivityTime } from '../../_model/activityTime';
import { User } from '../../_model/user';
import { ActivitytimeService } from '../../_services/activitytime.service';

@Component({
  selector: 'app-activitytime',
  templateUrl: './activitytime.component.html',
  styleUrls: ['./activitytime.component.css']
})
export class ActivitytimeComponent {
  user: User;
  activityTime: IActivityTime;
  userActivityTimes: ActivityTime[] = [];

  constructor(private activityTimeService: ActivitytimeService) { }

  getActivityTime(id: number) {
    this.activityTimeService.getActivityTime(id).subscribe(result => {
      this.activityTime = result;
    });
  }

  getActivityTimesForActivity(activityId: number) {
    this.activityTimeService.getActivityTimesForActivity(activityId).subscribe(result => {
      this.userActivityTimes = result;
    })
  }

  createActivityTime(activityId: number) {
    var activityTime = new ActivityTime();
    activityTime.activityId = activityId;
    activityTime.achievement = 1;
    activityTime.activityName = "Doing some steps exercise";
    activityTime.achievement = 8;
    activityTime.intimacy = 1;
    activityTime.pleasure = 4;
    activityTime.time = new Date(2021, 1, 16, 14, 30, 0, 0);
    this.activityTimeService.createActivityTime(activityId, activityTime);
  }

  removeActivityTime(id: number) {
    this.activityTimeService.removeActivityTime(id);
  }
}
