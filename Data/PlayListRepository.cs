using AutoMapper;
using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using System.Collections.Generic;

namespace MindYourMoodWeb.Data
{
    public class PlayListRepository : BaseRepository<PlayList>
    {
        public PlayListRepository(DataContext context, IMapper mapper, IList<string> includes) : base(context, mapper, includes)
        {
        }
    }
}
