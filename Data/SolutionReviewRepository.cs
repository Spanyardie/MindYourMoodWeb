using System.Collections.Generic;
using MindYourMoodWeb.Entities;
using MindYourMoodWeb.DTOs;
using AutoMapper;

namespace MindYourMoodWeb.Data
{
    public class SolutionReviewRepository : BaseRepository<SolutionReview, SolutionReviewDto>
    {
        public SolutionReviewRepository(DataContext context, IMapper mapper, IList<string> includes) : base(context, mapper, includes)
        {
        }
    }
}
