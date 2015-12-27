using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfilePort.DataModel
{
    public class Job :Edit
    {
        public int JobId { get; set; }
        public string JobTitle { get; set; }
        public string Description { get; set; }
        public int YearsExperience { get; set; }
        
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [ForeignKey("DashboardId")]
        public virtual Dashboard Dashboard { get; set; }
    }
}