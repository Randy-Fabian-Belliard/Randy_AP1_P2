using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parcial2_AP1_Randy.Server.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pagar",
                table: "CobrosDetalle");

            migrationBuilder.AddColumn<bool>(
                name: "Pagar",
                table: "Ventas",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "VentaId",
                keyValue: 1,
                column: "Pagar",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "VentaId",
                keyValue: 2,
                column: "Pagar",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "VentaId",
                keyValue: 3,
                column: "Pagar",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "VentaId",
                keyValue: 4,
                column: "Pagar",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "VentaId",
                keyValue: 5,
                column: "Pagar",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "VentaId",
                keyValue: 6,
                column: "Pagar",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pagar",
                table: "Ventas");

            migrationBuilder.AddColumn<bool>(
                name: "Pagar",
                table: "CobrosDetalle",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
