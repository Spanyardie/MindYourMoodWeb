import { PlanAction } from "./planAction";
import { User } from "./user";

export interface Fantasy extends PlanAction {
  id: number;
  user: User;
}
