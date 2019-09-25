using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MilanCorp.Repository.Migrations
{
    public partial class updateEventos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dataDoLeilao",
                table: "Eventos");

            migrationBuilder.AddColumn<string>(
                name: "endereco",
                table: "Eventos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "observacao",
                table: "Eventos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "endereco",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "observacao",
                table: "Eventos");

            migrationBuilder.AddColumn<DateTime>(
                name: "dataDoLeilao",
                table: "Eventos",
                nullable: true);
        }
    }
}
