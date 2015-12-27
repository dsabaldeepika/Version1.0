using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfilePort.DataModel
{
    public class Favorite : Edit
    {
        public int FavoriteId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        [ForeignKey("DashboardId")]
        public virtual Dashboard Dashboard { get; set; }
    }
}