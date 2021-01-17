export interface IActivityTime {
  id: number;
  activityName: string;
  time: Date;
  achievement: number;
  intimacy: number;
  pleasure: number;
  activityId: number;
}

export class ActivityTime implements IActivityTime {
    id: number;
    activityName: string;
    time: Date;
    achievement: number;
    intimacy: number;
    pleasure: number;
    activityId: number;
}
