namespace MvsixAPI.Models
{
    public class Artist
    {
        public Artist() { }
        public int Id { get; set; } = -1;
        public string ArtistName { get; set; } = string.Empty;
        public string ArtistDescription { get; set; } = string.Empty;
        public List<Song> Songs { get; set; } = new List<Song>();
    }
}
