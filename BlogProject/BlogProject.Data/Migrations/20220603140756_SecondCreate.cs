using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace BlogProject.Data.Migrations
{
    public partial class SecondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedByName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    NormalizedName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Picture = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    About = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true),
                    FirstName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    LastName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    YoutubeLink = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    TwitterLink = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    InstagramLink = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    FacebookLink = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    LinkedInLink = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    GitHubLink = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    WebsiteLink = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    UserName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "VARCHAR(1000)", nullable: false),
                    Thumbnail = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    WievsCount = table.Column<int>(type: "int", nullable: false),
                    CommentCount = table.Column<int>(type: "int", nullable: false),
                    SeoAuthor = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    SeoDescription = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    SeoTags = table.Column<string>(type: "text", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedByName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedByName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name", "Note" },
                values: new object[,]
                {
                    { 1, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 588, DateTimeKind.Local).AddTicks(6740), "Blogs About Epic Fantasy Novels", true, false, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 588, DateTimeKind.Local).AddTicks(6750), "Epic Fantasy", "Epic Fantasy Novels" },
                    { 2, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 588, DateTimeKind.Local).AddTicks(6770), "Blogs About Science Fiction Novels", true, false, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 588, DateTimeKind.Local).AddTicks(6770), "Science Fiction", "Science Fiction Novels" },
                    { 3, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 588, DateTimeKind.Local).AddTicks(6780), "Blogs About Detective Thriller Novels", true, false, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 588, DateTimeKind.Local).AddTicks(6780), "Detective Thriller", "Detective Thriller Novels" },
                    { 4, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 588, DateTimeKind.Local).AddTicks(6780), "Blogs About Emotional Novels", true, false, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 588, DateTimeKind.Local).AddTicks(6780), "Emotional", "Emotional Novels" },
                    { 5, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 588, DateTimeKind.Local).AddTicks(6790), "Blogs About Romantic Novels", true, false, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 588, DateTimeKind.Local).AddTicks(6790), "Romantic", "Romantic Novels" },
                    { 6, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 588, DateTimeKind.Local).AddTicks(6800), "Blogs About Horror Novels", true, false, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 588, DateTimeKind.Local).AddTicks(6800), "Horror", "Horror Novels" },
                    { 7, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 588, DateTimeKind.Local).AddTicks(6800), "Blogs About Historical Novels", true, false, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 588, DateTimeKind.Local).AddTicks(6800), "Historical", "Historical Novels" },
                    { 8, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 588, DateTimeKind.Local).AddTicks(6810), "Blogs About Utopian Novels", true, false, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 588, DateTimeKind.Local).AddTicks(6810), "Utopian", "Utopian Novels" },
                    { 9, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 588, DateTimeKind.Local).AddTicks(6820), "Blogs About Mistery Novels", true, false, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 588, DateTimeKind.Local).AddTicks(6820), "Mistery", "Mistery Novels" },
                    { 10, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 588, DateTimeKind.Local).AddTicks(6820), "Blogs About Gothic Novels", true, false, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 588, DateTimeKind.Local).AddTicks(6830), "Gothic", "Gothic Novels" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 14, "40353775-2e8f-4b49-928e-c5ada9d38dd8", "Role.Read", "ROLE.READ" },
                    { 15, "868e6cf4-b89f-4ef3-bf43-c77a1cadf66a", "Role.Update", "ROLE.UPDATE" },
                    { 16, "f7b695a0-5f4f-4528-90c9-cbdfc489f863", "Role.Delete", "ROLE.DELETE" },
                    { 17, "571b777e-2789-4715-87b3-5e5819aea79d", "Comment.Create", "COMMENT.CREATE" },
                    { 22, "10d5d24c-9cc8-45c0-92e2-a1d177cf896c", "SuperAdmin", "SUPERADMIN" },
                    { 19, "298e3dce-d30e-4248-8320-3c0ad03f7f3a", "Comment.Update", "COMMENT.UPDATE" },
                    { 20, "ab70bd3a-b50f-4489-bdea-bf128bc4aac5", "Comment.Delete", "COMMENT.DELETE" },
                    { 21, "64243a74-3294-4128-8a76-ebce62a1b978", "AdminArea.Home.Read", "ADMINAREA.HOME.READ" },
                    { 13, "11966fcc-c942-4b4c-9bee-9ce48953e122", "Role.Create", "ROLE.CREATE" },
                    { 18, "a8e31266-67c3-486d-a349-ea7e4138465a", "Comment.Read", "COMMENT.READ" },
                    { 12, "0522a119-ea29-4200-b1a6-441e0642e6d6", "User.Delete", "USER.DELETE" },
                    { 7, "c3aacdac-3ed5-4e23-ba43-89102ca13dbe", "Article.Update", "ARTICLE.UPDATE" },
                    { 10, "d2d650ef-0e2d-460b-8da4-bfddb2be1e84", "User.Read", "USER.READ" },
                    { 9, "c475a94c-281b-4d6b-960e-5a238c42558e", "User.Create", "USER.CREATE" },
                    { 8, "dd95b383-d893-4b5f-bdd7-c0643844ac06", "Article.Delete", "ARTICLE.DELETE" },
                    { 6, "7c752695-ea5e-4771-9881-97e5b42319b7", "Article.Read", "ARTICLE.READ" },
                    { 5, "01b8c04f-f834-4887-b3aa-8b953321d8ad", "Article.Create", "ARTICLE.CREATE" },
                    { 4, "2d55863f-11a6-44d2-a911-4f208b01761a", "Category.Delete", "CATEGORY.DELETE" },
                    { 3, "f9704330-58f0-4a2d-80ab-ac6783e5c8b1", "Category.Update", "CATEGORY.UPDATE" },
                    { 2, "f9012897-6982-4602-96c9-dedf7d3902f0", "Category.Read", "CATEGORY.READ" },
                    { 1, "a72ea102-a6ec-451d-b100-27bf35329180", "Category.Create", "CATEGORY.CREATE" },
                    { 11, "f36e50ff-e15b-4910-a606-98677349c119", "User.Update", "USER.UPDATE" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FacebookLink", "FirstName", "GitHubLink", "InstagramLink", "LastName", "LinkedInLink", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Picture", "SecurityStamp", "TwitterLink", "TwoFactorEnabled", "UserName", "WebsiteLink", "YoutubeLink" },
                values: new object[,]
                {
                    { 1, "Admin User of ProgrammersBlog", 0, "bda701b1-85e8-41bb-b191-eddb47a8d53c", "adminuser@gmail.com", true, "https://facebook.com/adminuser", "Kutlu", "https://github.com/adminuser", "https://instagram.com/adminuser", "Özdemir", "https://linkedin.com/adminuser", false, null, "ADMINUSER@GMAIL.COM", "ADMINUSER", "AQAAAAEAACcQAAAAEJQ6GtnhQSwMDVbisBk3JH0upesEIriocGoBeR7MxYDDyk5dIDr2nZ4G2+/7UGlfZQ==", "+905417415083", true, "userImages/defaultUser.png", "53c36dc1-145f-44cf-b0a7-600a51d3c2d3", "https://twitter.com/adminuser", false, "adminuser", "https://programmersblog.com/", "https://youtube.com/adminuser" },
                    { 2, "Editor User of ProgrammersBlog", 0, "46245f9c-7877-4865-9634-4aed4a6e1e5f", "editoruser@gmail.com", true, "https://facebook.com/editoruser", "Bahadır", "https://github.com/editoruser", "https://instagram.com/editoruser", "Özdemir", "https://linkedin.com/editoruser", false, null, "EDITORUSER@GMAIL.COM", "EDITORUSER", "AQAAAAEAACcQAAAAEDpMjZxooaAhP0IGl4YPwe/6NLkMmEsYEikBfIlidoGyqDKckFf9wfarea5eCyeJBg==", "+905437348733", true, "userImages/defaultUser.png", "c598b97b-175e-4c4c-a49f-99a7f7e84ff7", "https://twitter.com/editoruser", false, "editoruser", "https://programmersblog.com/", "https://youtube.com/editoruser" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "CommentCount", "Content", "CreatedByName", "CreatedDate", "Date", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "SeoAuthor", "SeoDescription", "SeoTags", "Thumbnail", "Title", "UserId", "WievsCount" },
                values: new object[,]
                {
                    { 1, 1, 1, "The future of civilization rests in the fate of the One Ring, which has been lost for centuries. Powerful forces are unrelenting in their search for it. But fate has placed it in the hands of a young Hobbit named Frodo Baggins, who inherits the Ring and steps into legend. A daunting task lies ahead for Frodo when he becomes the Ringbearer to destroy the One Ring in the fires of Mount Doom where it was forged.", "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 584, DateTimeKind.Local).AddTicks(4180), new DateTime(2022, 6, 3, 17, 7, 55, 584, DateTimeKind.Local).AddTicks(2320), true, false, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 584, DateTimeKind.Local).AddTicks(4590), "About Lord Of The Lord of the Rings: The Fellowship of the Ring Novel", "Kutlu Özdemir", "About Lord Of The Lord of the Rings: The Fellowship of the Ring Novel", "Lord Of The Lord of the Rings, Epic Fantasy, Novel, Tolkien", "postImages/defaultThumbnail.jpg", "Lord Of The Lord of the Rings: The Fellowship of the Ring", 1, 10 },
                    { 10, 10, 1, "When astronauts blast off from the planet Mars, they leave behind Mark Watney, presumed dead after a fierce storm. With only a meager amount of supplies, the stranded visitor must utilize his wits and spirit to find a way to survive on the hostile planet. Meanwhile, back on Earth, members of NASA and a team of international scientists work tirelessly to bring him home, while his crew mates hatch their own plan for a daring rescue mission.", "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 584, DateTimeKind.Local).AddTicks(6430), new DateTime(2022, 6, 3, 17, 7, 55, 584, DateTimeKind.Local).AddTicks(6420), true, false, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 584, DateTimeKind.Local).AddTicks(6430), "About Frankenstein Novel", "Kutlu Özdemir", "About Frankenstein Novel", "Frankenstein, Gothic, Novel, Mary Shelley", "postImages/defaultThumbnail.jpg", "Frankenstein", 1, 10 },
                    { 8, 8, 1, "In A Modern Utopia, two travelers fall into a space-warp and suddenly find themselves upon a Utopian Earth controlled by a single World Government.", "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 584, DateTimeKind.Local).AddTicks(6410), new DateTime(2022, 6, 3, 17, 7, 55, 584, DateTimeKind.Local).AddTicks(6410), true, false, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 584, DateTimeKind.Local).AddTicks(6410), "About A Modern Utopia Novel", "Kutlu Özdemir", "About A Modern Utopia Novel", "A Modern Utopia, Utopian, Novel, H. G. Wells", "postImages/defaultThumbnail.jpg", "A Modern Utopia", 1, 10 },
                    { 7, 7, 1, "A Tale of Two Cities, by Charles Dickens, deals with the major themes of duality, revolution, and resurrection. It was the best of times, it was the worst of times in London and Paris, as economic and political unrest lead to the American and French Revolutions.", "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 584, DateTimeKind.Local).AddTicks(6400), new DateTime(2022, 6, 3, 17, 7, 55, 584, DateTimeKind.Local).AddTicks(6400), true, false, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 584, DateTimeKind.Local).AddTicks(6400), "About A Tale of Two Cities Novel", "Kutlu Özdemir", "About A Tale of Two Cities Novel", "A Tale of Two Cities, Historical, Novel, Charles Dickens", "postImages/defaultThumbnail.jpg", "A Tale of Two Cities", 1, 10 },
                    { 6, 6, 1, "It is a 1986 horror novel by American author Stephen King. It was his 22nd book and his 17th novel written under his own name. The story follows the experiences of seven children as they are terrorized by an evil entity that exploits the fears of its victims to disguise itself while hunting its prey.", "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 584, DateTimeKind.Local).AddTicks(6390), new DateTime(2022, 6, 3, 17, 7, 55, 584, DateTimeKind.Local).AddTicks(6390), true, false, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 584, DateTimeKind.Local).AddTicks(6390), "About The IT Novel", "Kutlu Özdemir", "About The IT Novel", "IT, Horror, Novel, Stephen King", "postImages/defaultThumbnail.jpg", "IT", 1, 10 },
                    { 9, 9, 1, "The novel explores an alternative religious history, whose central plot point is that the Merovingian kings of France were descended from the bloodline of Jesus Christ and Mary Magdalene, ideas derived from Clive Prince's The Templar Revelation (1997) and books by Margaret Starbird.", "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 584, DateTimeKind.Local).AddTicks(6420), new DateTime(2022, 6, 3, 17, 7, 55, 584, DateTimeKind.Local).AddTicks(6420), true, false, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 584, DateTimeKind.Local).AddTicks(6420), "About The Da Vinci Code Novel", "Kutlu Özdemir", "About The Da Vinci Code Novel", "The Da Vinci Code, Mistery, Novel, Dan Brown", "postImages/defaultThumbnail.jpg", "The Da Vinci Code", 1, 10 },
                    { 4, 4, 1, "The Fault in Our Stars is a novel about love and death. The main character, Hazel, is a young woman who has been battling thyroid cancer for years. At a cancer support meeting, she meets Augustus, a young man who is recovering from cancer. He helps her break out of her shell and see the bright side of life.", "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 584, DateTimeKind.Local).AddTicks(6370), new DateTime(2022, 6, 3, 17, 7, 55, 584, DateTimeKind.Local).AddTicks(6370), true, false, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 584, DateTimeKind.Local).AddTicks(6380), "About The Fault in Our Stars Novel", "Kutlu Özdemir", "About The Fault in Our Stars Novel", "The Fault in Our Stars, Emotional, Novel, John Green", "postImages/defaultThumbnail.jpg", "The Fault in Our Stars", 1, 10 },
                    { 3, 3, 1, "In the tenth arrondissement of Paris, a rookie police inspector and a seasoned veteran called out of retirement investigate the horrific murders of three anonymous young women, illegal Turkish aliens who could not have deserved such a brutal, inhuman death.", "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 584, DateTimeKind.Local).AddTicks(6370), new DateTime(2022, 6, 3, 17, 7, 55, 584, DateTimeKind.Local).AddTicks(6360), true, false, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 584, DateTimeKind.Local).AddTicks(6370), "About The Empire of the Wolves Novel", "Kutlu Özdemir", "About The Empire of the Wolves Novel", "The Empire of the Wolves, Detective Thriller, Novel, Jean-Christophe Grange", "postImages/defaultThumbnail.jpg", "The Empire of the Wolves", 1, 10 },
                    { 2, 2, 1, "When astronauts blast off from the planet Mars, they leave behind Mark Watney, presumed dead after a fierce storm. With only a meager amount of supplies, the stranded visitor must utilize his wits and spirit to find a way to survive on the hostile planet. Meanwhile, back on Earth, members of NASA and a team of international scientists work tirelessly to bring him home, while his crew mates hatch their own plan for a daring rescue mission.", "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 584, DateTimeKind.Local).AddTicks(6360), new DateTime(2022, 6, 3, 17, 7, 55, 584, DateTimeKind.Local).AddTicks(6350), true, false, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 584, DateTimeKind.Local).AddTicks(6360), "About The Martian Novel", "Kutlu Özdemir", "About The Martian Novel", "The Martian, Science Fiction, Novel, Andy Weir", "postImages/defaultThumbnail.jpg", "The Martian", 1, 10 },
                    { 5, 5, 1, "The Notebook is an achingly tender story about the enduring power of love, a story of miracles that will stay with you forever. Set amid the austere beauty of coastal North Carolina in 1946, The Notebook begins with the story of Noah Calhoun, a rural Southerner returned home from World War II.", "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 584, DateTimeKind.Local).AddTicks(6380), new DateTime(2022, 6, 3, 17, 7, 55, 584, DateTimeKind.Local).AddTicks(6380), true, false, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 584, DateTimeKind.Local).AddTicks(6380), "About The Notebook Novel", "Kutlu Özdemir", "About The Notebook", "The Notebook, Romantic, Novel, Nicholas Sparks", "postImages/defaultThumbnail.jpg", "The Notebook", 1, 10 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 3, 2 },
                    { 20, 1 },
                    { 21, 1 },
                    { 22, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 4, 2 },
                    { 17, 2 },
                    { 6, 2 },
                    { 7, 2 },
                    { 8, 2 },
                    { 19, 1 },
                    { 18, 2 },
                    { 19, 2 },
                    { 5, 2 },
                    { 18, 1 },
                    { 13, 1 },
                    { 16, 1 },
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 },
                    { 7, 1 },
                    { 8, 1 },
                    { 9, 1 },
                    { 10, 1 },
                    { 11, 1 },
                    { 12, 1 },
                    { 20, 2 },
                    { 14, 1 },
                    { 15, 1 },
                    { 17, 1 },
                    { 21, 2 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ArticleId", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "Text" },
                values: new object[,]
                {
                    { 1, 1, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 591, DateTimeKind.Local).AddTicks(6460), true, false, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 591, DateTimeKind.Local).AddTicks(6470), "Comment About Lord Of The Lord of the Rings: The Fellowship of the Ring Novel", "This is the best thing I have ever read." },
                    { 2, 2, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 591, DateTimeKind.Local).AddTicks(6490), true, false, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 591, DateTimeKind.Local).AddTicks(6490), "Comment About The Martian Novel", "This novel take my breath away when i was reading" },
                    { 3, 3, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 591, DateTimeKind.Local).AddTicks(6500), true, false, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 591, DateTimeKind.Local).AddTicks(6500), "Comment About The Empire of the Wolves Novel", "It has been years since I read this book but I still remember the plot and characters in detail. This book started off very interesting for me; the main character suffers from partial amnesia, she forgets his husbands face but no-one elses. I was instantly pulled in and could not put this book down first. Writing is graphic and detailed, which I enjoyed. Too bad the ending was, in my opinion, terrible. I want to like this book more than I do, this had so much potential but the ending was boring and and at parts the plot went on relying too much on coincidence. Still, I enjoyed the beginning of this mystery very much." },
                    { 4, 4, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 591, DateTimeKind.Local).AddTicks(6500), true, false, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 591, DateTimeKind.Local).AddTicks(6510), "Comment About The Fault in Our Stars Novel", "I was unable to build any kind of connection to the characters. A lot of their actions seemed immature and childish to me. The main character is constantly saying how she wants everyone to treat her like a normal kid, but it's hard when she's constantly reminding you that she is dying, not reminding you that she has cancer and working through it, but that she is dying and that everything that is happening to her, is because she is dying..." },
                    { 5, 5, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 591, DateTimeKind.Local).AddTicks(6510), true, false, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 591, DateTimeKind.Local).AddTicks(6510), "Comment About The Notebook Novel", "Does such true love really exist? Nicholas Sparks, all I can tell is that your wife Cathy has been lucky to marry you!I cried like a baby.Yes, true love will return to you, maybe not in a very perfect condition, maybe with a fiancee, maybe not with a good heart, but surely it'll return." },
                    { 6, 6, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 591, DateTimeKind.Local).AddTicks(6520), true, false, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 591, DateTimeKind.Local).AddTicks(6520), "Comment About IT Novel", "Why yes, I did just complete my longest read to date. I simultaneously feel relieved and accomplished, drained and fulfilled. There are few authors who can successfully deliver such conflicting feelings, which is why he's one of the most well known names in the fiction world. I feel as if I could write an entire book about this tender and terrifying coming of age tale, but I also feel as if all the umph has left my body for the moment. Definitely my favorite King novel that I've read so far and I hope to revisit this review after a time of processing and reflection to add more thoughts. Thanks for all the hand holding and encouragement you all provided along the way!" },
                    { 7, 7, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 591, DateTimeKind.Local).AddTicks(6520), true, false, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 591, DateTimeKind.Local).AddTicks(6530), "Comment About A Tale of Two Cities Novel", "A wonderful fact to reflect upon, that every human creature is constituted to be that profound secret and mystery to every other. A solemn consideration, when I enter a great city by night, that every one of those darkly clustered houses encloses its own secret; that every room in every one of them encloses its own secret; that every beating heart in the hundreds of thousands of breasts there, is, in some of its imaginings, a secret to the heart nearest it!" },
                    { 8, 8, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 591, DateTimeKind.Local).AddTicks(6530), true, false, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 591, DateTimeKind.Local).AddTicks(6530), "Comment About A Modern Utopia Novel", "3 rating is like a neutral rating. This is a difficult book to get through but it might be of great use to students in social science and philosophy to understand the strength and weakness of some of the theories. One needs to be familiar with names like plato, aristotle, th more, Aquinas, comte, rousseau, marx.. Questions about social order, women place, political practice, religion (despite its contribution to equality) and culture problems are discussed but not solved, leaving the world at the starting point as we can easily see many years after the book was written!" },
                    { 9, 9, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 591, DateTimeKind.Local).AddTicks(6540), true, false, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 591, DateTimeKind.Local).AddTicks(6540), "Comment About The Da Vinci Code Novel", "For the most part, it seems that people either passionately love this book or they passionately hate it. I happen to be one of the former. For my part, I don't see the book so much as an indictment of the Catholic Church in particular but of religious extremism and religion interfering in political process in general. The unwarranted political control granted to extreme religious organizations like the CBN is an issue that we will be forced to address one way or the other. To my eye, our political process has been poisoned by it and the danger of theocracy is quite real. Furthermore, Brown's indictment of the Church for removing or suppressing feminine divinity figures is justified and needs a much closer look. Women do not have enough of a role in religion, religious practice, heroic myths, and creation myths, nor are they portrayed as divinity figures enough. In short, our religious systems and institutions lack balance and have a bias to suppress issues, stories, and roles that empower women to live as equals to men. Finally, Brown wrote his story simplistically, in my view, to spread his tale to as broad an audience as possible. Though it is not as pristine a narrative as, say, Umberto Eco, the message it conveys is one that needs to be heard. More obscure books on the matter are not as accessible as Da Vinci Code and if someone were to write an accessible book of genius on this subject, I would give him/her all due praise. In the meantime, Dan Brown is telling a story that needs to be told. It is one that has been kept quiet and in the dark for far too long." },
                    { 10, 10, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 591, DateTimeKind.Local).AddTicks(6540), true, false, "InitialCreate", new DateTime(2022, 6, 3, 17, 7, 55, 591, DateTimeKind.Local).AddTicks(6540), "Comment About Frankenstein Novel", "This is another book that i read in high school, but greatly appreciated it, even at that age. As a fan of comparing movie adaptions to books, I remember thinking ‘this is a hell of a lot different than the frankenstein that I knew.’ For one, the monster’s name isn’t Frankenstein, and he wasn’t just a mindless drone stumbling around. He was a highly intelligent, agile, and emotional creature. The film version with Robert Deniro was by far the most accurate, although not totally, depiction from what I remember, but it wasn’t widely acclaimed. This is still a very scary book and an absolute staple in horror literature. But the emotions of the monster were what I remember the most. From his admission to killing Victor’s brother and asking for forgiveness, to asking for the creation of a mate, his rage towards his creator, and just the back and forth dynamic between the monster and Victor was the highlight of the novel. The ending was very sad, but utterly satisfactory to this tale. Again, if you are a fan of horror, this is an absolute must read." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ArticleId",
                table: "Comments",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
