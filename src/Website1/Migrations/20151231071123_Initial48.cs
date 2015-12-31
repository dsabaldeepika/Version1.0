using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace Website1.Migrations
{
    public partial class Initial48 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_ApplicationUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_ContactInfo_Dashboard_DashboardId", table: "ContactInfo");
            migrationBuilder.DropForeignKey(name: "FK_Education_Dashboard_DashboardId", table: "Education");
            migrationBuilder.DropForeignKey(name: "FK_Favorite_Dashboard_DashboardId", table: "Favorite");
            migrationBuilder.DropForeignKey(name: "FK_Interest_Dashboard_DashboardId", table: "Interest");
            migrationBuilder.DropForeignKey(name: "FK_Job_Dashboard_DashboardId", table: "Job");
            migrationBuilder.DropForeignKey(name: "FK_Layout_Dashboard_DashboardId", table: "Layout");
            migrationBuilder.DropForeignKey(name: "FK_Like_Dashboard_DashboardId", table: "Like");
            migrationBuilder.DropForeignKey(name: "FK_Note_Dashboard_DashboardId", table: "Note");
            migrationBuilder.DropForeignKey(name: "FK_Skill_Dashboard_DashboardId", table: "Skill");
            migrationBuilder.DropForeignKey(name: "FK_Status_Dashboard_DashboardId", table: "Status");
            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    By = table.Column<string>(nullable: true),
                    ById = table.Column<int>(nullable: false),
                    CommentContent = table.Column<string>(nullable: true),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<DateTime>(nullable: false),
                    DashboardId = table.Column<int>(nullable: false),
                    ModifiedById = table.Column<DateTime>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(nullable: false),
                    To = table.Column<string>(nullable: true),
                    ToId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Dashboard_DashboardId",
                        column: x => x.DashboardId,
                        principalTable: "Dashboard",
                        principalColumn: "DashboardId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.AddColumn<int>(
                name: "DashboardId10",
                table: "Dashboard",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Dashboard_DashboardId10",
                table: "Dashboard",
                column: "DashboardId10");
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_ApplicationUser_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_ContactInfo_Dashboard_DashboardId",
                table: "ContactInfo",
                column: "DashboardId",
                principalTable: "Dashboard",
                principalColumn: "DashboardId1",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Education_Dashboard_DashboardId",
                table: "Education",
                column: "DashboardId",
                principalTable: "Dashboard",
                principalColumn: "DashboardId2",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Favorite_Dashboard_DashboardId",
                table: "Favorite",
                column: "DashboardId",
                principalTable: "Dashboard",
                principalColumn: "DashboardId3",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Interest_Dashboard_DashboardId",
                table: "Interest",
                column: "DashboardId",
                principalTable: "Dashboard",
                principalColumn: "DashboardId4",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Job_Dashboard_DashboardId",
                table: "Job",
                column: "DashboardId",
                principalTable: "Dashboard",
                principalColumn: "DashboardId5",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Layout_Dashboard_DashboardId",
                table: "Layout",
                column: "DashboardId",
                principalTable: "Dashboard",
                principalColumn: "DashboardId6",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Like_Dashboard_DashboardId",
                table: "Like",
                column: "DashboardId",
                principalTable: "Dashboard",
                principalColumn: "DashboardId7",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Note_Dashboard_DashboardId",
                table: "Note",
                column: "DashboardId",
                principalTable: "Dashboard",
                principalColumn: "DashboardId8",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Dashboard_DashboardId",
                table: "Skill",
                column: "DashboardId",
                principalTable: "Dashboard",
                principalColumn: "DashboardId9",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Status_Dashboard_DashboardId",
                table: "Status",
                column: "DashboardId",
                principalTable: "Dashboard",
                principalColumn: "DashboardId10",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_ApplicationUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_ContactInfo_Dashboard_DashboardId", table: "ContactInfo");
            migrationBuilder.DropForeignKey(name: "FK_Education_Dashboard_DashboardId", table: "Education");
            migrationBuilder.DropForeignKey(name: "FK_Favorite_Dashboard_DashboardId", table: "Favorite");
            migrationBuilder.DropForeignKey(name: "FK_Interest_Dashboard_DashboardId", table: "Interest");
            migrationBuilder.DropForeignKey(name: "FK_Job_Dashboard_DashboardId", table: "Job");
            migrationBuilder.DropForeignKey(name: "FK_Layout_Dashboard_DashboardId", table: "Layout");
            migrationBuilder.DropForeignKey(name: "FK_Like_Dashboard_DashboardId", table: "Like");
            migrationBuilder.DropForeignKey(name: "FK_Note_Dashboard_DashboardId", table: "Note");
            migrationBuilder.DropForeignKey(name: "FK_Skill_Dashboard_DashboardId", table: "Skill");
            migrationBuilder.DropForeignKey(name: "FK_Status_Dashboard_DashboardId", table: "Status");
            migrationBuilder.DropUniqueConstraint(name: "AK_Dashboard_DashboardId10", table: "Dashboard");
            migrationBuilder.DropColumn(name: "DashboardId10", table: "Dashboard");
            migrationBuilder.DropTable("Comment");
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_ApplicationUser_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_ContactInfo_Dashboard_DashboardId",
                table: "ContactInfo",
                column: "DashboardId",
                principalTable: "Dashboard",
                principalColumn: "DashboardId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Education_Dashboard_DashboardId",
                table: "Education",
                column: "DashboardId",
                principalTable: "Dashboard",
                principalColumn: "DashboardId1",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Favorite_Dashboard_DashboardId",
                table: "Favorite",
                column: "DashboardId",
                principalTable: "Dashboard",
                principalColumn: "DashboardId2",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Interest_Dashboard_DashboardId",
                table: "Interest",
                column: "DashboardId",
                principalTable: "Dashboard",
                principalColumn: "DashboardId3",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Job_Dashboard_DashboardId",
                table: "Job",
                column: "DashboardId",
                principalTable: "Dashboard",
                principalColumn: "DashboardId4",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Layout_Dashboard_DashboardId",
                table: "Layout",
                column: "DashboardId",
                principalTable: "Dashboard",
                principalColumn: "DashboardId5",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Like_Dashboard_DashboardId",
                table: "Like",
                column: "DashboardId",
                principalTable: "Dashboard",
                principalColumn: "DashboardId6",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Note_Dashboard_DashboardId",
                table: "Note",
                column: "DashboardId",
                principalTable: "Dashboard",
                principalColumn: "DashboardId7",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Dashboard_DashboardId",
                table: "Skill",
                column: "DashboardId",
                principalTable: "Dashboard",
                principalColumn: "DashboardId8",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Status_Dashboard_DashboardId",
                table: "Status",
                column: "DashboardId",
                principalTable: "Dashboard",
                principalColumn: "DashboardId9",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
