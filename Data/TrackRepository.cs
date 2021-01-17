using AutoMapper;
using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using System.Collections.Generic;

namespace MindYourMoodWeb.Data
{
    public class TrackRepository : BaseRepository<Track>
    {
        public TrackRepository(DataContext context, IMapper mapper, IList<string> includes) : base(context, mapper, includes)
        {
        }
    }
}
