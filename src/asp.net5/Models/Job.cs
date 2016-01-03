using System;


namespace asp.net5.Models
{
    public class Job :Edit
    {
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public string Description { get; set; }
        public int YearsExperience { get; set; }
        
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}