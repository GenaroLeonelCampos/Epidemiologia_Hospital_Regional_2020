using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Epidemiologia.Data.Migrations
{
    public partial class Leonel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responsable_Departamento_DepartamentoId",
                table: "Responsable");

            migrationBuilder.DropForeignKey(
                name: "FK_Responsable_Distrito_DistritoId",
                table: "Responsable");

            migrationBuilder.DropForeignKey(
                name: "FK_Responsable_Profesion_ProfesionId",
                table: "Responsable");

            migrationBuilder.DropForeignKey(
                name: "FK_Responsable_Provincia_ProvinciaId",
                table: "Responsable");

            migrationBuilder.DropForeignKey(
                name: "FK_Responsable_Tipdoc_TipdocId",
                table: "Responsable");

            migrationBuilder.DropForeignKey(
                name: "FK_Responsable_UnidLab_UnidLabId",
                table: "Responsable");

            migrationBuilder.DropTable(
                name: "Ingresos");

            migrationBuilder.DropTable(
                name: "IngresosL");

            migrationBuilder.DropTable(
                name: "MedicamentoL");

            migrationBuilder.DropTable(
                name: "Salidas");

            migrationBuilder.DropTable(
                name: "SalidasL");

            migrationBuilder.DropColumn(
                name: "Apellidos",
                table: "Responsable");

            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Responsable");

            migrationBuilder.DropColumn(
                name: "Condicion",
                table: "Responsable");

            migrationBuilder.DropColumn(
                name: "Correo",
                table: "Responsable");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Responsable");

            migrationBuilder.DropColumn(
                name: "NdocIden",
                table: "Responsable");

            migrationBuilder.DropColumn(
                name: "Nombres",
                table: "Responsable");

            migrationBuilder.AlterColumn<int>(
                name: "UnidLabId",
                table: "Responsable",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TipdocId",
                table: "Responsable",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProvinciaId",
                table: "Responsable",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProfesionId",
                table: "Responsable",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DistritoId",
                table: "Responsable",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoId",
                table: "Responsable",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Responsable",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha_Ingreso",
                table: "Responsable",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PerSalId",
                table: "Responsable",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NdocIden",
                table: "PerSal",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                name: "Observacion",
                table: "Medicamento",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "AgregMedic",
                columns: table => new
                {
                    AgregMedicId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicamentoId = table.Column<int>(nullable: false),
                    PerSalId = table.Column<int>(nullable: false),
                    Fecha_Ingreso = table.Column<DateTime>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Observacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgregMedic", x => x.AgregMedicId);
                });

            migrationBuilder.CreateTable(
                name: "SalidMedic",
                columns: table => new
                {
                    SalidMedicId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicamentoId = table.Column<int>(nullable: false),
                    ResponsableId = table.Column<int>(nullable: false),
                    CartservId = table.Column<int>(nullable: false),
                    PerSalId = table.Column<int>(nullable: false),
                    PertenenciaId = table.Column<int>(nullable: false),
                    Fecha_salida = table.Column<DateTime>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Observacion = table.Column<string>(nullable: true),
                    Estado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalidMedic", x => x.SalidMedicId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Responsable_Departamento_DepartamentoId",
                table: "Responsable",
                column: "DepartamentoId",
                principalTable: "Departamento",
                principalColumn: "DepartamentoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Responsable_Distrito_DistritoId",
                table: "Responsable",
                column: "DistritoId",
                principalTable: "Distrito",
                principalColumn: "DistritoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Responsable_Profesion_ProfesionId",
                table: "Responsable",
                column: "ProfesionId",
                principalTable: "Profesion",
                principalColumn: "ProfesionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Responsable_Provincia_ProvinciaId",
                table: "Responsable",
                column: "ProvinciaId",
                principalTable: "Provincia",
                principalColumn: "ProvinciaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Responsable_Tipdoc_TipdocId",
                table: "Responsable",
                column: "TipdocId",
                principalTable: "Tipdoc",
                principalColumn: "TipdocId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Responsable_UnidLab_UnidLabId",
                table: "Responsable",
                column: "UnidLabId",
                principalTable: "UnidLab",
                principalColumn: "UnidLabId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responsable_Departamento_DepartamentoId",
                table: "Responsable");

            migrationBuilder.DropForeignKey(
                name: "FK_Responsable_Distrito_DistritoId",
                table: "Responsable");

            migrationBuilder.DropForeignKey(
                name: "FK_Responsable_Profesion_ProfesionId",
                table: "Responsable");

            migrationBuilder.DropForeignKey(
                name: "FK_Responsable_Provincia_ProvinciaId",
                table: "Responsable");

            migrationBuilder.DropForeignKey(
                name: "FK_Responsable_Tipdoc_TipdocId",
                table: "Responsable");

            migrationBuilder.DropForeignKey(
                name: "FK_Responsable_UnidLab_UnidLabId",
                table: "Responsable");

            migrationBuilder.DropTable(
                name: "AgregMedic");

            migrationBuilder.DropTable(
                name: "SalidMedic");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Responsable");

            migrationBuilder.DropColumn(
                name: "Fecha_Ingreso",
                table: "Responsable");

            migrationBuilder.DropColumn(
                name: "PerSalId",
                table: "Responsable");

            migrationBuilder.AlterColumn<int>(
                name: "UnidLabId",
                table: "Responsable",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TipdocId",
                table: "Responsable",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProvinciaId",
                table: "Responsable",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProfesionId",
                table: "Responsable",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DistritoId",
                table: "Responsable",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoId",
                table: "Responsable",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Apellidos",
                table: "Responsable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "Responsable",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Condicion",
                table: "Responsable",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Correo",
                table: "Responsable",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Responsable",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NdocIden",
                table: "Responsable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nombres",
                table: "Responsable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "NdocIden",
                table: "PerSal",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                name: "Observacion",
                table: "Medicamento",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Ingresos",
                columns: table => new
                {
                    IngresosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: true),
                    Fecha_Ingreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MedicamentoId = table.Column<int>(type: "int", nullable: true),
                    Observacion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ResponsableId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingresos", x => x.IngresosId);
                    table.ForeignKey(
                        name: "FK_Ingresos_Medicamento_MedicamentoId",
                        column: x => x.MedicamentoId,
                        principalTable: "Medicamento",
                        principalColumn: "MedicamentoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ingresos_Responsable_ResponsableId",
                        column: x => x.ResponsableId,
                        principalTable: "Responsable",
                        principalColumn: "ResponsableId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IngresosL",
                columns: table => new
                {
                    IngresosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Fecha_Ingreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Medicamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicamentoId = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Responsable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponsableId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngresosL", x => x.IngresosId);
                });

            migrationBuilder.CreateTable(
                name: "MedicamentoL",
                columns: table => new
                {
                    MedicamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cod_sismed = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Concentracion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Denominacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha_Ingreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Presentacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Saldo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicamentoL", x => x.MedicamentoId);
                });

            migrationBuilder.CreateTable(
                name: "Salidas",
                columns: table => new
                {
                    SalidasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    CartservId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: true),
                    FechaDistrib = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MedicamentoId = table.Column<int>(type: "int", nullable: false),
                    PerSalId = table.Column<int>(type: "int", nullable: false),
                    PertenenciaId = table.Column<int>(type: "int", nullable: false),
                    ResponsableId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salidas", x => x.SalidasId);
                });

            migrationBuilder.CreateTable(
                name: "SalidasL",
                columns: table => new
                {
                    SalidasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    CartservId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: true),
                    FechaDistrib = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Medicamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicamentoId = table.Column<int>(type: "int", nullable: false),
                    PerSalId = table.Column<int>(type: "int", nullable: false),
                    Pertenencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PertenenciaId = table.Column<int>(type: "int", nullable: false),
                    Recepcionante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Responsable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponsableId = table.Column<int>(type: "int", nullable: false),
                    Servicio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalidasL", x => x.SalidasId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingresos_MedicamentoId",
                table: "Ingresos",
                column: "MedicamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingresos_ResponsableId",
                table: "Ingresos",
                column: "ResponsableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Responsable_Departamento_DepartamentoId",
                table: "Responsable",
                column: "DepartamentoId",
                principalTable: "Departamento",
                principalColumn: "DepartamentoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Responsable_Distrito_DistritoId",
                table: "Responsable",
                column: "DistritoId",
                principalTable: "Distrito",
                principalColumn: "DistritoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Responsable_Profesion_ProfesionId",
                table: "Responsable",
                column: "ProfesionId",
                principalTable: "Profesion",
                principalColumn: "ProfesionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Responsable_Provincia_ProvinciaId",
                table: "Responsable",
                column: "ProvinciaId",
                principalTable: "Provincia",
                principalColumn: "ProvinciaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Responsable_Tipdoc_TipdocId",
                table: "Responsable",
                column: "TipdocId",
                principalTable: "Tipdoc",
                principalColumn: "TipdocId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Responsable_UnidLab_UnidLabId",
                table: "Responsable",
                column: "UnidLabId",
                principalTable: "UnidLab",
                principalColumn: "UnidLabId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
