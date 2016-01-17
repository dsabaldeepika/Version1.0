using System;

namespace ProfilePort.DataModel
{
    public abstract class Edit
    {
        public DateTime ModifiedDateTime { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime CreateById { get; set; }
        public DateTime ModifiedById { get; set; }
    }
}