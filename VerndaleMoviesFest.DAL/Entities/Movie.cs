using System;
using System.Collections.Generic;

namespace VerndaleMoviesFest.DAL.Entities
{
    public partial class Movie
    {
        public int IdMovie { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Duration { get; set; }
        public string Synopsis { get; set; }
        public int IdGenre { get; set; }

        public virtual Genre IdGenreNavigation { get; set; }
    }
}
