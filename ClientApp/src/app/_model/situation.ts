import { ThoughtRecord } from './thoughtRecord';

export interface Situation {
  id: number;
  thoughtRecord: ThoughtRecord;
  who: string;
  what: string;
  when: string;
  where: string;
}
