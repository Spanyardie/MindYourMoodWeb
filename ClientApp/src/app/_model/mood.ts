import { MoodList } from './moodList';
import { ThoughtRecord } from './thoughtRecord';

export interface Mood {
  id: number;
  moodList: MoodList;
  moodRating: number;
  thoughtRecord: ThoughtRecord;
}
