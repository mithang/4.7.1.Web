using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MediHub.Touchee.Migrations
{
    public partial class EditPropertiesProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Assignment",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Checkin",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Checkout",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Difficulty",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpectedCheckout",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ExpectedDuration",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OfftimeOverage",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Overtime",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<float>(
                name: "PercentilePerformance",
                table: "Products",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "ProjectName",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UrgentLevel",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Assignment",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Checkin",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Checkout",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ExpectedCheckout",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ExpectedDuration",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OfftimeOverage",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Overtime",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PercentilePerformance",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProjectName",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UrgentLevel",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Products",
                nullable: false,
                defaultValue: 0);
        }
    }
}
