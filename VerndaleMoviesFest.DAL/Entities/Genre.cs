﻿using System;
using System.Collections.Generic;

namespace VerndaleMoviesFest.DAL.Entities
{
    public partial class Genre
    {
        public Genre()
        {
            Movies = new HashSet<Movie>();
        }

        public int IdGenre { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
