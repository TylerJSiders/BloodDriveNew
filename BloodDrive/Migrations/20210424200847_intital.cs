using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodDrive.Migrations
{
    public partial class intital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BloodTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Donators",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<long>(type: "bigint", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Elligible = table.Column<bool>(type: "bit", nullable: false),
                    BloodTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donators", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Donators_BloodTypes_BloodTypeID",
                        column: x => x.BloodTypeID,
                        principalTable: "BloodTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donators_BloodTypeID",
                table: "Donators",
                column: "BloodTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donators");

            migrationBuilder.DropTable(
                name: "BloodTypes");
        }
    }
}
