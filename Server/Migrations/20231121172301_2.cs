using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parcial2_AP1_Randy.Server.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Pagar",
                table: "CobrosDetalle",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_CobrosDetalle_VentaId",
                table: "CobrosDetalle",
                column: "VentaId");

            migrationBuilder.AddForeignKey(
                name: "FK_CobrosDetalle_Ventas_VentaId",
                table: "CobrosDetalle",
                column: "VentaId",
                principalTable: "Ventas",
                principalColumn: "VentaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CobrosDetalle_Ventas_VentaId",
                table: "CobrosDetalle");

            migrationBuilder.DropIndex(
                name: "IX_CobrosDetalle_VentaId",
                table: "CobrosDetalle");

            migrationBuilder.DropColumn(
                name: "Pagar",
                table: "CobrosDetalle");
        }
    }
}
