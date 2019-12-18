using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EpillBox.API.Migrations
{
    public partial class ExtendedMedicineAndUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActiveSubstances",
                columns: table => new
                {
                    ActiveSubstanceID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveSubstances", x => x.ActiveSubstanceID);
                });

            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    AllergiesID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.AllergiesID);
                });

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
                name: "MedicineForms",
                columns: table => new
                {
                    MedicineFormID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FormName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineForms", x => x.MedicineFormID);
                });

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    ProducerID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.ProducerID);
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
                name: "Medicines",
                columns: table => new
                {
                    MedicineID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    QuantityInPackage = table.Column<int>(nullable: false),
                    ProducerID = table.Column<int>(nullable: false),
                    MedicineFormID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.MedicineID);
                    table.ForeignKey(
                        name: "FK_Medicines_MedicineForms_MedicineFormID",
                        column: x => x.MedicineFormID,
                        principalTable: "MedicineForms",
                        principalColumn: "MedicineFormID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicines_Producers_ProducerID",
                        column: x => x.ProducerID,
                        principalTable: "Producers",
                        principalColumn: "ProducerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingBaskets",
                columns: table => new
                {
                    ShoppingBasketID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingBaskets", x => x.ShoppingBasketID);
                    table.ForeignKey(
                        name: "FK_ShoppingBaskets_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFirstAidKits",
                columns: table => new
                {
                    UserFirstAidKitID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserID = table.Column<int>(nullable: false),
                    FirstAidKitID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "UsersAllergies",
                columns: table => new
                {
                    UsersAllergiesID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AllergiesID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersAllergies", x => x.UsersAllergiesID);
                    table.ForeignKey(
                        name: "FK_UsersAllergies_Allergies_AllergiesID",
                        column: x => x.AllergiesID,
                        principalTable: "Allergies",
                        principalColumn: "AllergiesID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersAllergies_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActiveSubstanceMedicines",
                columns: table => new
                {
                    ActiveSubstanceMedicineID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ActiveSubstanceID = table.Column<int>(nullable: false),
                    MedicineID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveSubstanceMedicines", x => x.ActiveSubstanceMedicineID);
                    table.ForeignKey(
                        name: "FK_ActiveSubstanceMedicines_ActiveSubstances_ActiveSubstanceID",
                        column: x => x.ActiveSubstanceID,
                        principalTable: "ActiveSubstances",
                        principalColumn: "ActiveSubstanceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActiveSubstanceMedicines_Medicines_MedicineID",
                        column: x => x.MedicineID,
                        principalTable: "Medicines",
                        principalColumn: "MedicineID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FirstAidKitMedicines",
                columns: table => new
                {
                    FirstAidKitMedicineID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MedicineID = table.Column<int>(nullable: false),
                    FirstAidKitID = table.Column<int>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: true),
                    IsTaken = table.Column<bool>(nullable: false),
                    RemainingQuantity = table.Column<int>(nullable: false)
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
                name: "ShoppingBasketMedicines",
                columns: table => new
                {
                    ShoppingBasketMedicineID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MedicineID = table.Column<int>(nullable: false),
                    ShoppingBasketID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingBasketMedicines", x => x.ShoppingBasketMedicineID);
                    table.ForeignKey(
                        name: "FK_ShoppingBasketMedicines_Medicines_MedicineID",
                        column: x => x.MedicineID,
                        principalTable: "Medicines",
                        principalColumn: "MedicineID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingBasketMedicines_ShoppingBaskets_ShoppingBasketID",
                        column: x => x.ShoppingBasketID,
                        principalTable: "ShoppingBaskets",
                        principalColumn: "ShoppingBasketID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActiveSubstanceMedicines_ActiveSubstanceID",
                table: "ActiveSubstanceMedicines",
                column: "ActiveSubstanceID");

            migrationBuilder.CreateIndex(
                name: "IX_ActiveSubstanceMedicines_MedicineID",
                table: "ActiveSubstanceMedicines",
                column: "MedicineID");

            migrationBuilder.CreateIndex(
                name: "IX_FirstAidKitMedicines_FirstAidKitID",
                table: "FirstAidKitMedicines",
                column: "FirstAidKitID");

            migrationBuilder.CreateIndex(
                name: "IX_FirstAidKitMedicines_MedicineID",
                table: "FirstAidKitMedicines",
                column: "MedicineID");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_MedicineFormID",
                table: "Medicines",
                column: "MedicineFormID");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_ProducerID",
                table: "Medicines",
                column: "ProducerID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingBasketMedicines_MedicineID",
                table: "ShoppingBasketMedicines",
                column: "MedicineID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingBasketMedicines_ShoppingBasketID",
                table: "ShoppingBasketMedicines",
                column: "ShoppingBasketID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingBaskets_UserID",
                table: "ShoppingBaskets",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserFirstAidKits_FirstAidKitID",
                table: "UserFirstAidKits",
                column: "FirstAidKitID");

            migrationBuilder.CreateIndex(
                name: "IX_UserFirstAidKits_UserID",
                table: "UserFirstAidKits",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UsersAllergies_AllergiesID",
                table: "UsersAllergies",
                column: "AllergiesID");

            migrationBuilder.CreateIndex(
                name: "IX_UsersAllergies_UserID",
                table: "UsersAllergies",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActiveSubstanceMedicines");

            migrationBuilder.DropTable(
                name: "FirstAidKitMedicines");

            migrationBuilder.DropTable(
                name: "ShoppingBasketMedicines");

            migrationBuilder.DropTable(
                name: "UserFirstAidKits");

            migrationBuilder.DropTable(
                name: "UsersAllergies");

            migrationBuilder.DropTable(
                name: "ActiveSubstances");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "ShoppingBaskets");

            migrationBuilder.DropTable(
                name: "FirstAidKits");

            migrationBuilder.DropTable(
                name: "Allergies");

            migrationBuilder.DropTable(
                name: "MedicineForms");

            migrationBuilder.DropTable(
                name: "Producers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
