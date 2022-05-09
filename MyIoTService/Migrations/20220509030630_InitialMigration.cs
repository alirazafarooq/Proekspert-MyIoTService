using Microsoft.EntityFrameworkCore.Migrations;

namespace MyIoTService.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EndUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    SerialNumber = table.Column<int>(nullable: false),
                    InsideTemperature = table.Column<int>(nullable: false),
                    OutsideTemperature = table.Column<int>(nullable: false),
                    HasOutsideTemperature = table.Column<bool>(nullable: false),
                    WaterTemperature = table.Column<int>(nullable: false),
                    OperationTimeInSec = table.Column<int>(nullable: false),
                    OperationTimeInHour = table.Column<int>(nullable: false),
                    IsOperational = table.Column<bool>(nullable: false),
                    SilentMode = table.Column<bool>(nullable: false),
                    MachineIsBroken = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.SerialNumber);
                    table.ForeignKey(
                        name: "FK_Devices_EndUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "EndUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EndUsers",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { 1, "Muhammad", "Zubair", "admin", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Devices_UserId",
                table: "Devices",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "EndUsers");
        }
    }
}
