using NecFlixApp.API.Data;

namespace NecFlixApp.API.Models.Movies
{
    public class MovieDto
    {
        public int MovieId { get; set; }
        public string? MovieName { get; set; }
        public string? Description { get; set; }
        public string? Director { get; set; }
        public int MovieRate { get; set; }
        public string? Img { get; set; }
        public string? Trailer { get; set; }
        public bool IsStatus { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set;}
        public List<string>? Comments { get; set; }
    }
}
