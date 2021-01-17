import { AppointmentQuestion } from './AppointmentQuestion';
import { User } from './user';

export interface Appointment {
  id: number;
  date: Date;
  type: number;
  location: string;
  withWhom: string;
  appointmentTime: Date;
  notes: string;
  questions: AppointmentQuestion[];
  user: User;
}
