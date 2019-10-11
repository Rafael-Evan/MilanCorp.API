using Microsoft.EntityFrameworkCore.Migrations;

namespace MilanCorp.Repository.Migrations
{
    public partial class reuniaoatt2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Reunioes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reunioes_UserId",
                table: "Reunioes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reunioes_AspNetUsers_UserId",
                table: "Reunioes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reunioes_AspNetUsers_UserId",
                table: "Reunioes");

            migrationBuilder.DropIndex(
                name: "IX_Reunioes_UserId",
                table: "Reunioes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Reunioes");
        }
    }
}
