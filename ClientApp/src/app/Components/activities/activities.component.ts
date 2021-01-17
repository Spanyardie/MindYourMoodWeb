import { Component } from '@angular/core';
import { Activity, IActivity } from '../../_model/activity';
import { User } from '../../_model/user';
import { AccountService } from '../../_services/account.service';
import { ActivityService } from '../../_services/activity.service';

@Component({
  selector: 'app-activities',
  templateUrl: './activities.component.html',
  styleUrls: ['./activities.component.css']
})
export class ActivitiesComponent {
  user: User;
  activity: IActivity;
  userActivities: Activity[] = [];

  constructor(private activityService: ActivityService, private accountService: AccountService) { }

  getActivity(id: number) {
    this.activityService.getActivity(id).subscribe(result => {
      this.activity = result;
      console.log(result);
    });
  }

  getActivitiesForUser(userId: number) {
    this.activityService.getActivitiesForUser(userId).subscribe(result => {
      this.userActivities = result;
    })
  }

  createActivity(userId: number, ) {
    var activity = new Activity();
    activity.userID = userId;
    activity.activityTimes = [];
    activity.activityDate = new Date(2021, 1, 16, 15, 30, 0, 0);
    this.activityService.createActivity(activity);
  }

  removeActivity(id: number) {
    this.activityService.removeActivity(id);
  }
}
