using System;

namespace Website1.Models
{
    public class Like 
    {

        public DateTime ModifiedDateTime { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime CreatedById { get; set; }
        public DateTime ModifiedById { get; set; }
        public int Id { get; set; }
        public string To { get; set; }
        public int ToId { get; set; }
        public string By { get; set; }
        public int ById { get; set; }
        public string CommentContent { get; set; }
        public Status Status { get; set; }
    }
}