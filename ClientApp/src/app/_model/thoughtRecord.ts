import { AlternativeThought } from "./alternativeThought";
import { AutomaticThought } from "./automaticThought";
import { EvidenceAgainstHotThought } from "./evidenceAgainstHotThought";
import { EvidenceForHotThought } from "./evidenceForHotThought";
import { Mood } from "./mood";
import { ReRateMood } from "./reRateMood";
import { Situation } from "./situation";
import { User } from "./user";

export interface ThoughtRecord {
  id: number;
  recordDate: Date;
  user: User;
  situation: Situation[];
  moods: Mood[];
  automaticThoughts: AutomaticThought[];
  evidenceFor: EvidenceForHotThought[];
  evidenceAgainst: EvidenceAgainstHotThought[];
  alternativeThoughts: AlternativeThought[];
  reRateMoods: ReRateMood[];
}
