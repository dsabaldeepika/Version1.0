using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfilePort.DataModel
{
    public class Skill : Edit
    {
        public int SkillId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public string DashboardId { get; set; }

        [ForeignKey("DashboardId")]
        public virtual Dashboard Dashboard { get; set; }
    }
}