using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace MvsixAPI.Models
{
    public class Song
    {
        public Song() { }
        public int Id { get; set; } = 0;
        public string SongName { get; set; } = string.Empty;
        public string ReleaseYear { get; set; } = string.Empty;
        public string SongDuration { get; set; } = string.Empty;
        public string SongGenre { get; set;} = string.Empty;
        public string Album { get; set; } = string.Empty;
        public string SongPath { get; set; } = string.Empty;
        public Artist SongArtist { get; set; } = new Artist();
    }
}
