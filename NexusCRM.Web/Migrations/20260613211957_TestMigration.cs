using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexusCRM.Web.Migrations;

/// <inheritdoc />
public partial class TestMigration : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Customers_Companies_CompanyId",
            table: "Customers");

        migrationBuilder.DropForeignKey(
            name: "FK_Customers_Companies_CompanyId1",
            table: "Customers");

        migrationBuilder.DropForeignKey(
            name: "FK_Customers_Users_UserId",
            table: "Customers");

        migrationBuilder.DropForeignKey(
            name: "FK_Deals_Companies_CompanyId",
            table: "Deals");

        migrationBuilder.DropForeignKey(
            name: "FK_Deals_Customers_CustomerId",
            table: "Deals");

        migrationBuilder.DropForeignKey(
            name: "FK_Deals_Users_UserId",
            table: "Deals");

        migrationBuilder.DropForeignKey(
            name: "FK_FollowUps_Deals_DealId",
            table: "FollowUps");

        migrationBuilder.DropForeignKey(
            name: "FK_FollowUps_Tasks_TaskId",
            table: "FollowUps");

        migrationBuilder.DropForeignKey(
            name: "FK_FollowUps_Users_AssignedUserId1",
            table: "FollowUps");

        migrationBuilder.DropForeignKey(
            name: "FK_FollowUps_Users_AuthorId1",
            table: "FollowUps");

        migrationBuilder.DropForeignKey(
            name: "FK_Notes_Users_AuthorId1",
            table: "Notes");

        migrationBuilder.DropForeignKey(
            name: "FK_Tasks_Deals_DealId",
            table: "Tasks");

        migrationBuilder.DropForeignKey(
            name: "FK_Tasks_Users_UserId1",
            table: "Tasks");

        migrationBuilder.DropForeignKey(
            name: "FK_Users_Companies_CompanyId",
            table: "Users");

        migrationBuilder.DropIndex(
            name: "IX_Customers_CompanyId1",
            table: "Customers");

        migrationBuilder.DropColumn(
            name: "AddressId",
            table: "Customers");

        migrationBuilder.DropColumn(
            name: "CompanyId1",
            table: "Customers");

        migrationBuilder.AlterColumn<string>(
            name: "Address_Country",
            table: "Customers",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "Address_City",
            table: "Customers",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldNullable: true);

        migrationBuilder.AddForeignKey(
            name: "FK_Customers_Companies_CompanyId",
            table: "Customers",
            column: "CompanyId",
            principalTable: "Companies",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);

        migrationBuilder.AddForeignKey(
            name: "FK_Customers_Users_UserId",
            table: "Customers",
            column: "UserId",
            principalTable: "Users",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);

        migrationBuilder.AddForeignKey(
            name: "FK_Deals_Companies_CompanyId",
            table: "Deals",
            column: "CompanyId",
            principalTable: "Companies",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);

        migrationBuilder.AddForeignKey(
            name: "FK_Deals_Customers_CustomerId",
            table: "Deals",
            column: "CustomerId",
            principalTable: "Customers",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);

        migrationBuilder.AddForeignKey(
            name: "FK_Deals_Users_UserId",
            table: "Deals",
            column: "UserId",
            principalTable: "Users",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);

        migrationBuilder.AddForeignKey(
            name: "FK_FollowUps_Deals_DealId",
            table: "FollowUps",
            column: "DealId",
            principalTable: "Deals",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);

        migrationBuilder.AddForeignKey(
            name: "FK_FollowUps_Tasks_TaskId",
            table: "FollowUps",
            column: "TaskId",
            principalTable: "Tasks",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);

        migrationBuilder.AddForeignKey(
            name: "FK_FollowUps_Users_AssignedUserId1",
            table: "FollowUps",
            column: "AssignedUserId1",
            principalTable: "Users",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);

        migrationBuilder.AddForeignKey(
            name: "FK_FollowUps_Users_AuthorId1",
            table: "FollowUps",
            column: "AuthorId1",
            principalTable: "Users",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);

        migrationBuilder.AddForeignKey(
            name: "FK_Notes_Users_AuthorId1",
            table: "Notes",
            column: "AuthorId1",
            principalTable: "Users",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);

        migrationBuilder.AddForeignKey(
            name: "FK_Tasks_Deals_DealId",
            table: "Tasks",
            column: "DealId",
            principalTable: "Deals",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);

        migrationBuilder.AddForeignKey(
            name: "FK_Tasks_Users_UserId1",
            table: "Tasks",
            column: "UserId1",
            principalTable: "Users",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);

        migrationBuilder.AddForeignKey(
            name: "FK_Users_Companies_CompanyId",
            table: "Users",
            column: "CompanyId",
            principalTable: "Companies",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Customers_Companies_CompanyId",
            table: "Customers");

        migrationBuilder.DropForeignKey(
            name: "FK_Customers_Users_UserId",
            table: "Customers");

        migrationBuilder.DropForeignKey(
            name: "FK_Deals_Companies_CompanyId",
            table: "Deals");

        migrationBuilder.DropForeignKey(
            name: "FK_Deals_Customers_CustomerId",
            table: "Deals");

        migrationBuilder.DropForeignKey(
            name: "FK_Deals_Users_UserId",
            table: "Deals");

        migrationBuilder.DropForeignKey(
            name: "FK_FollowUps_Deals_DealId",
            table: "FollowUps");

        migrationBuilder.DropForeignKey(
            name: "FK_FollowUps_Tasks_TaskId",
            table: "FollowUps");

        migrationBuilder.DropForeignKey(
            name: "FK_FollowUps_Users_AssignedUserId1",
            table: "FollowUps");

        migrationBuilder.DropForeignKey(
            name: "FK_FollowUps_Users_AuthorId1",
            table: "FollowUps");

        migrationBuilder.DropForeignKey(
            name: "FK_Notes_Users_AuthorId1",
            table: "Notes");

        migrationBuilder.DropForeignKey(
            name: "FK_Tasks_Deals_DealId",
            table: "Tasks");

        migrationBuilder.DropForeignKey(
            name: "FK_Tasks_Users_UserId1",
            table: "Tasks");

        migrationBuilder.DropForeignKey(
            name: "FK_Users_Companies_CompanyId",
            table: "Users");

        migrationBuilder.AlterColumn<string>(
            name: "Address_Country",
            table: "Customers",
            type: "nvarchar(max)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AlterColumn<string>(
            name: "Address_City",
            table: "Customers",
            type: "nvarchar(max)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AddColumn<int>(
            name: "AddressId",
            table: "Customers",
            type: "int",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddColumn<int>(
            name: "CompanyId1",
            table: "Customers",
            type: "int",
            nullable: true);

        migrationBuilder.CreateIndex(
            name: "IX_Customers_CompanyId1",
            table: "Customers",
            column: "CompanyId1");

        migrationBuilder.AddForeignKey(
            name: "FK_Customers_Companies_CompanyId",
            table: "Customers",
            column: "CompanyId",
            principalTable: "Companies",
            principalColumn: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_Customers_Companies_CompanyId1",
            table: "Customers",
            column: "CompanyId1",
            principalTable: "Companies",
            principalColumn: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_Customers_Users_UserId",
            table: "Customers",
            column: "UserId",
            principalTable: "Users",
            principalColumn: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_Deals_Companies_CompanyId",
            table: "Deals",
            column: "CompanyId",
            principalTable: "Companies",
            principalColumn: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_Deals_Customers_CustomerId",
            table: "Deals",
            column: "CustomerId",
            principalTable: "Customers",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);

        migrationBuilder.AddForeignKey(
            name: "FK_Deals_Users_UserId",
            table: "Deals",
            column: "UserId",
            principalTable: "Users",
            principalColumn: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_FollowUps_Deals_DealId",
            table: "FollowUps",
            column: "DealId",
            principalTable: "Deals",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);

        migrationBuilder.AddForeignKey(
            name: "FK_FollowUps_Tasks_TaskId",
            table: "FollowUps",
            column: "TaskId",
            principalTable: "Tasks",
            principalColumn: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_FollowUps_Users_AssignedUserId1",
            table: "FollowUps",
            column: "AssignedUserId1",
            principalTable: "Users",
            principalColumn: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_FollowUps_Users_AuthorId1",
            table: "FollowUps",
            column: "AuthorId1",
            principalTable: "Users",
            principalColumn: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_Notes_Users_AuthorId1",
            table: "Notes",
            column: "AuthorId1",
            principalTable: "Users",
            principalColumn: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_Tasks_Deals_DealId",
            table: "Tasks",
            column: "DealId",
            principalTable: "Deals",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);

        migrationBuilder.AddForeignKey(
            name: "FK_Tasks_Users_UserId1",
            table: "Tasks",
            column: "UserId1",
            principalTable: "Users",
            principalColumn: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_Users_Companies_CompanyId",
            table: "Users",
            column: "CompanyId",
            principalTable: "Companies",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }
}
