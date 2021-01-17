import { User } from "./user";

export interface TellMyself {
  id: number;
  tellText: string;
  tellTitle: string;
  user: User;
}
