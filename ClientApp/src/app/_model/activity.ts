import { ActivityTime } from "./activityTime";

export interface IActivity {
  id: number;
  activityDate: Date;
  activityTimes: ActivityTime[];
  userID: number;
}

export class Activity implements IActivity {
    id: number;
    activityDate: Date;
    activityTimes: ActivityTime[];
    userID: number;
}
