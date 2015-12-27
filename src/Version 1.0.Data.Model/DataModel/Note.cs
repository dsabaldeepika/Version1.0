using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfilePort.DataModel
{
    public class Note : Edit
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string NoteContent { get; set; }
      
        [ForeignKey("DashboardId")]
        public virtual Dashboard Dashboard { get; set; }
    }
}