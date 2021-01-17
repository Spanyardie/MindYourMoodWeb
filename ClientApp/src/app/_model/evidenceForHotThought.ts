import { AutomaticThought } from "./automaticThought";
import { ThoughtRecord } from "./thoughtRecord";

export interface EvidenceForHotThought {
  id: number;
  automaticThought: AutomaticThought;
  evidence: string;
  thoughtRecord: ThoughtRecord;
}
