import { SolutionReview } from './solutionReview';

export interface SolutionPlan {
  id: number;
  solutionReview: SolutionReview;
  solutionStep: string;
  priorityOrder: number;
}
