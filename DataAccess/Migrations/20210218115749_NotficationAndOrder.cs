using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class NotficationAndOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notfications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                      .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    IsStored = table.Column<bool>(nullable: false),
                    IsDeliver = table.Column<bool>(nullable: false),
                    IsStartDeliver = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notfications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Link = table.Column<string>(nullable: true),
                    Count = table.Column<double>(nullable: false),
                    Size = table.Column<double>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    CargoCountry = table.Column<double>(nullable: false),
                    DeclarationLink = table.Column<string>(nullable: true),
                    Total = table.Column<double>(nullable: false),
                    İsPayment = table.Column<bool>(nullable: false),
                    İsAccepted = table.Column<bool>(nullable: false),
                    İsRejected = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notfications");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
