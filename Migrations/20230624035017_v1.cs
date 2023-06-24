using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UberEats.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    DriverID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.DriverID);
                });

            migrationBuilder.CreateTable(
                name: "Partners",
                columns: table => new
                {
                    PartnerID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BusinessName = table.Column<string>(type: "TEXT", nullable: false),
                    BusinessAddress = table.Column<string>(type: "TEXT", nullable: false),
                    BusinessEmail = table.Column<string>(type: "TEXT", nullable: false),
                    BusinessPhone = table.Column<string>(type: "TEXT", nullable: false),
                    DriverID = table.Column<int>(type: "INTEGER", nullable: false),
                    LogoImage = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.PartnerID);
                    table.ForeignKey(
                        name: "FK_Partners_Drivers_DriverID",
                        column: x => x.DriverID,
                        principalTable: "Drivers",
                        principalColumn: "DriverID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "DriverID", "Name" },
                values: new object[] { 1, "Restaurant" });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "DriverID", "Name" },
                values: new object[] { 2, "Grocery" });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "DriverID", "Name" },
                values: new object[] { 3, "Alcohol" });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "DriverID", "Name" },
                values: new object[] { 4, "Convienience" });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "DriverID", "Name" },
                values: new object[] { 5, "Flower shop" });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "DriverID", "Name" },
                values: new object[] { 6, "Pet Store" });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "DriverID", "Name" },
                values: new object[] { 7, "retail" });

            migrationBuilder.InsertData(
                table: "Partners",
                columns: new[] { "PartnerID", "BusinessAddress", "BusinessEmail", "BusinessName", "BusinessPhone", "DriverID", "LogoImage" },
                values: new object[] { 1, "Chicago, 3001", "intial@gmail.com", "intial", "123456", 1, "" });

            migrationBuilder.InsertData(
                table: "Partners",
                columns: new[] { "PartnerID", "BusinessAddress", "BusinessEmail", "BusinessName", "BusinessPhone", "DriverID", "LogoImage" },
                values: new object[] { 2, "401 North", "apple@gmail.com", "apple", "234234", 1, "" });

            migrationBuilder.CreateIndex(
                name: "IX_Partners_DriverID",
                table: "Partners",
                column: "DriverID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Partners");

            migrationBuilder.DropTable(
                name: "Drivers");
        }
    }
}
