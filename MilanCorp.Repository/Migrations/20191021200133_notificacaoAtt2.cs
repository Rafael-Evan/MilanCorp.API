using Microsoft.EntityFrameworkCore.Migrations;

namespace MilanCorp.Repository.Migrations
{
    public partial class notificacaoAtt2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataDaSolicitação",
                table: "Notificacoes",
                newName: "DataDaSolicitacao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataDaSolicitacao",
                table: "Notificacoes",
                newName: "DataDaSolicitação");
        }
    }
}
