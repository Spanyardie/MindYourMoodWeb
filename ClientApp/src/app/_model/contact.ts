import { User } from "./user";

export interface Contact {
  id: number;
  uri: number;
  name: string;
  telephoneNumber: string;
  email: string;
  useEmergencyCall: boolean;
  useEmergencyEmail: boolean;
  useEmergencySms: boolean;
  photoId: string;
  user: User;
}
