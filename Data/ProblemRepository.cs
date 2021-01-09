using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using MindYourMoodWeb.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindYourMoodWeb.Data
{
    public class ProblemRepository : IProblemRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProblemRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddProblem(Problem problem)
        {
            _context.Problems.Add(problem);
        }

        public async Task<Problem> GetProblemAsync(int problemId)
        {
            return await _context.Problems
                .Include(u => u.User)
                .Include(ps => ps.Steps)
                .SingleOrDefaultAsync(p => p.Id == problemId);
        }

        public async Task<IEnumerable<ProblemDto>> GetProblemsAsync(int userId)
        {
            var problems = await _context.Problems
                .Include(u => u.User)
                .Include(ps => ps.Steps)
                .Where(u => u.User.Id == userId)
                .ProjectTo<ProblemDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return problems;
        }

        public void RemoveProblem(Problem problem)
        {
            _context.Problems.Remove(problem);
        }

        public void Update(Problem problem)
        {
            _context.Entry(problem).State = EntityState.Modified;
        }
    }
}
