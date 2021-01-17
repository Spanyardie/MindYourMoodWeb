using AutoMapper;
using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using System.Collections.Generic;

namespace MindYourMoodWeb.Data
{
    public class FantasyRepository : BaseRepository<Fantasy>
    {
        public FantasyRepository(DataContext context, IMapper mapper, IList<string> includes) : base(context, mapper, includes)
        {
        }
    }
}
