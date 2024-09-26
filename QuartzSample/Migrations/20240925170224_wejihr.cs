using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuartzSample.Migrations
{
    /// <inheritdoc />
    public partial class wejihr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Set",
                columns: table => new
                {
                    K = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    V = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Set", x => x.K);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Set");
        }
    }
}
