using System.Collections.Generic;

namespace Version1.DataModel
{
    public class Blog : Edit
    {
        public int Id { get;  set;}
        public string Name { get; set; }
        public virtual List<Post> PostList { get; set; }


    }
}
