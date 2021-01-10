using MindYourMoodWeb.Entities;
using System.Collections.Generic;
using MindYourMoodWeb.DTOs;
using AutoMapper;

namespace MindYourMoodWeb.Data
{
    public class EvidenceAgainstHotThoughtRepository : BaseRepository<EvidenceAgainstHotThought, EvidenceAgainstHotThoughtDto>
    {
        public EvidenceAgainstHotThoughtRepository(DataContext context, IMapper mapper, IList<string> includes) : base(context, mapper, includes)
        {
        }
    }
}
