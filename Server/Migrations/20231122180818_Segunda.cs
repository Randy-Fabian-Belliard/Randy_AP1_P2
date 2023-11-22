using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parcial2_AP1_Randy.Server.Migrations
{
    /// <inheritdoc />
    public partial class Segunda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pagar",
                table: "CobrosDetalle");

            migrationBuilder.AlterColumn<int>(
                name: "TotalFacturas",
                table: "CobrosDetalle",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<int>(
                name: "TotalCobrado",
                table: "CobrosDetalle",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "TotalFacturas",
                table: "CobrosDetalle",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<double>(
                name: "TotalCobrado",
                table: "CobrosDetalle",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<bool>(
                name: "Pagar",
                table: "CobrosDetalle",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
