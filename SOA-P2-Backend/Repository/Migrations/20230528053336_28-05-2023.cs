using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class _28052023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    curp = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    birth_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.curp);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_people = table.Column<string>(type: "nvarchar(18)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_hire = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.id);
                    table.ForeignKey(
                        name: "FK_Empleados_Personas_id_people",
                        column: x => x.id_people,
                        principalTable: "Personas",
                        principalColumn: "curp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Activo_Empleado",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_empleoyee = table.Column<int>(type: "int", nullable: false),
                    id_activo = table.Column<int>(type: "int", nullable: false),
                    assignment_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    release_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    delivery_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activo_Empleado", x => x.id);
                    table.ForeignKey(
                        name: "FK_Activo_Empleado_Activos_id_activo",
                        column: x => x.id_activo,
                        principalTable: "Activos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activo_Empleado_Empleados_id_empleoyee",
                        column: x => x.id_empleoyee,
                        principalTable: "Empleados",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activo_Empleado_id_activo",
                table: "Activo_Empleado",
                column: "id_activo");

            migrationBuilder.CreateIndex(
                name: "IX_Activo_Empleado_id_empleoyee",
                table: "Activo_Empleado",
                column: "id_empleoyee");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_id_people",
                table: "Empleados",
                column: "id_people");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activo_Empleado");

            migrationBuilder.DropTable(
                name: "Activos");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
