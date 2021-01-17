import { Prescription } from './prescription';
import { MedicationSpread } from './medicationSpread';

export interface Medication {
  id: number;
  medicationName: string;
  totalDailyDosage: number;
  prescription: Prescription;
  medicationSpreads: MedicationSpread[];
}
