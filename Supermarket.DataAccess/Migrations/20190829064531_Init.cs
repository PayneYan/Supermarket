using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Supermarket.DataAccess.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateUser = table.Column<string>(maxLength: 10, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateUser = table.Column<string>(maxLength: 10, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Director = table.Column<string>(maxLength: 20, nullable: true),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    Fax = table.Column<string>(maxLength: 20, nullable: true),
                    Address = table.Column<string>(maxLength: 50, nullable: true),
                    CooperationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Goods",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateUser = table.Column<string>(maxLength: 10, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateUser = table.Column<string>(maxLength: 10, nullable: true),
                    TypeId = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 20, nullable: true),
                    Unit = table.Column<string>(maxLength: 20, nullable: true),
                    Norm = table.Column<string>(maxLength: 20, nullable: true),
                    SellPrice = table.Column<decimal>(nullable: false),
                    GoodNum = table.Column<int>(nullable: false),
                    AlarmNum = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GoodsType",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateUser = table.Column<string>(maxLength: 10, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateUser = table.Column<string>(maxLength: 10, nullable: true),
                    TypeName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sell",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateUser = table.Column<string>(maxLength: 10, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateUser = table.Column<string>(maxLength: 10, nullable: true),
                    GoodsId = table.Column<string>(maxLength: 50, nullable: true),
                    Operator = table.Column<int>(nullable: false),
                    SellPrice = table.Column<decimal>(nullable: false),
                    GoodsNum = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sell", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateUser = table.Column<string>(maxLength: 10, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateUser = table.Column<string>(maxLength: 10, nullable: true),
                    GoodsId = table.Column<string>(maxLength: 50, nullable: true),
                    ConmpanyId = table.Column<string>(maxLength: 50, nullable: true),
                    Operator = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    GoodsNum = table.Column<int>(nullable: false),
                    Remark = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockPrice",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateUser = table.Column<string>(maxLength: 10, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateUser = table.Column<string>(maxLength: 10, nullable: true),
                    GoodsId = table.Column<string>(maxLength: 50, nullable: true),
                    ConmpanyId = table.Column<string>(maxLength: 50, nullable: true),
                    GoodsSellPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockPrice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateUser = table.Column<string>(maxLength: 10, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateUser = table.Column<string>(maxLength: 10, nullable: true),
                    RealName = table.Column<string>(maxLength: 10, nullable: true),
                    UserName = table.Column<string>(maxLength: 30, nullable: true),
                    Password = table.Column<string>(maxLength: 30, nullable: true),
                    UserRight = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Goods");

            migrationBuilder.DropTable(
                name: "GoodsType");

            migrationBuilder.DropTable(
                name: "Sell");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "StockPrice");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
