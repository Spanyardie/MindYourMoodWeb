using System.Collections.Generic;
using MindYourMoodWeb.Entities;
using MindYourMoodWeb.DTOs;
using AutoMapper;

namespace MindYourMoodWeb.Data
{
    public class SolutionPlanRepository : BaseRepository<SolutionPlan, SolutionPlanDto>
    {
        public SolutionPlanRepository(DataContext context, IMapper mapper, IList<string> includes) : base(context, mapper, includes)
        {
        }
    }
}
