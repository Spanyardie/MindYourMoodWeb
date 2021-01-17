import { MedicationSpread } from './medicationSpread';

export interface MedicationReminder {
  id: number;
  medicationSpread: MedicationSpread;
  medicationDay: number;
  medicationTime: Date;
}
