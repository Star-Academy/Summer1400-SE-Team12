using Microsoft.EntityFrameworkCore.Migrations;

namespace Phase11_ASP.Migrations
{
    public partial class InvertedIndexMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentsDbContext",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocContents = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentsDbContext", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "WordsDbContext",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordsDbContext", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentWord",
                columns: table => new
                {
                    DocsCollectionid = table.Column<int>(type: "int", nullable: false),
                    wordsCollectionid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentWord", x => new { x.DocsCollectionid, x.wordsCollectionid });
                    table.ForeignKey(
                        name: "FK_DocumentWord_DocumentsDbContext_DocsCollectionid",
                        column: x => x.DocsCollectionid,
                        principalTable: "DocumentsDbContext",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentWord_WordsDbContext_wordsCollectionid",
                        column: x => x.wordsCollectionid,
                        principalTable: "WordsDbContext",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentWord_wordsCollectionid",
                table: "DocumentWord",
                column: "wordsCollectionid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentWord");

            migrationBuilder.DropTable(
                name: "DocumentsDbContext");

            migrationBuilder.DropTable(
                name: "WordsDbContext");
        }
    }
}
