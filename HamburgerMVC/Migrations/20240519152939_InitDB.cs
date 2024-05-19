using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HamburgerMVC.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Boys",
                columns: table => new
                {
                    BoyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoyCarpani = table.Column<double>(type: "float", nullable: false),
                    BoyAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boys", x => x.BoyID);
                });

            migrationBuilder.CreateTable(
                name: "EkMalzemes",
                columns: table => new
                {
                    EkMalzemeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EkMalzemeAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EkMalzemeFiyat = table.Column<decimal>(type: "money", nullable: false),
                    Resim = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EkMalzemes", x => x.EkMalzemeID);
                });

            migrationBuilder.CreateTable(
                name: "Hamburgers",
                columns: table => new
                {
                    HamburgerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HamburgerAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HamburgerFiyat = table.Column<decimal>(type: "money", nullable: false),
                    Resim = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hamburgers", x => x.HamburgerID);
                });

            migrationBuilder.CreateTable(
                name: "Iceceks",
                columns: table => new
                {
                    IcecekID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IcecekAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IcecekFiyat = table.Column<decimal>(type: "money", nullable: false),
                    Resim = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iceceks", x => x.IcecekID);
                });

            migrationBuilder.CreateTable(
                name: "Login_VM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login_VM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Register_VM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Register_VM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sos",
                columns: table => new
                {
                    SosID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SosAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SosFiyat = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sos", x => x.SosID);
                });

            migrationBuilder.CreateTable(
                name: "YanUruns",
                columns: table => new
                {
                    YanUrunID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YanUrunAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YanUrunFiyat = table.Column<decimal>(type: "money", nullable: false),
                    Resim = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YanUruns", x => x.YanUrunID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HamburgerEkMalzemes",
                columns: table => new
                {
                    HamburgerEkMalzemeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HamburgerID = table.Column<int>(type: "int", nullable: false),
                    EkMalzemeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HamburgerEkMalzemes", x => x.HamburgerEkMalzemeID);
                    table.ForeignKey(
                        name: "FK_HamburgerEkMalzemes_EkMalzemes_EkMalzemeID",
                        column: x => x.EkMalzemeID,
                        principalTable: "EkMalzemes",
                        principalColumn: "EkMalzemeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HamburgerEkMalzemes_Hamburgers_HamburgerID",
                        column: x => x.HamburgerID,
                        principalTable: "Hamburgers",
                        principalColumn: "HamburgerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    MenuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MenuFiyat = table.Column<decimal>(type: "money", nullable: false),
                    HamburgerID = table.Column<int>(type: "int", nullable: false),
                    YanUrunID = table.Column<int>(type: "int", nullable: false),
                    IcecekID = table.Column<int>(type: "int", nullable: false),
                    BoyID = table.Column<int>(type: "int", nullable: false),
                    Resim = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.MenuID);
                    table.ForeignKey(
                        name: "FK_Menus_Boys_BoyID",
                        column: x => x.BoyID,
                        principalTable: "Boys",
                        principalColumn: "BoyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Menus_Hamburgers_HamburgerID",
                        column: x => x.HamburgerID,
                        principalTable: "Hamburgers",
                        principalColumn: "HamburgerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Menus_Iceceks_IcecekID",
                        column: x => x.IcecekID,
                        principalTable: "Iceceks",
                        principalColumn: "IcecekID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Menus_YanUruns_YanUrunID",
                        column: x => x.YanUrunID,
                        principalTable: "YanUruns",
                        principalColumn: "YanUrunID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SosMenu",
                columns: table => new
                {
                    SosMenuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SosID = table.Column<int>(type: "int", nullable: false),
                    MenuID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SosMenu", x => x.SosMenuID);
                    table.ForeignKey(
                        name: "FK_SosMenu_Menus_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menus",
                        principalColumn: "MenuID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SosMenu_Sos_SosID",
                        column: x => x.SosID,
                        principalTable: "Sos",
                        principalColumn: "SosID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "2b785952-daa8-406b-8daf-7646551b3708", "Yonetici", "YONETICI" },
                    { 2, "7fd729e8-008f-49ff-b49c-29c82195a1da", "Uye", "UYE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Ad", "Adres", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Soyad", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "Bora", "Uskudar", "777602df-baca-41e4-a19f-24e6a0ff8c72", "Bora@gmail.com", false, false, null, "BORA@GMAIL.COM", "BORA@GMAIL.COM", "AQAAAAIAAYagAAAAEHjazcFnVOzuy0tXfK6I8dx55o3qPp1f4I30sHIP6ph1j1oiGT9A6I/AjBlUahN07Q==", null, false, "6dd6b5de-f5e0-4959-bb03-efc11393eb84", "Yildirim", false, "Bora@gmail.com" });

            migrationBuilder.InsertData(
                table: "Boys",
                columns: new[] { "BoyID", "BoyAdi", "BoyCarpani" },
                values: new object[,]
                {
                    { 1, "Kucuk", 1.0 },
                    { 2, "Orta", 1.1000000000000001 },
                    { 3, "Buyuk", 1.2 }
                });

            migrationBuilder.InsertData(
                table: "EkMalzemes",
                columns: new[] { "EkMalzemeID", "EkMalzemeAdi", "EkMalzemeFiyat", "Resim" },
                values: new object[,]
                {
                    { 1, "Sogan", 10m, null },
                    { 2, "Marul", 8m, null },
                    { 3, "Domates", 12m, null },
                    { 4, "Peynir", 20m, null }
                });

            migrationBuilder.InsertData(
                table: "Hamburgers",
                columns: new[] { "HamburgerID", "HamburgerAdi", "HamburgerFiyat", "Resim" },
                values: new object[,]
                {
                    { 1, "ChickenShow", 200m, null },
                    { 2, "DoubleShow", 280m, null },
                    { 3, "SteakShow", 240m, null },
                    { 4, "McShow", 310m, null }
                });

            migrationBuilder.InsertData(
                table: "Iceceks",
                columns: new[] { "IcecekID", "IcecekAdi", "IcecekFiyat", "Resim" },
                values: new object[,]
                {
                    { 1, "Kola", 30m, null },
                    { 2, "Fanta", 30m, null },
                    { 3, "Ayran", 20m, null },
                    { 4, "Sprite", 30m, null }
                });

            migrationBuilder.InsertData(
                table: "Sos",
                columns: new[] { "SosID", "SosAdi", "SosFiyat" },
                values: new object[,]
                {
                    { 1, "Ketcap", 5m },
                    { 2, "Mayonez", 5m },
                    { 3, "Hardal", 8m },
                    { 4, "Ranch", 10m }
                });

            migrationBuilder.InsertData(
                table: "YanUruns",
                columns: new[] { "YanUrunID", "Resim", "YanUrunAdi", "YanUrunFiyat" },
                values: new object[,]
                {
                    { 1, null, "Patates", 20m },
                    { 2, null, "SoganHalkasi", 30m },
                    { 3, null, "Salata", 10m },
                    { 4, null, "PeynirCubugu", 20m }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MenuID", "BoyID", "HamburgerID", "IcecekID", "MenuAdi", "MenuFiyat", "Resim", "YanUrunID" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, "GamerMenu", 300m, "Burger1.jpg", 1 },
                    { 2, 1, 2, 2, "DoyuranMenu", 350m, "Burger2.jpg", 2 },
                    { 3, 1, 3, 3, "GurmeMenu", 370m, "Burger3.jpg", 2 },
                    { 4, 1, 4, 4, "BEUMenu", 400m, "Burger4.jpg", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HamburgerEkMalzemes_EkMalzemeID",
                table: "HamburgerEkMalzemes",
                column: "EkMalzemeID");

            migrationBuilder.CreateIndex(
                name: "IX_HamburgerEkMalzemes_HamburgerID",
                table: "HamburgerEkMalzemes",
                column: "HamburgerID");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_BoyID",
                table: "Menus",
                column: "BoyID");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_HamburgerID",
                table: "Menus",
                column: "HamburgerID");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_IcecekID",
                table: "Menus",
                column: "IcecekID");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_YanUrunID",
                table: "Menus",
                column: "YanUrunID");

            migrationBuilder.CreateIndex(
                name: "IX_SosMenu_MenuID",
                table: "SosMenu",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_SosMenu_SosID",
                table: "SosMenu",
                column: "SosID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "HamburgerEkMalzemes");

            migrationBuilder.DropTable(
                name: "Login_VM");

            migrationBuilder.DropTable(
                name: "Register_VM");

            migrationBuilder.DropTable(
                name: "SosMenu");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "EkMalzemes");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Sos");

            migrationBuilder.DropTable(
                name: "Boys");

            migrationBuilder.DropTable(
                name: "Hamburgers");

            migrationBuilder.DropTable(
                name: "Iceceks");

            migrationBuilder.DropTable(
                name: "YanUruns");
        }
    }
}
