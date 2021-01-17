import { User } from "./user";

export interface PlanAction {
  toWhat: string;
  strength: number;
  type: number;
  doAction: number;
  actionOf: string;
  user: User;
}
