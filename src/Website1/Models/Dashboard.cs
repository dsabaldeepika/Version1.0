

using System.Collections.Generic;

namespace Website1.Models
{
    public class Dashboard
    {
       
        public string DashboardId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Status> Statuses { get; set; }
        public virtual ICollection<Layout> Layouts { get; set; }
        public virtual ICollection<Education> Educations { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
        

    }
}