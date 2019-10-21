using Microsoft.EntityFrameworkCore.Migrations;

namespace MilanCorp.Repository.Migrations
{
    public partial class ReuniaoAttVars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "sala",
                table: "Reunioes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "local",
                table: "Reunioes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(75)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "sala",
                table: "Reunioes",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "local",
                table: "Reunioes",
                type: "nvarchar(75)",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
