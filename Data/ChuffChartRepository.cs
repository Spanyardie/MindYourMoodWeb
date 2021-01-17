using System.Collections.Generic;
using AutoMapper;
using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;

namespace MindYourMoodWeb.Data
{
    public class ChuffChartRepository : BaseRepository<ChuffChartItem>
    {
        public ChuffChartRepository(DataContext context, IMapper mapper, IList<string> includes) : base(context, mapper, includes)
        {
        }
    }
}
