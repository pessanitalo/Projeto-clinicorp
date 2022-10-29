using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CliniCorp.Migrations
{
    public partial class correcao_entidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MedicoEspecialista",
                table: "Consultas");

            migrationBuilder.AlterColumn<string>(
                name: "Especializacao",
                table: "Medicos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Especializacao",
                table: "Medicos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedicoEspecialista",
                table: "Consultas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
