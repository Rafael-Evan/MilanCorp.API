using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MilanCorp.Repository.Migrations
{
    public partial class recebimentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recebimentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Remetente = table.Column<string>(nullable: true),
                    NumeroDeRastreamento = table.Column<string>(nullable: true),
                    Quantidade = table.Column<int>(nullable: false),
                    DataDoRecebimento = table.Column<DateTime>(nullable: false),
                    RecebidoPor = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recebimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recebimentos_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recebimentos_UserId",
                table: "Recebimentos",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recebimentos");
        }
    }
}
