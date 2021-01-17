using MindYourMoodWeb.Entities;
using System.Collections.Generic;
using MindYourMoodWeb.DTOs;
using AutoMapper;

namespace MindYourMoodWeb.Data
{
    public class AlternativeThoughtRepository : BaseRepository<AlternativeThought>
    {
        public AlternativeThoughtRepository(DataContext context, IMapper mapper, IList<string> includes) : base(context, mapper, includes)
        {
        }
    }
}
