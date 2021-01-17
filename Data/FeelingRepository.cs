using AutoMapper;
using System.Collections.Generic;
using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;

namespace MindYourMoodWeb.Data
{
    public class FeelingRepository : BaseRepository<Feeling>
    {
        public FeelingRepository(DataContext context, IMapper mapper, IList<string> includes) : base(context, mapper, includes)
        {
        }
    }
}
