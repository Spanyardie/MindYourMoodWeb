using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindYourMoodWeb.Interfaces
{
    public interface IProblemRepository
    {
        void Update(Problem problem);
        Task<IEnumerable<ProblemDto>> GetProblemsAsync(int userId);
        Task<Problem> GetProblemAsync(int problemId);
        void AddProblem(Problem problem);
        void RemoveProblem(Problem problem);
    }
}
