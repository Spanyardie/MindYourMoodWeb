import { ThoughtRecord } from './thoughtRecord';

export interface AlternativeThought {
  id: number;
  alternative: string;
  beliefRating: number;
  thoughtRecord: ThoughtRecord;
}
