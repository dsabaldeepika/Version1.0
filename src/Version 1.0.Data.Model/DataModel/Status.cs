using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfilePort.DataModel
{
    public class Status : Edit
    {
        public int StatusId { get; set; }
        public string Title { get; set; }
        public virtual List<Like> LikesList { get; set; }
        public virtual List<Comment> CommentsList { get; set; }
        
        [ForeignKey("DashboardId")]
        public virtual Dashboard Dashboard { get; set; }
    }
}
