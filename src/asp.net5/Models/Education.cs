using System;

namespace asp.net5.Models
{
    public class Education :Edit
    {
        public int Id { get; set; }

        public string School { get; set; }
        public DateTime? DatesAttended { get; set; }
        public string FieldofStudy { get; set; }
        public string Grade { get; set; }

        public string DegreeReceived { get; set; }
        public string Activities { get; set; }
        public string Description { get; set; }
        
    }
}