using System.Collections.Generic;

namespace MindYourMoodWeb.Entities
{
    public class PlayList : Entity
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public int TrackCount { get; set; }
        public ICollection<Track> Tracks { get; set; }
        public AppUser User { get; set; }
    }
}
