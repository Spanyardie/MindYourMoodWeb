using AutoMapper;
using System.Collections.Generic;
using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;

namespace MindYourMoodWeb.Data
{
    public class ReRateMoodRepository : BaseRepository<ReRateMood>
    {
        public ReRateMoodRepository(DataContext context, IMapper mapper, IList<string> includes) : base(context, mapper, includes)
        {
        }
    }
}
