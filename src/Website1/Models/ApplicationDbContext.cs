using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Website1.Models;

namespace Website1.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

        }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<ContactInfo> ContactInfo { get; set; }
        public DbSet<Dashboard> Dashboard { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<Favorite> Favorite { get; set; }
        public DbSet<Interest> Interest { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<Like> Like { get; set; }
        public DbSet<Layout> Layout { get; set; }
        public DbSet<Note> Note { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Skill> Skill { get; set; }
       
    }
}
