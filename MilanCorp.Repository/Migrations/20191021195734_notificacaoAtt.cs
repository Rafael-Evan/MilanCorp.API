using Microsoft.EntityFrameworkCore.Migrations;

namespace MilanCorp.Repository.Migrations
{
    public partial class notificacaoAtt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataInicio",
                table: "Notificacoes",
                newName: "DataDaSolicitação");

            migrationBuilder.RenameColumn(
                name: "DataFim",
                table: "Notificacoes",
                newName: "Data");

            migrationBuilder.AddColumn<int>(
                name: "Expirar",
                table: "Notificacoes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Expirar",
                table: "Notificacoes");

            migrationBuilder.RenameColumn(
                name: "DataDaSolicitação",
                table: "Notificacoes",
                newName: "DataInicio");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Notificacoes",
                newName: "DataFim");
        }
    }
}
