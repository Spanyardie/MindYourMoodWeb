using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using MindYourMoodWeb.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindYourMoodWeb.Data
{
    public class TrackRepository : ITrackRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public TrackRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddTrack(Track track)
        {
            _context.Tracks.Add(track);
        }

        public async Task<Track> GetTrackAsync(int trackId)
        {
            return await _context.Tracks
                .Include(pl => pl.PlayList)
                .SingleOrDefaultAsync(t => t.Id == trackId);
        }

        public async Task<IEnumerable<TrackDto>> GetTracksAsync(int playListId)
        {
            var tracks = await _context.Tracks
                .Include(pl => pl.PlayList)
                .Where(pl => pl.PlayList.Id == playListId)
                .ProjectTo<TrackDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return tracks;
        }

        public void RemoveTrack(Track track)
        {
            _context.Tracks.Remove(track);
        }

        public void Update(Track track)
        {
            _context.Entry(track).State = EntityState.Modified;
        }
    }
}
