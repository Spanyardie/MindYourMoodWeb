import { PlayList } from "./playList";

export interface Track {
  id: null;
  playList: PlayList;
  name: string;
  artist: string;
  orderNumber: number;
  uri: string;
  duration: number;
}
