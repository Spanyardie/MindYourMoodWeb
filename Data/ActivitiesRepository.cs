using MindYourMoodWeb.Entities;
using System.Collections.Generic;
using MindYourMoodWeb.DTOs;
using AutoMapper;

namespace MindYourMoodWeb.Data
{
    public class ActivitiesRepository : BaseRepository<Activities>
    {
        public ActivitiesRepository(DataContext context, IMapper mapper, IList<string> includes) : base(context, mapper, includes)
        {
        }
    }
}
