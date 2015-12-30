using System;
using Microsoft.Data.Entity.Metadata.Internal;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Version1.DataModel
{
    public abstract class Edit
    {
        public DateTime ModifiedDateTime { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime CreatedById { get; set; }
        public DateTime ModifiedById { get; set; }

        [Required]
        public int DashboardId { get; set; }

        [ForeignKey("DashboardId")]
        public virtual Dashboard Dashboard { get; set; }

    }
}