import { ProblemStep } from './problemStep';
import { ProblemProCon } from './problemProCon';
import { Problem } from './problem';

export interface ProblemIdea {
  id: number;
  step: ProblemStep;
  problem: Problem;
  ideaText: string;
  prosAndCons: ProblemProCon[];
}
