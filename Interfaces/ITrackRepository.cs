using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindYourMoodWeb.Interfaces
{
    public interface ITrackRepository
    {
        void Update(Track track);
        Task<IEnumerable<TrackDto>> GetTracksAsync(int playListId);
        Task<Track> GetTrackAsync(int trackId);
        void AddTrack(Track track);
        void RemoveTrack(Track track);
    }
}
