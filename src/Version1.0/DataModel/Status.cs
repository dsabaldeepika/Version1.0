using System.Collections.Generic;

namespace Version1.DataModel
{
    public class Status : Edit
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual List<Like> LikesList { get; set; }
        public virtual List<Comment> CommentsList { get; set; }
       
     
    }
}
