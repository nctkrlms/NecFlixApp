using System;
using System.Collections.Generic;

namespace NecFlixApp.API.Data
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public string? Content { get; set; }
        public int Rate { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }

        public virtual Movie Movie { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
