import { User } from "./user";
import { Track } from './track';

export interface PlayList {
  id: number;
  name: string;
  trackCount: number;
  tracks: Track[];
  user: User;
}
