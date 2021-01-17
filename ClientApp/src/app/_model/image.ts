import { User } from "./user";

export interface Image {
  id: number;
  uri: string;
  comment: string;
  user: User;
}
