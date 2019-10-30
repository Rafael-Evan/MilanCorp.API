using Microsoft.EntityFrameworkCore.Migrations;

namespace MilanCorp.Repository.Migrations
{
    public partial class FeriasAtualziado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DataDaSolicitacao",
                table: "Ferias",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Expirar",
                table: "Ferias",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataDaSolicitacao",
                table: "Ferias");

            migrationBuilder.DropColumn(
                name: "Expirar",
                table: "Ferias");
        }
    }
}
