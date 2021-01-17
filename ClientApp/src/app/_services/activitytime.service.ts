import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { ActivityTime, IActivityTime } from '../_model/activityTime';

@Injectable({
  providedIn: 'root'
})
export class ActivitytimeService {
  baseUrl = environment.apiUrl;
  activitytime: ActivityTime;

  constructor(private http: HttpClient) { }

  getActivityTime(id: number) {
    return this.http.get<IActivityTime>(this.baseUrl + 'activitytime/getactivitytime/' + id.toString());
  }

  getActivityTimesForActivity(activityId: number) {
    return this.http.get<IActivityTime[]>(this.baseUrl + 'activitytime/getactivitytimes/' + activityId.toString());
  }

  createActivityTime(activityId: number, activitytime: IActivityTime) {
    var retval = this.http.post<ActivityTime>(this.baseUrl + 'activitytime/createactivitytime/' + activityId.toString(), activitytime)
      .subscribe(result => {
        console.log(result);
        error => {
          console.log(error);
        }
      });
    console.log(retval);
  }

  removeActivityTime(id: number) {
    return this.http.delete<IActivityTime>(this.baseUrl + 'activitytime/removeactivitytime/' + id.toString()).subscribe(result => {
      console.log(result);
      error => {
        console.log(error);
      }
    })
  }
}
