using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IoTDevice.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    SerialNumber = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HasOutsideTemperature = table.Column<bool>(nullable: false),
                    DeviceStartTime = table.Column<DateTime>(nullable: false),
                    IsOperational = table.Column<bool>(nullable: false),
                    SilentMode = table.Column<bool>(nullable: false),
                    MachineIsBroken = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.SerialNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Device");
        }
    }
}
