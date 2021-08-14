using Microsoft.EntityFrameworkCore.Migrations;

namespace SQLHandler.Migrations
{
    public partial class Phase08Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentsDbContext",
                columns: table => new
                {
                    DocName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DocContents = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentsDbContext", x => x.DocName);
                });

            migrationBuilder.CreateTable(
                name: "WordsDbContext",
                columns: table => new
                {
                    eachWord = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordsDbContext", x => x.eachWord);
                });

            migrationBuilder.CreateTable(
                name: "DocumentWord",
                columns: table => new
                {
                    DocsCollectionDocName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    wordsCollectioneachWord = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentWord", x => new { x.DocsCollectionDocName, x.wordsCollectioneachWord });
                    table.ForeignKey(
                        name: "FK_DocumentWord_DocumentsDbContext_DocsCollectionDocName",
                        column: x => x.DocsCollectionDocName,
                        principalTable: "DocumentsDbContext",
                        principalColumn: "DocName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentWord_WordsDbContext_wordsCollectioneachWord",
                        column: x => x.wordsCollectioneachWord,
                        principalTable: "WordsDbContext",
                        principalColumn: "eachWord",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentWord_wordsCollectioneachWord",
                table: "DocumentWord",
                column: "wordsCollectioneachWord");
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
