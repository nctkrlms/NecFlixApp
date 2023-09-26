using System;
using System.Collections.Generic;

namespace NecFlixApp.API.Data
{
    public partial class Movie
    {
        public Movie()
        {
            Comments = new HashSet<Comment>();
            Favorites = new HashSet<Favorite>();
        }

        public int MovieId { get; set; }
        public string? MovieName { get; set; }
        public string? Description { get; set; }
        public string? Director { get; set; }
        public int MovieRate { get; set; }
        public string? Img { get; set; }
        public string? Trailer { get; set; }
        public bool IsStatus { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
    }
}
