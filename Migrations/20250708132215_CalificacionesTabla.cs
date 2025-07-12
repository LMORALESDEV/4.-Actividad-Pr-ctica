using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Actividad4LengPro3.Migrations
{
    /// <inheritdoc />
    public partial class CalificacionesTabla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calificaciones",
                columns: table => new
                {
                    MatriculaEstudiante = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    CodigoMateria = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Periodo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nota = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calificaciones", x => new { x.MatriculaEstudiante, x.CodigoMateria, x.Periodo });
                    table.ForeignKey(
                        name: "FK_Calificaciones_Estudiantes_MatriculaEstudiante",
                        column: x => x.MatriculaEstudiante,
                        principalTable: "Estudiantes",
                        principalColumn: "Matricula",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Calificaciones_Materias_CodigoMateria",
                        column: x => x.CodigoMateria,
                        principalTable: "Materias",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calificaciones_CodigoMateria",
                table: "Calificaciones",
                column: "CodigoMateria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calificaciones");
        }
    }
}
