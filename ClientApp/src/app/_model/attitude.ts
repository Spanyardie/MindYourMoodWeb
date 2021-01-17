import { PlanAction } from "./planAction";

export interface Attitude extends PlanAction {
  id: number;
  feeling: number;
}
