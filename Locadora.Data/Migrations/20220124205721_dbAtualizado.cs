using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Locadora.Data.Migrations
{
    public partial class dbAtualizado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Generos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Filmes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Diretores",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Generos_Nome",
                table: "Generos",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Filmes_Nome",
                table: "Filmes",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Diretores_Nome",
                table: "Diretores",
                column: "Nome",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Generos_Nome",
                table: "Generos");

            migrationBuilder.DropIndex(
                name: "IX_Filmes_Nome",
                table: "Filmes");

            migrationBuilder.DropIndex(
                name: "IX_Diretores_Nome",
                table: "Diretores");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Generos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Filmes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Diretores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
