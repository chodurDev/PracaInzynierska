using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EpillBox.API.Migrations
{
    public partial class ChangedFirstAidKitMedicine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "UserFirstAidKits",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuantityInPackage",
                table: "Medicines",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "FirstAidKitMedicines",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsTaken",
                table: "FirstAidKitMedicines",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "RemainingQuantity",
                table: "FirstAidKitMedicines",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "UserFirstAidKits");

            migrationBuilder.DropColumn(
                name: "QuantityInPackage",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "FirstAidKitMedicines");

            migrationBuilder.DropColumn(
                name: "IsTaken",
                table: "FirstAidKitMedicines");

            migrationBuilder.DropColumn(
                name: "RemainingQuantity",
                table: "FirstAidKitMedicines");
        }
    }
}
