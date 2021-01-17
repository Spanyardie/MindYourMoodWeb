import { Appointment } from './appointment';

export interface AppointmentQuestion {
  id: number;
  appointment: Appointment;
  question: string;
  answer: string;
}
