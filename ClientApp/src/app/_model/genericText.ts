import { User } from "./user";

export interface GenericText {
  id: number;
  textType: number;
  textValue: string;
  user: User;
}
