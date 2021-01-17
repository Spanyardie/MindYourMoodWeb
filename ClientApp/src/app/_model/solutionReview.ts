import { ProblemIdea } from "./problemIdea";
import { SolutionPlan } from "./solutionPlan";

export interface SolutionReview {
  id: number;
  idea: ProblemIdea;
  solutionSteps: SolutionPlan[];
  reviewText: string;
  achieved: boolean;
  achievedDate: Date;
}
