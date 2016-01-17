using System;

namespace Website1.Models
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