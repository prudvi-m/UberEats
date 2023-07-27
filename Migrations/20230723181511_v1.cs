using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UberEats.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    DriverID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    SSN = table.Column<string>(type: "TEXT", nullable: false),
                    PostCode = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    DriverLicense = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.DriverID);
                });

            migrationBuilder.CreateTable(
                name: "MenuCategories",
                columns: table => new
                {
                    MenuCategoryID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuCategories", x => x.MenuCategoryID);
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
                    CategoryID = table.Column<int>(type: "INTEGER", nullable: false),
                    LogoImage = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.PartnerID);
                    table.ForeignKey(
                        name: "FK_Partners_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    MenuItemID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    PartnerID = table.Column<int>(type: "INTEGER", nullable: false),
                    MenuCategoryID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.MenuItemID);
                    table.ForeignKey(
                        name: "FK_MenuItems_MenuCategories_MenuCategoryID",
                        column: x => x.MenuCategoryID,
                        principalTable: "MenuCategories",
                        principalColumn: "MenuCategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuItems_Partners_PartnerID",
                        column: x => x.PartnerID,
                        principalTable: "Partners",
                        principalColumn: "PartnerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[] { 1, "Restaurant" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[] { 2, "Grocery" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[] { 3, "Alcohol" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[] { 4, "Convienience" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[] { 5, "Flower shop" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[] { 6, "Pet Store" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[] { 7, "retail" });

            migrationBuilder.InsertData(
                table: "MenuCategories",
                columns: new[] { "MenuCategoryID", "Name" },
                values: new object[] { 1, "Appetizer" });

            migrationBuilder.InsertData(
                table: "MenuCategories",
                columns: new[] { "MenuCategoryID", "Name" },
                values: new object[] { 2, "Soup" });

            migrationBuilder.InsertData(
                table: "MenuCategories",
                columns: new[] { "MenuCategoryID", "Name" },
                values: new object[] { 3, "Salad" });

            migrationBuilder.InsertData(
                table: "MenuCategories",
                columns: new[] { "MenuCategoryID", "Name" },
                values: new object[] { 4, "Main Course" });

            migrationBuilder.InsertData(
                table: "MenuCategories",
                columns: new[] { "MenuCategoryID", "Name" },
                values: new object[] { 5, "Dessert" });

            migrationBuilder.InsertData(
                table: "MenuCategories",
                columns: new[] { "MenuCategoryID", "Name" },
                values: new object[] { 6, "Drink" });

            migrationBuilder.InsertData(
                table: "MenuCategories",
                columns: new[] { "MenuCategoryID", "Name" },
                values: new object[] { 7, "Vegetarian" });

            migrationBuilder.InsertData(
                table: "Partners",
                columns: new[] { "PartnerID", "BusinessAddress", "BusinessEmail", "BusinessName", "BusinessPhone", "CategoryID", "LogoImage" },
                values: new object[] { 1, "Chicago, 3001", "intial@gmail.com", "intial", "123456", 1, "" });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "MenuItemID", "Description", "MenuCategoryID", "Name", "PartnerID", "Price" },
                values: new object[] { 1, "Traditional Delicious Sweet", 5, "Payasam", 1, 5.2000000000000002 });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_MenuCategoryID",
                table: "MenuItems",
                column: "MenuCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_PartnerID",
                table: "MenuItems",
                column: "PartnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Partners_CategoryID",
                table: "Partners",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "MenuCategories");

            migrationBuilder.DropTable(
                name: "Partners");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
