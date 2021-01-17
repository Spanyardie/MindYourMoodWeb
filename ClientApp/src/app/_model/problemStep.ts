import { Problem } from "./problem";
import { ProblemIdea } from "./problemIdea";

export interface ProblemStep {
  id: number;
  problem: Problem;
  step: string;
  priorityOrder: number;
  ideas: ProblemIdea[];
}
