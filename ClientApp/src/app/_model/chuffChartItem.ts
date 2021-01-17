import { User } from './user';

export interface ChuffChartItem {
  id: number;
  achievementType: number;
  achievement: string;
  chuffChartType: number;
  achievementDate: Date;
  user: User;
}
