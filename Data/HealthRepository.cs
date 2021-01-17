using AutoMapper;
using System.Collections.Generic;
using MindYourMoodWeb.Entities;
using MindYourMoodWeb.DTOs;

namespace MindYourMoodWeb.Data
{
    public class HealthRepository : BaseRepository<Health>
    {
        public HealthRepository(DataContext context, IMapper mapper, IList<string> includes) : base(context, mapper, includes)
        {
        }
    }
}
