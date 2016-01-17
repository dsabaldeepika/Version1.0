using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfilePort.DataModel
{
    public class Profile
    {
        public int ProfileId { get; set; }
        public string Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string SocialSecurity { get; set; }
        public string PicFile { get; set; }
        public bool IsLookingForJob { get; set; }
    }
}