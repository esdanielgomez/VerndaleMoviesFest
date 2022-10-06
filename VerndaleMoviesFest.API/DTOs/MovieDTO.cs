namespace VerndaleMoviesFest.API.DTOs
{
    public class MovieDTO
    {
        public int IdMovie { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Duration { get; set; }
        public string Synopsis { get; set; }

        // Genre attributes
        public int IdGenre { get; set; }
        public string NameGenre { get; set; }
    }
}
