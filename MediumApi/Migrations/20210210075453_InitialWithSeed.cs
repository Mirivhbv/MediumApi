using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MediumApi.Migrations
{
    public partial class InitialWithSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { new Guid("9f35b48d-cb87-4783-bfdb-21e36012930a"), "There are should be text consist of lorem ipsum", "Let's build several projects" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { new Guid("bffcf83a-0224-4a7c-a278-5aae00a02c1e"), "Hello world, second chance to get a chance", "Sort of" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
