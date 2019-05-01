using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Main.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountEntities",
                columns: table => new
                {
                    User_AccountGUID = table.Column<Guid>(nullable: false),
                    OrderNumber = table.Column<int>(nullable: false),
                    Row_ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    User_Login = table.Column<string>(maxLength: 16, nullable: true),
                    User_Password = table.Column<string>(maxLength: 32, nullable: true),
                    User_AccountStatus = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(maxLength: 8, nullable: false),
                    UserPhone = table.Column<byte[]>(maxLength: 11, nullable: true),
                    UserEMail = table.Column<string>(maxLength: 64, nullable: true),
                    Occupation = table.Column<string>(maxLength: 16, nullable: true),
                    BlogAddress = table.Column<string>(maxLength: 128, nullable: true),
                    Birthday = table.Column<DateTime>(nullable: true),
                    Sex = table.Column<bool>(nullable: false),
                    Location_Nation = table.Column<string>(maxLength: 16, nullable: true),
                    Location_Province = table.Column<string>(maxLength: 16, nullable: true),
                    Location_City = table.Column<string>(maxLength: 16, nullable: true),
                    Location_County = table.Column<string>(maxLength: 16, nullable: true),
                    Nation = table.Column<string>(maxLength: 16, nullable: true),
                    Province = table.Column<string>(maxLength: 16, nullable: true),
                    City = table.Column<string>(maxLength: 16, nullable: true),
                    County = table.Column<string>(maxLength: 16, nullable: true),
                    Intro = table.Column<string>(maxLength: 32, nullable: true),
                    UserIconURL = table.Column<string>(maxLength: 128, nullable: true),
                    User_AccountLevel = table.Column<int>(nullable: false),
                    User_AccountRegisterTime = table.Column<DateTime>(nullable: false),
                    User_AccountRegisterIPAddress = table.Column<byte[]>(maxLength: 12, nullable: false),
                    User_AccountLastLoginIPAddress = table.Column<byte[]>(maxLength: 12, nullable: false),
                    User_AccountLastLoginTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountEntities", x => x.User_AccountGUID);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ArticleGUID = table.Column<Guid>(nullable: false),
                    OrderNumber = table.Column<int>(nullable: false),
                    Row_ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArticlePigeonholeClassificationGUID = table.Column<Guid>(nullable: false),
                    ArticleWriter = table.Column<Guid>(nullable: false),
                    ArticleContentURL = table.Column<string>(maxLength: 128, nullable: true),
                    ArticleCreateTime = table.Column<DateTime>(nullable: false),
                    ArticleLastEditingTime = table.Column<int>(nullable: false),
                    ArticleReadNum = table.Column<int>(nullable: false),
                    ArticleTitle = table.Column<string>(maxLength: 32, nullable: true),
                    ArticleTitlePrefix = table.Column<string>(maxLength: 16, nullable: true),
                    ArticleSynopsis = table.Column<string>(maxLength: 300, nullable: true),
                    ArticleBackgroundImageURL = table.Column<string>(maxLength: 128, nullable: true),
                    ArticleVisualStatus = table.Column<int>(nullable: false),
                    ArticleStatus = table.Column<int>(nullable: false),
                    ArticleLoveNumber = table.Column<int>(nullable: false),
                    ArticleAversionNumber = table.Column<int>(nullable: false),
                    IsTop = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ArticleGUID);
                });

            migrationBuilder.CreateTable(
                name: "Attaches",
                columns: table => new
                {
                    Attach_GUID = table.Column<Guid>(nullable: false),
                    OrderNumber = table.Column<int>(nullable: false),
                    Row_ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Attach_MD5 = table.Column<string>(maxLength: 32, nullable: true),
                    Attach_Size = table.Column<int>(nullable: false),
                    Attach_Name = table.Column<string>(maxLength: 32, nullable: true),
                    Attach_ExtName = table.Column<string>(maxLength: 32, nullable: true),
                    Attach_Path = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attaches", x => x.Attach_GUID);
                });

            migrationBuilder.CreateTable(
                name: "PigeonholeClassifications",
                columns: table => new
                {
                    Article_PigeonholeClassificationGUID = table.Column<Guid>(nullable: false),
                    OrderNumber = table.Column<int>(nullable: false),
                    Row_ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Article_PigeonholeClassificationName = table.Column<string>(maxLength: 16, nullable: true),
                    Article_PigeonholeClassificationPGUID = table.Column<Guid>(nullable: false),
                    Article_PigeonholeClassificationDeepness = table.Column<byte>(nullable: false),
                    Article_PigeonholeClassificationClickNum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PigeonholeClassifications", x => x.Article_PigeonholeClassificationGUID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountEntities");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Attaches");

            migrationBuilder.DropTable(
                name: "PigeonholeClassifications");
        }
    }
}
