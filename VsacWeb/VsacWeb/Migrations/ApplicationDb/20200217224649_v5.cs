using Microsoft.EntityFrameworkCore.Migrations;

namespace VsacWeb.Migrations.ApplicationDb
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "RaizUrlId",
                table: "Url",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RaizUrl",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaizUrl", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Url_RaizUrlId",
                table: "Url",
                column: "RaizUrlId");

            migrationBuilder.AddForeignKey(
                name: "FK_Url_RaizUrl_RaizUrlId",
                table: "Url",
                column: "RaizUrlId",
                principalTable: "RaizUrl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Url_RaizUrl_RaizUrlId",
                table: "Url");

            migrationBuilder.DropTable(
                name: "RaizUrl");

            migrationBuilder.DropIndex(
                name: "IX_Url_RaizUrlId",
                table: "Url");

            migrationBuilder.DropColumn(
                name: "RaizUrlId",
                table: "Url");
        }
    }
}
