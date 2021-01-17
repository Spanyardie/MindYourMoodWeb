import { Problem } from "./problem";
import { ProblemIdea } from "./problemIdea";
import { ProblemStep } from "./problemStep";

export interface ProblemProCon {
  id: number;
  idea: ProblemIdea;
  step: ProblemStep;
  problem: Problem;
  proConText: string;
  type: number;
}
