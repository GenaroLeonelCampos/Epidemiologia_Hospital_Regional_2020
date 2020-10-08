using Microsoft.EntityFrameworkCore.Migrations;

namespace Epidemiologia.Data.Migrations
{
    public partial class procedimiento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var procedure = @"CREATE PROCEDURE usp_AgregMedic
                            @MedicamentoId INT,
                            @PerSalId INT,
                            @Fecha_Ingreso DATE =NULL ,
                            @Cantidad INT,
                            @Observacion VARCHAR(150)
                            AS
                            IF @Fecha_Ingreso IS NULL
                            BEGIN
                                SET @Fecha_Ingreso = GETDATE()
                            END
                            INSERT INTO AgregMedic VALUES(@MedicamentoId, @PerSalId, @Fecha_Ingreso, @Cantidad, @Observacion)
                            UPDATE Medicamento SET Saldo = Saldo + @Cantidad WHERE MedicamentoId = @MedicamentoId";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE usp_AgregMedic");
        }
    }
}
