using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindYourMoodWeb.Interfaces
{
    public interface IPlayListRepository
    {
        void Update(PlayList playList);
        Task<IEnumerable<PlayListDto>> GetPlayListsAsync(int userId);
        Task<PlayList> GetPlayListAsync(int playListId);
        void AddPlayList(PlayList playList);
        void RemovePlayList(PlayList playList);
    }
}
