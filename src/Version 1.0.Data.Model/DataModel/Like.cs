using System.ComponentModel.DataAnnotations.Schema;

namespace ProfilePort.DataModel
{
    public class Like : Edit
    {
        public int CommentId { get; set; }
        public string To { get; set; }
        public int ToId { get; set; }
        public string By { get; set; }
        public int ById { get; set; }
        public string CommentContent { get; set; }

        [ForeignKey("DashboardId")]
        public virtual Dashboard Dashboard { get; set; }
    }
}