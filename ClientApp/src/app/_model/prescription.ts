import { Medication } from "./medication";
import { User } from "./user";

export interface Prescription {
  id: number;
  medications: Medication[];
  prescriptionType: number;
  weeklyDay: number;
  monthlyDay: number;
  user: User;
}
