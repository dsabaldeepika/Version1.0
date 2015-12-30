using System;

namespace Version1.DataModel
{
    public class Profile : Edit
    {
        public int Id { get; set; }
        public string Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string SocialSecurity { get; set; }
        public string PicFile { get; set; }
        public bool IsLookingForJob { get; set; }
        
    }
}