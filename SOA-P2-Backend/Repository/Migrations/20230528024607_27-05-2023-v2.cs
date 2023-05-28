using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class _27052023v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Activoid",
                table: "Activo_Empleado",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Empleadoid",
                table: "Activo_Empleado",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Activo_Empleado_Activoid",
                table: "Activo_Empleado",
                column: "Activoid");

            migrationBuilder.CreateIndex(
                name: "IX_Activo_Empleado_Empleadoid",
                table: "Activo_Empleado",
                column: "Empleadoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Activo_Empleado_Activos_Activoid",
                table: "Activo_Empleado",
                column: "Activoid",
                principalTable: "Activos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Activo_Empleado_Empleados_Empleadoid",
                table: "Activo_Empleado",
                column: "Empleadoid",
                principalTable: "Empleados",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activo_Empleado_Activos_Activoid",
                table: "Activo_Empleado");

            migrationBuilder.DropForeignKey(
                name: "FK_Activo_Empleado_Empleados_Empleadoid",
                table: "Activo_Empleado");

            migrationBuilder.DropIndex(
                name: "IX_Activo_Empleado_Activoid",
                table: "Activo_Empleado");

            migrationBuilder.DropIndex(
                name: "IX_Activo_Empleado_Empleadoid",
                table: "Activo_Empleado");

            migrationBuilder.DropColumn(
                name: "Activoid",
                table: "Activo_Empleado");

            migrationBuilder.DropColumn(
                name: "Empleadoid",
                table: "Activo_Empleado");
        }
    }
}
