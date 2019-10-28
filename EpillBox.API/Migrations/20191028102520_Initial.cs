using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EpillBox.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alergics",
                columns: table => new
                {
                    IdAlergic = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    substanceName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alergics", x => x.IdAlergic);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    IdCategory = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.IdCategory);
                });

            migrationBuilder.CreateTable(
                name: "Compositions",
                columns: table => new
                {
                    IdComposition = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compositions", x => x.IdComposition);
                });

            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    IdForm = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.IdForm);
                });

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    IdProducer = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.IdProducer);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    IdMedicine = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdProducer = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    IdForm = table.Column<int>(nullable: false),
                    Effect = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.IdMedicine);
                    table.ForeignKey(
                        name: "FK_Medicines_Forms_IdForm",
                        column: x => x.IdForm,
                        principalTable: "Forms",
                        principalColumn: "IdForm",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicines_Producers_IdProducer",
                        column: x => x.IdProducer,
                        principalTable: "Producers",
                        principalColumn: "IdProducer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAlergics",
                columns: table => new
                {
                    IdUserAlergics = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdUser = table.Column<int>(nullable: false),
                    IdAlergic = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAlergics", x => x.IdUserAlergics);
                    table.ForeignKey(
                        name: "FK_UserAlergics_Alergics_IdAlergic",
                        column: x => x.IdAlergic,
                        principalTable: "Alergics",
                        principalColumn: "IdAlergic",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAlergics_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FirstAidKits",
                columns: table => new
                {
                    IdFirstAidKit = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdUser = table.Column<int>(nullable: false),
                    IdMedicine = table.Column<int>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    IsTaken = table.Column<bool>(nullable: false),
                    remainingQuantity = table.Column<int>(nullable: false),
                    IsAlergicTo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirstAidKits", x => x.IdFirstAidKit);
                    table.ForeignKey(
                        name: "FK_FirstAidKits_Medicines_IdMedicine",
                        column: x => x.IdMedicine,
                        principalTable: "Medicines",
                        principalColumn: "IdMedicine",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FirstAidKits_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicineCategories",
                columns: table => new
                {
                    IdMedicineCategory = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdMedicine = table.Column<int>(nullable: false),
                    IdCategory = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineCategories", x => x.IdMedicineCategory);
                    table.ForeignKey(
                        name: "FK_MedicineCategories_Categories_IdCategory",
                        column: x => x.IdCategory,
                        principalTable: "Categories",
                        principalColumn: "IdCategory",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicineCategories_Medicines_IdMedicine",
                        column: x => x.IdMedicine,
                        principalTable: "Medicines",
                        principalColumn: "IdMedicine",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicineCompositions",
                columns: table => new
                {
                    IdMedicineComposition = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdMedicine = table.Column<int>(nullable: false),
                    IdComposition = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineCompositions", x => x.IdMedicineComposition);
                    table.ForeignKey(
                        name: "FK_MedicineCompositions_Compositions_IdComposition",
                        column: x => x.IdComposition,
                        principalTable: "Compositions",
                        principalColumn: "IdComposition",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicineCompositions_Medicines_IdMedicine",
                        column: x => x.IdMedicine,
                        principalTable: "Medicines",
                        principalColumn: "IdMedicine",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FirstAidKits_IdMedicine",
                table: "FirstAidKits",
                column: "IdMedicine");

            migrationBuilder.CreateIndex(
                name: "IX_FirstAidKits_IdUser",
                table: "FirstAidKits",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineCategories_IdCategory",
                table: "MedicineCategories",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineCategories_IdMedicine",
                table: "MedicineCategories",
                column: "IdMedicine");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineCompositions_IdComposition",
                table: "MedicineCompositions",
                column: "IdComposition");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineCompositions_IdMedicine",
                table: "MedicineCompositions",
                column: "IdMedicine");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_IdForm",
                table: "Medicines",
                column: "IdForm");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_IdProducer",
                table: "Medicines",
                column: "IdProducer");

            migrationBuilder.CreateIndex(
                name: "IX_UserAlergics_IdAlergic",
                table: "UserAlergics",
                column: "IdAlergic");

            migrationBuilder.CreateIndex(
                name: "IX_UserAlergics_IdUser",
                table: "UserAlergics",
                column: "IdUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FirstAidKits");

            migrationBuilder.DropTable(
                name: "MedicineCategories");

            migrationBuilder.DropTable(
                name: "MedicineCompositions");

            migrationBuilder.DropTable(
                name: "UserAlergics");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Compositions");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "Alergics");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.DropTable(
                name: "Producers");
        }
    }
}
