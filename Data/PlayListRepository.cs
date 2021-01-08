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
    public class PlayListRepository : IPlayListRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PlayListRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddPlayList(PlayList playList)
        {
            _context.PlayLists.Add(playList);
        }

        public async Task<PlayList> GetPlayListAsync(int playListId)
        {
            return await _context.PlayLists
                .Include(u => u.User)
                .SingleOrDefaultAsync(pl => pl.Id == playListId);
        }

        public async Task<IEnumerable<PlayListDto>> GetPlayListsAsync(int userId)
        {
            var playLists = await _context.PlayLists
                .Include(u => u.User)
                .Where(U => U.User.Id == userId)
                .ProjectTo<PlayListDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return playLists;
        }

        public void RemovePlayList(PlayList playList)
        {
            _context.PlayLists.Remove(playList);
        }

        public void Update(PlayList playList)
        {
            _context.Entry(playList).State = EntityState.Modified;
        }
    }
}
