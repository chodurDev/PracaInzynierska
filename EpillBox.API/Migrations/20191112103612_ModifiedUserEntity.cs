using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EpillBox.API.Migrations
{
    public partial class ModifiedUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FirstAidKits",
                columns: table => new
                {
                    FirstAidKitID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirstAidKits", x => x.FirstAidKitID);
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    MedicineID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.MedicineID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "FirstAidKitMedicines",
                columns: table => new
                {
                    FirstAidKitMedicineID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MedicineID = table.Column<int>(nullable: false),
                    FirstAidKitID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirstAidKitMedicines", x => x.FirstAidKitMedicineID);
                    table.ForeignKey(
                        name: "FK_FirstAidKitMedicines_FirstAidKits_FirstAidKitID",
                        column: x => x.FirstAidKitID,
                        principalTable: "FirstAidKits",
                        principalColumn: "FirstAidKitID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FirstAidKitMedicines_Medicines_MedicineID",
                        column: x => x.MedicineID,
                        principalTable: "Medicines",
                        principalColumn: "MedicineID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFirstAidKits",
                columns: table => new
                {
                    UserFirstAidKitID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserID = table.Column<int>(nullable: false),
                    FirstAidKitID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFirstAidKits", x => x.UserFirstAidKitID);
                    table.ForeignKey(
                        name: "FK_UserFirstAidKits_FirstAidKits_FirstAidKitID",
                        column: x => x.FirstAidKitID,
                        principalTable: "FirstAidKits",
                        principalColumn: "FirstAidKitID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFirstAidKits_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FirstAidKitMedicines_FirstAidKitID",
                table: "FirstAidKitMedicines",
                column: "FirstAidKitID");

            migrationBuilder.CreateIndex(
                name: "IX_FirstAidKitMedicines_MedicineID",
                table: "FirstAidKitMedicines",
                column: "MedicineID");

            migrationBuilder.CreateIndex(
                name: "IX_UserFirstAidKits_FirstAidKitID",
                table: "UserFirstAidKits",
                column: "FirstAidKitID");

            migrationBuilder.CreateIndex(
                name: "IX_UserFirstAidKits_UserID",
                table: "UserFirstAidKits",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FirstAidKitMedicines");

            migrationBuilder.DropTable(
                name: "UserFirstAidKits");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "FirstAidKits");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
