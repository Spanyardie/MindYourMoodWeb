import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Activity, IActivity } from '../_model/activity';

@Injectable({
  providedIn: 'root'
})
export class ActivityService {
  baseUrl = environment.apiUrl;
  activity: Activity;

  constructor(private http: HttpClient) { }

  getActivity(id: number) {
    return this.http.get<IActivity>(this.baseUrl + 'activities/getactivity/' + id.toString());
  }

  getActivitiesForUser(userId: number) {
    return this.http.get<IActivity[]>(this.baseUrl + 'activities/getactivities/' + userId.toString());
  }

  createActivity(activity: IActivity) {
    var retval = this.http.post<Activity>(this.baseUrl + 'activities/createactivity/', activity)
      .subscribe(result => {
        console.log(result);
        error => {
          console.log(error);
        }
      });
    console.log(retval);
  }

  removeActivity(id: number) {
    return this.http.delete<IActivity>(this.baseUrl + 'activities/removeactivity/' + id.toString()).subscribe(result => {
      console.log(result);
      error => {
        console.log(error);
      }
    })
  }
}
