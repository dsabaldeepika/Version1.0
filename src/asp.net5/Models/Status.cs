using System.Collections.Generic;

namespace asp.net5.Models
{
    public class Status : Edit
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual List<Like> LikesList { get; set; }
     
       
     
    }
}
