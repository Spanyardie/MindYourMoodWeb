import { PlanAction } from './planAction';

export interface Feeling extends PlanAction{
  id: number;
  feeling: number;
}
