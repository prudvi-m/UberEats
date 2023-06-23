using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UberEats.Migrations
{
    public partial class v2 : Migration
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
                    BusinessPhone = table.Column<int>(type: "INTEGER", nullable: false),
                    DriverID = table.Column<int>(type: "INTEGER", nullable: false)
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
                values: new object[] { 1, "Restaurent" });

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
                columns: new[] { "PartnerID", "BusinessAddress", "BusinessEmail", "BusinessName", "BusinessPhone", "DriverID" },
                values: new object[] { 1, "Stratocaster", "Stratocaster@gmail.com", "strat", 908876754, 1 });

            migrationBuilder.InsertData(
                table: "Partners",
                columns: new[] { "PartnerID", "BusinessAddress", "BusinessEmail", "BusinessName", "BusinessPhone", "DriverID" },
                values: new object[] { 2, "Gibson Les Paul", "les_paul@gmail.com", "les_paul", 908876754, 1 });

            migrationBuilder.InsertData(
                table: "Partners",
                columns: new[] { "PartnerID", "BusinessAddress", "BusinessEmail", "BusinessName", "BusinessPhone", "DriverID" },
                values: new object[] { 3, "Gibson SG", "sg@gmail.com", "sg", 908876754, 1 });

            migrationBuilder.InsertData(
                table: "Partners",
                columns: new[] { "PartnerID", "BusinessAddress", "BusinessEmail", "BusinessName", "BusinessPhone", "DriverID" },
                values: new object[] { 4, "Yamaha FG700S", "fg700s@gmail.com", "fg700s", 908876754, 7 });

            migrationBuilder.InsertData(
                table: "Partners",
                columns: new[] { "PartnerID", "BusinessAddress", "BusinessEmail", "BusinessName", "BusinessPhone", "DriverID" },
                values: new object[] { 5, "Washburn D10S", "washburn@gmail.com", "washburn", 908876754, 7 });

            migrationBuilder.InsertData(
                table: "Partners",
                columns: new[] { "PartnerID", "BusinessAddress", "BusinessEmail", "BusinessName", "BusinessPhone", "DriverID" },
                values: new object[] { 6, "Rodriguez Caballero 11", "rodriguez@gmail.com", "rodriguez", 908876754, 4 });

            migrationBuilder.InsertData(
                table: "Partners",
                columns: new[] { "PartnerID", "BusinessAddress", "BusinessEmail", "BusinessName", "BusinessPhone", "DriverID" },
                values: new object[] { 7, "Fender Precision", "precision@gmail.com", "precision", 908876754, 2 });

            migrationBuilder.InsertData(
                table: "Partners",
                columns: new[] { "PartnerID", "BusinessAddress", "BusinessEmail", "BusinessName", "BusinessPhone", "DriverID" },
                values: new object[] { 8, "Hofner Icon", "hofner@gmail.com", "hofner", 908876754, 2 });

            migrationBuilder.InsertData(
                table: "Partners",
                columns: new[] { "PartnerID", "BusinessAddress", "BusinessEmail", "BusinessName", "BusinessPhone", "DriverID" },
                values: new object[] { 9, "Ludwig 5-piece Drum Set with Cymbals", "ludwig@gmail.com", "ludwig", 908876754, 3 });

            migrationBuilder.InsertData(
                table: "Partners",
                columns: new[] { "PartnerID", "BusinessAddress", "BusinessEmail", "BusinessName", "BusinessPhone", "DriverID" },
                values: new object[] { 10, "Tama 5-Piece Drum Set with Cymbals", "tama@gmail.com", "tama", 908876754, 3 });

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
