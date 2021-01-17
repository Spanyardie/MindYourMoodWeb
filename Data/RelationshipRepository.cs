using System.Collections.Generic;
using AutoMapper;
using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;

namespace MindYourMoodWeb.Data
{
    public class RelationshipRepository : BaseRepository<Relationship>
    {
        public RelationshipRepository(DataContext context, IMapper mapper, IList<string> includes) : base(context, mapper, includes)
        {
        }
    }
}
