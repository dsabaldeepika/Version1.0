using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Website1.Models;

namespace Website1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasAnnotation("Relational:Name", "RoleNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasAnnotation("Relational:TableName", "AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasAnnotation("Relational:TableName", "AspNetUserRoles");
                });

            modelBuilder.Entity("Website1.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasAnnotation("Relational:Name", "EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasAnnotation("Relational:Name", "UserNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetUsers");
                });

            modelBuilder.Entity("Website1.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("By");

                    b.Property<int>("ById");

                    b.Property<string>("CommentContent");

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<DateTime>("CreatedById");

                    b.Property<int>("DashboardId");

                    b.Property<DateTime>("ModifiedById");

                    b.Property<DateTime>("ModifiedDateTime");

                    b.Property<string>("To");

                    b.Property<int>("ToId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Website1.Models.ContactInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<DateTime>("CreatedById");

                    b.Property<int>("DashboardId");

                    b.Property<string>("EmailAddress");

                    b.Property<string>("EmailAddress2");

                    b.Property<string>("FacebookUrl");

                    b.Property<string>("GoogleplusUrl");

                    b.Property<string>("HomeCity");

                    b.Property<string>("HomeState");

                    b.Property<string>("HomeStreetAddress");

                    b.Property<string>("HomeStreetAddress2");

                    b.Property<string>("HomeZipCode");

                    b.Property<string>("LinkedinUrl");

                    b.Property<string>("MainUrl");

                    b.Property<DateTime>("ModifiedById");

                    b.Property<DateTime>("ModifiedDateTime");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("PhoneNumber2");

                    b.Property<string>("TwitterUrl");

                    b.Property<string>("WorkCity");

                    b.Property<string>("WorkState");

                    b.Property<string>("WorkStreetAddress");

                    b.Property<string>("WorkStreetAddress2");

                    b.Property<string>("WorkZipCode");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Website1.Models.Dashboard", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("DashboardId");

                    b.Property<int>("DashboardId1");

                    b.Property<int>("DashboardId10");

                    b.Property<int>("DashboardId2");

                    b.Property<int>("DashboardId3");

                    b.Property<int>("DashboardId4");

                    b.Property<int>("DashboardId5");

                    b.Property<int>("DashboardId6");

                    b.Property<int>("DashboardId7");

                    b.Property<int>("DashboardId8");

                    b.Property<int>("DashboardId9");

                    b.Property<string>("Name");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Website1.Models.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Activities");

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<DateTime>("CreatedById");

                    b.Property<int>("DashboardId");

                    b.Property<DateTime?>("DatesAttended");

                    b.Property<string>("DegreeReceived");

                    b.Property<string>("Description");

                    b.Property<string>("FieldofStudy");

                    b.Property<char>("Grade");

                    b.Property<DateTime>("ModifiedById");

                    b.Property<DateTime>("ModifiedDateTime");

                    b.Property<string>("School");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Website1.Models.Favorite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<DateTime>("CreatedById");

                    b.Property<int>("DashboardId");

                    b.Property<string>("Description");

                    b.Property<DateTime>("ModifiedById");

                    b.Property<DateTime>("ModifiedDateTime");

                    b.Property<string>("Name");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Website1.Models.Interest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<DateTime>("CreatedById");

                    b.Property<int>("DashboardId");

                    b.Property<string>("Description");

                    b.Property<DateTime>("ModifiedById");

                    b.Property<DateTime>("ModifiedDateTime");

                    b.Property<string>("Name");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Website1.Models.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<DateTime>("CreatedById");

                    b.Property<int>("DashboardId");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("EndDate");

                    b.Property<string>("JobTitle");

                    b.Property<DateTime>("ModifiedById");

                    b.Property<DateTime>("ModifiedDateTime");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("YearsExperience");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Website1.Models.Layout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BackgroundColor");

                    b.Property<string>("BodyColor");

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<DateTime>("CreatedById");

                    b.Property<int>("DashboardId");

                    b.Property<string>("FooterColor");

                    b.Property<string>("HeaderColor");

                    b.Property<string>("LayoutName");

                    b.Property<DateTime>("ModifiedById");

                    b.Property<DateTime>("ModifiedDateTime");

                    b.Property<string>("NavigationBarColor");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Website1.Models.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("By");

                    b.Property<int>("ById");

                    b.Property<string>("CommentContent");

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<DateTime>("CreatedById");

                    b.Property<int>("DashboardId");

                    b.Property<DateTime>("ModifiedById");

                    b.Property<DateTime>("ModifiedDateTime");

                    b.Property<int?>("StatusId");

                    b.Property<string>("To");

                    b.Property<int>("ToId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Website1.Models.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<DateTime>("CreatedById");

                    b.Property<int>("DashboardId");

                    b.Property<DateTime>("ModifiedById");

                    b.Property<DateTime>("ModifiedDateTime");

                    b.Property<string>("NoteContent");

                    b.Property<string>("Title");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Website1.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<DateTime>("CreatedById");

                    b.Property<int>("DashboardId");

                    b.Property<string>("Description");

                    b.Property<DateTime>("ModifiedById");

                    b.Property<DateTime>("ModifiedDateTime");

                    b.Property<string>("Name");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Website1.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<DateTime>("CreatedById");

                    b.Property<int>("DashboardId");

                    b.Property<DateTime>("ModifiedById");

                    b.Property<DateTime>("ModifiedDateTime");

                    b.Property<string>("Title");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Website1.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Website1.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("Website1.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Website1.Models.Comment", b =>
                {
                    b.HasOne("Website1.Models.Dashboard")
                        .WithMany()
                        .HasForeignKey("DashboardId")
                        .HasPrincipalKey("DashboardId");
                });

            modelBuilder.Entity("Website1.Models.ContactInfo", b =>
                {
                    b.HasOne("Website1.Models.Dashboard")
                        .WithMany()
                        .HasForeignKey("DashboardId")
                        .HasPrincipalKey("DashboardId1");
                });

            modelBuilder.Entity("Website1.Models.Education", b =>
                {
                    b.HasOne("Website1.Models.Dashboard")
                        .WithMany()
                        .HasForeignKey("DashboardId")
                        .HasPrincipalKey("DashboardId2");
                });

            modelBuilder.Entity("Website1.Models.Favorite", b =>
                {
                    b.HasOne("Website1.Models.Dashboard")
                        .WithMany()
                        .HasForeignKey("DashboardId")
                        .HasPrincipalKey("DashboardId3");
                });

            modelBuilder.Entity("Website1.Models.Interest", b =>
                {
                    b.HasOne("Website1.Models.Dashboard")
                        .WithMany()
                        .HasForeignKey("DashboardId")
                        .HasPrincipalKey("DashboardId4");
                });

            modelBuilder.Entity("Website1.Models.Job", b =>
                {
                    b.HasOne("Website1.Models.Dashboard")
                        .WithMany()
                        .HasForeignKey("DashboardId")
                        .HasPrincipalKey("DashboardId5");
                });

            modelBuilder.Entity("Website1.Models.Layout", b =>
                {
                    b.HasOne("Website1.Models.Dashboard")
                        .WithMany()
                        .HasForeignKey("DashboardId")
                        .HasPrincipalKey("DashboardId6");
                });

            modelBuilder.Entity("Website1.Models.Like", b =>
                {
                    b.HasOne("Website1.Models.Dashboard")
                        .WithMany()
                        .HasForeignKey("DashboardId")
                        .HasPrincipalKey("DashboardId7");

                    b.HasOne("Website1.Models.Status")
                        .WithMany()
                        .HasForeignKey("StatusId");
                });

            modelBuilder.Entity("Website1.Models.Note", b =>
                {
                    b.HasOne("Website1.Models.Dashboard")
                        .WithMany()
                        .HasForeignKey("DashboardId")
                        .HasPrincipalKey("DashboardId8");
                });

            modelBuilder.Entity("Website1.Models.Skill", b =>
                {
                    b.HasOne("Website1.Models.Dashboard")
                        .WithMany()
                        .HasForeignKey("DashboardId")
                        .HasPrincipalKey("DashboardId9");
                });

            modelBuilder.Entity("Website1.Models.Status", b =>
                {
                    b.HasOne("Website1.Models.Dashboard")
                        .WithMany()
                        .HasForeignKey("DashboardId")
                        .HasPrincipalKey("DashboardId10");
                });
        }
    }
}
