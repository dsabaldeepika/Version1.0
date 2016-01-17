using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfilePort.DataModel
{
    public class Education : Edit
    {
        public int EducationId { get; set; }

        public string School { get; set; }
        public DateTime? DatesAttended { get; set; }
        public string FieldofStudy { get; set; }
        public char Grade { get; set; }
        public string Activities { get; set; }
        public string Description { get; set; }

        [ForeignKey("DashboardId")]
        public virtual Dashboard Dashboard { get; set; }
    }
}