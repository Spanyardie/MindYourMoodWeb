import { EvidenceAgainstHotThought } from './evidenceAgainstHotThought';
import { EvidenceForHotThought } from './evidenceForHotThought';
import { ThoughtRecord } from './thoughtRecord';

export interface AutomaticThought {
  id: number;
  hotThought: boolean;
  thought: string;
  thoughtRecord: ThoughtRecord;
  evidenceForHotThought: EvidenceForHotThought[];
  evidenceAgainstHotThought: EvidenceAgainstHotThought[];
}
