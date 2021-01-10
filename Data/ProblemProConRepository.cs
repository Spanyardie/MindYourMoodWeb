using System.Collections.Generic;
using MindYourMoodWeb.Entities;
using MindYourMoodWeb.DTOs;
using AutoMapper;

namespace MindYourMoodWeb.Data
{
    public class ProblemProConRepository : BaseRepository<ProblemProCon, ProblemProConDto>
    {
        public ProblemProConRepository(DataContext context, IMapper mapper, IList<string> includes) : base(context, mapper, includes)
        {
        }
    }
}
