using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfilePort.DataModel
{
    public class Blog :Edit
    {
        public int BlogId { get; set; }
        public List<Post> Posts { get; set; } 


    }
}
