import { Medication } from "./medication";
import { MedicationReminder } from "./medicationReminder";
import { MedicationTime } from "./medicationTime";

export interface MedicationSpread {
  foodRelevance: number;
  id: number;
  medication: Medication;
  dosage: number;
  medicationTime: MedicationTime;
  medicationTakeReminder: MedicationReminder;
}
