using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MilanCorp.Repository.Migrations
{
    public partial class eventoLeilao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "leilao",
                table: "Eventos");

            migrationBuilder.AddColumn<bool>(
                name: "ativo",
                table: "Aniversariantes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "EventosLeiloes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    start = table.Column<DateTime>(nullable: true),
                    nomeDoComitente = table.Column<string>(nullable: true),
                    observacao = table.Column<string>(nullable: true),
                    endereco = table.Column<string>(nullable: true),
                    tipoDeLeilao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventosLeiloes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventosLeiloes");

            migrationBuilder.DropColumn(
                name: "ativo",
                table: "Aniversariantes");

            migrationBuilder.AddColumn<string>(
                name: "leilao",
                table: "Eventos",
                nullable: true);
        }
    }
}
