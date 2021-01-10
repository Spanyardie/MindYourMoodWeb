using System.Collections.Generic;
using MindYourMoodWeb.Entities;
using MindYourMoodWeb.DTOs;
using AutoMapper;

namespace MindYourMoodWeb.Data
{
    public class SafetyPlanCardRepository : BaseRepository<SafetyPlanCard, SafetyPlanCardDto>
    {
        public SafetyPlanCardRepository(DataContext context, IMapper mapper, IList<string> includes) : base(context, mapper, includes)
        {
        }
    }
}
