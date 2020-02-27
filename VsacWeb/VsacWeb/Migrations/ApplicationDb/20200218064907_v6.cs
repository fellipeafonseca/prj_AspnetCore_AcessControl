using Microsoft.EntityFrameworkCore.Migrations;

namespace VsacWeb.Migrations.ApplicationDb
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Url_RaizUrl_RaizUrlId",
                table: "Url");

            migrationBuilder.AlterColumn<long>(
                name: "RaizUrlId",
                table: "Url",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Url_RaizUrl_RaizUrlId",
                table: "Url",
                column: "RaizUrlId",
                principalTable: "RaizUrl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Url_RaizUrl_RaizUrlId",
                table: "Url");

            migrationBuilder.AlterColumn<long>(
                name: "RaizUrlId",
                table: "Url",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Url_RaizUrl_RaizUrlId",
                table: "Url",
                column: "RaizUrlId",
                principalTable: "RaizUrl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
