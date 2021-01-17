//import { User } from "./user";

export interface IAffirmation {
  id: number;
  userId: number;
  affirmationText: string;
}

export class Affirmation implements IAffirmation {
    id: number;
    userId: number;
    affirmationText: string;
}
