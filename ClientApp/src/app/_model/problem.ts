import { ProblemStep } from './problemStep';
import { User } from './user';

export interface Problem {
  id: number;
  problemText: string;
  steps: ProblemStep;
  user: User;
}
