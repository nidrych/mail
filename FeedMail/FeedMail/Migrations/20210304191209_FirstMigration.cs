using Microsoft.EntityFrameworkCore.Migrations;

namespace FeedMail.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FeedReceivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedReceivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeedReceiverId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rss_FeedReceivers_FeedReceiverId",
                        column: x => x.FeedReceiverId,
                        principalTable: "FeedReceivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rss_FeedReceiverId",
                table: "Rss",
                column: "FeedReceiverId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rss");

            migrationBuilder.DropTable(
                name: "FeedReceivers");
        }
    }
}
