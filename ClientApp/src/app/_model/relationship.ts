import { PlanAction } from "./planAction";

export interface Relationship extends PlanAction {
  id: number;
  feeling: number;
}
