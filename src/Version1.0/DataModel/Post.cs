
using System;

namespace Version1.DataModel
{
    public class Post : Edit
    {
        public int Id { get; set; }
        public string To { get; set; }
        public int ToId { get; set; }
        public string From { get; set; }
        public int FromId { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime? DateRead { get; set; }

        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }

    }
}