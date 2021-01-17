import { Medication } from "./medication";
import { MedicationSpread } from "./medicationSpread";

export interface MedicationTime {
  id: number;
  spread: MedicationSpread;
  medication: Medication;
  time: Date;
  takenTime: Date;
}
