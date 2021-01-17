using AutoMapper;
using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using System.Collections.Generic;

namespace MindYourMoodWeb.Data
{
    public class SituationRepository : BaseRepository<Situation>
    {
        public SituationRepository(DataContext context, IMapper mapper, IList<string> includes) : base(context, mapper, includes)
        {
        }
    }
}
