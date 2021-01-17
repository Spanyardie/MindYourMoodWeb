import { AutomaticThought } from "./automaticThought";
import { ThoughtRecord } from "./thoughtRecord";

export interface EvidenceAgainstHotThought {
  id: number;
  automaticThought: AutomaticThought;
  evidence: string;
  thoughtRecord: ThoughtRecord;
}
