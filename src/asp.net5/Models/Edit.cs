using System;

namespace asp.net5.Models
{
    public abstract class Edit
    {
        public DateTime ModifiedDateTime { get; set; }
        public DateTime CreateDateTime { get; set; }
        public int CreatedById { get; set; }
        public int ModifiedById { get; set; }
        
        public virtual Dashboard Dashboard { get; set; }

    }
}