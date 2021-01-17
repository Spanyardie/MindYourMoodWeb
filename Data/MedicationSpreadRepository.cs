using AutoMapper;
using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using System.Collections.Generic;

namespace MindYourMoodWeb.Data
{
    public class MedicationSpreadRepository : BaseRepository<MedicationSpread>
    {
        public MedicationSpreadRepository(DataContext context, IMapper mapper, IList<string> includes) : base(context, mapper, includes)
        {
        }
    }
}
