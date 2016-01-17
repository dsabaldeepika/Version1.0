﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfilePort.DataModel
{
    public class ContactInfo
    {
        public int ContactInfoId { get; set; }

        public string HomeStreetAddress { get; set; }
        public string HomeStreetAddress2 { get; set; }
        public string HomeCity { get; set; }
        public string HomeState { get; set; }
        public string HomeZipCode { get; set; }
        public string WorkStreetAddress { get; set; }
        public string WorkStreetAddress2 { get; set; }
        public string WorkCity { get; set; }
        public string WorkState { get; set; }
        public string WorkZipCode { get; set; }
        public string MainUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string LinkedinUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string GoogleplusUrl { get; set; }
        public string EmailAddress { get; set; }
        public string EmailAddress2 { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumber2 { get; set; }

        [ForeignKey("DashboardId")]
        public virtual Dashboard Dashboard { get; set; }
    }
}