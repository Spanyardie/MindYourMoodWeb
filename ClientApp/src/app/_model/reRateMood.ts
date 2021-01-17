import { Mood } from "./mood";
import { MoodList } from "./moodList";
import { ThoughtRecord } from './thoughtRecord';

export interface ReRateMood {
  id: number;
  moodList: MoodList;
  moodRating: number;
  mood: Mood;
  thoughtRecord: ThoughtRecord;
}
