using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EComunidadeAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    IdEvento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TituloEvento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescricaoEvento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataEvento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoraEvento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QtVoluntarios = table.Column<int>(type: "int", nullable: false),
                    DuracaoEvento = table.Column<int>(type: "int", nullable: false),
                    PontuacaoEvento = table.Column<int>(type: "int", nullable: false),
                    LocalEvento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Situacao = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.IdEvento);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eventos");
        }
    }
}
