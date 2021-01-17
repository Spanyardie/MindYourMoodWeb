import { User } from "./user";

export interface SafetyPlanCard {
  id: number;
  calmMyself: string;
  tellMyself: string;
  willCall: string;
  willGoTo: string;
  user: User;
}
