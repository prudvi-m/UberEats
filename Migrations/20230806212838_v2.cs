using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UberEats.Migrations
{
    public partial class v2 : Migration
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
                    ItemCategoryID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuCategories", x => x.ItemCategoryID);
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
                name: "Menu",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    PartnerID = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemCategoryID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_Menu_MenuCategories_ItemCategoryID",
                        column: x => x.ItemCategoryID,
                        principalTable: "MenuCategories",
                        principalColumn: "ItemCategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Menu_Partners_PartnerID",
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
                columns: new[] { "ItemCategoryID", "Name" },
                values: new object[] { 1, "Appetizer" });

            migrationBuilder.InsertData(
                table: "MenuCategories",
                columns: new[] { "ItemCategoryID", "Name" },
                values: new object[] { 2, "Soup" });

            migrationBuilder.InsertData(
                table: "MenuCategories",
                columns: new[] { "ItemCategoryID", "Name" },
                values: new object[] { 3, "Salad" });

            migrationBuilder.InsertData(
                table: "MenuCategories",
                columns: new[] { "ItemCategoryID", "Name" },
                values: new object[] { 4, "Main Course" });

            migrationBuilder.InsertData(
                table: "MenuCategories",
                columns: new[] { "ItemCategoryID", "Name" },
                values: new object[] { 5, "Dessert" });

            migrationBuilder.InsertData(
                table: "MenuCategories",
                columns: new[] { "ItemCategoryID", "Name" },
                values: new object[] { 6, "Drink" });

            migrationBuilder.InsertData(
                table: "MenuCategories",
                columns: new[] { "ItemCategoryID", "Name" },
                values: new object[] { 7, "Vegetarian" });

            migrationBuilder.InsertData(
                table: "Partners",
                columns: new[] { "PartnerID", "BusinessAddress", "BusinessEmail", "BusinessName", "BusinessPhone", "CategoryID", "LogoImage" },
                values: new object[] { 1, "Chicago, 401, West Downtown", "vr@gmail.com", "Vinod Restaurant", "007", 1, "" });

            migrationBuilder.InsertData(
                table: "Partners",
                columns: new[] { "PartnerID", "BusinessAddress", "BusinessEmail", "BusinessName", "BusinessPhone", "CategoryID", "LogoImage" },
                values: new object[] { 2, "Dallas, 401, East Downtown", "vr@gmail.com", "AdventureQuest Tours", "007", 2, "" });

            migrationBuilder.InsertData(
                table: "Partners",
                columns: new[] { "PartnerID", "BusinessAddress", "BusinessEmail", "BusinessName", "BusinessPhone", "CategoryID", "LogoImage" },
                values: new object[] { 3, "Illinios, 402", "CodeCraft@gmail.com", "CodeCraft Solutions", "007", 3, "" });

            migrationBuilder.InsertData(
                table: "Partners",
                columns: new[] { "PartnerID", "BusinessAddress", "BusinessEmail", "BusinessName", "BusinessPhone", "CategoryID", "LogoImage" },
                values: new object[] { 4, "Texas, 403", "DecoCraft@gmail.com", "DecoCraft Interiors", "007", 2, "" });

            migrationBuilder.InsertData(
                table: "Partners",
                columns: new[] { "PartnerID", "BusinessAddress", "BusinessEmail", "BusinessName", "BusinessPhone", "CategoryID", "LogoImage" },
                values: new object[] { 5, "Chicago, 401, West Downtown", "vr@gmail.com", "Vinod Restaurant", "007", 1, "" });

            migrationBuilder.InsertData(
                table: "Partners",
                columns: new[] { "PartnerID", "BusinessAddress", "BusinessEmail", "BusinessName", "BusinessPhone", "CategoryID", "LogoImage" },
                values: new object[] { 6, "Chicago, 401, West Downtown", "vr@gmail.com", "Vinod Restaurant", "007", 3, "" });

            migrationBuilder.InsertData(
                table: "Menu",
                columns: new[] { "ItemID", "Description", "ItemCategoryID", "Name", "PartnerID", "Price" },
                values: new object[] { 1, "Mast Brothers bittersweet chocolate", 5, "Biscochitos", 1, 31.5 });

            migrationBuilder.CreateIndex(
                name: "IX_Menu_ItemCategoryID",
                table: "Menu",
                column: "ItemCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_PartnerID",
                table: "Menu",
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
                name: "Menu");

            migrationBuilder.DropTable(
                name: "MenuCategories");

            migrationBuilder.DropTable(
                name: "Partners");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
