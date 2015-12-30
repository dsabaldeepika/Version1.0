using System;

namespace Version1.DataModel
{
    public class Education :Edit
    {
        public int Id { get; set; }

        public string School { get; set; }
        public DateTime? DatesAttended { get; set; }
        public string FieldofStudy { get; set; }
        public char Grade { get; set; }

        public string DegreeReceived { get; set; }
        public string Activities { get; set; }
        public string Description { get; set; }
        
    }
}