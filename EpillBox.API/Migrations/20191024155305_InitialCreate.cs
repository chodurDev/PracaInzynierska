using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EpillBox.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    ProducerIdProducer = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    FormIdForm = table.Column<int>(nullable: true),
                    Effect = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.IdMedicine);
                    table.ForeignKey(
                        name: "FK_Medicines_Forms_FormIdForm",
                        column: x => x.FormIdForm,
                        principalTable: "Forms",
                        principalColumn: "IdForm",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Medicines_Producers_ProducerIdProducer",
                        column: x => x.ProducerIdProducer,
                        principalTable: "Producers",
                        principalColumn: "IdProducer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Alergics",
                columns: table => new
                {
                    IdAlergic = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserIdUser = table.Column<int>(nullable: true),
                    substanceName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alergics", x => x.IdAlergic);
                    table.ForeignKey(
                        name: "FK_Alergics_Users_UserIdUser",
                        column: x => x.UserIdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FirstAidKits",
                columns: table => new
                {
                    IdUser = table.Column<int>(nullable: false),
                    IdMedicine = table.Column<int>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    IsTaken = table.Column<bool>(nullable: false),
                    remainingQuantity = table.Column<int>(nullable: false),
                    IsAlergicTo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirstAidKits", x => new { x.IdMedicine, x.IdUser });
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
                    IdMedicine = table.Column<int>(nullable: false),
                    IdCategory = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineCategories", x => new { x.IdMedicine, x.IdCategory });
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
                    IdMedicine = table.Column<int>(nullable: false),
                    IdComposition = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineCompositions", x => new { x.IdMedicine, x.IdComposition });
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
                name: "IX_Alergics_UserIdUser",
                table: "Alergics",
                column: "UserIdUser");

            migrationBuilder.CreateIndex(
                name: "IX_FirstAidKits_IdUser",
                table: "FirstAidKits",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineCategories_IdCategory",
                table: "MedicineCategories",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineCompositions_IdComposition",
                table: "MedicineCompositions",
                column: "IdComposition");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_FormIdForm",
                table: "Medicines",
                column: "FormIdForm");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_ProducerIdProducer",
                table: "Medicines",
                column: "ProducerIdProducer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alergics");

            migrationBuilder.DropTable(
                name: "FirstAidKits");

            migrationBuilder.DropTable(
                name: "MedicineCategories");

            migrationBuilder.DropTable(
                name: "MedicineCompositions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Compositions");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.DropTable(
                name: "Producers");
        }
    }
}
