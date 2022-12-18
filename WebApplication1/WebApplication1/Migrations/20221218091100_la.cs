using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class la : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Datee = table.Column<DateTime>(nullable: false),
                    BestSaler = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false),
                    Payment = table.Column<int>(nullable: false),
                    Order_Date = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Customer = table.Column<int>(nullable: false),
                    CustomersId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Customer_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "A", "6ca7b6dd-7a53-4f0a-8f50-d34512f70575", "Administrator", "Administrator" },
                    { "B", "4b82780f-6390-42e5-bfe5-fb9d364986ef", "Customer", "Customer" },
                    { "C", "0fafc96c-8868-4a88-8d53-975cf8065137", "Storner", "Stornner" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "6563ad85-bb55-4d6f-b9b3-5305a9aa948d", "admin@fpt.com", true, false, null, null, "admin@fpt.com", "AQAAAAEAACcQAAAAEDhgPr45PkpD5kjx3bnT89qq1H9ToBkrcg9BK1YfGfoi12ah2afrKj6rCcJ7WzabvA==", null, false, "14300933-3e6a-4276-a93a-69914c43c640", false, "admin@fpt.com" },
                    { "2", 0, "c450da08-1010-4a59-82fb-dad915cb788f", "customer@fpt.com", true, false, null, null, "customer@fpt.com", "AQAAAAEAACcQAAAAEDb0QulCT9AJ5wrgaZyLPl03gPxqHxr4JbT/OLCSkDJA15UmtKtZF9VJpI/HXk6d4w==", null, false, "bbf6ef39-9911-4c2f-a889-a94f0ef36af3", false, "customer@fpt.com" },
                    { "3", 0, "f244c40e-8c7c-4ec4-b321-71122db5f2ab", "storner@fpt.com", true, false, null, null, "storner@fpt.com", "AQAAAAEAACcQAAAAEFQYR+Eb/nA/vmDOJlmZzcv/DRdxT2lB5ZsgNyMbADY4yM7q0+DSM10F0Jx5ojWvVA==", null, false, "985a0951-79e2-4a98-a11f-206bb8bc1136", false, "storner@fpt.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Horror" },
                    { 2, "Trinh Thám" },
                    { 3, "Thiếu Nhi" },
                    { 4, "Khoa Học Viễn Tưởng" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "1", "A" },
                    { "2", "B" },
                    { "3", "C" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "BestSaler", "CategoryId", "Datee", "Image", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { 1, "Smith", false, 1, new DateTime(2022, 12, 18, 16, 11, 0, 247, DateTimeKind.Local).AddTicks(8434), "https://th.bing.com/th/id/R.246f8ee1936955f5f1fa148c87e338d0?rik=6nmiN8y2BcarAQ&riu=http%3a%2f%2fwww.kroobannok.com%2fnews_pic%2fp37928861815.jpg&ehk=Hz7fNzyb41xHC%2fnEZkqMtkAX2OUAdzSezzeo5AympSQ%3d&risl=&pid=ImgRaw&r=0", "Nữ Hoàng Tuyết", 69999.0, "PDF" },
                    { 2, "Thomas", false, 1, new DateTime(2022, 12, 18, 16, 11, 0, 248, DateTimeKind.Local).AddTicks(7565), "https://th.bing.com/th/id/R.246f8ee1936955f5f1fa148c87e338d0?rik=6nmiN8y2BcarAQ&riu=http%3a%2f%2fwww.kroobannok.com%2fnews_pic%2fp37928861815.jpg&ehk=Hz7fNzyb41xHC%2fnEZkqMtkAX2OUAdzSezzeo5AympSQ%3d&risl=&pid=ImgRaw&r=0", "Hoàng Tử Gấu", 69999.0, "PDF" },
                    { 6, "Catary", false, 1, new DateTime(2022, 12, 18, 16, 11, 0, 248, DateTimeKind.Local).AddTicks(7626), "https://th.bing.com/th/id/R.246f8ee1936955f5f1fa148c87e338d0?rik=6nmiN8y2BcarAQ&riu=http%3a%2f%2fwww.kroobannok.com%2fnews_pic%2fp37928861815.jpg&ehk=Hz7fNzyb41xHC%2fnEZkqMtkAX2OUAdzSezzeo5AympSQ%3d&risl=&pid=ImgRaw&r=0", "Huyền Thoại Võ Thuật", 69999.0, "PDF" },
                    { 4, "Alpha", false, 2, new DateTime(2022, 12, 18, 16, 11, 0, 248, DateTimeKind.Local).AddTicks(7622), "https://th.bing.com/th/id/R.246f8ee1936955f5f1fa148c87e338d0?rik=6nmiN8y2BcarAQ&riu=http%3a%2f%2fwww.kroobannok.com%2fnews_pic%2fp37928861815.jpg&ehk=Hz7fNzyb41xHC%2fnEZkqMtkAX2OUAdzSezzeo5AympSQ%3d&risl=&pid=ImgRaw&r=0", "Vua Sư Tử", 69999.0, "PDF" },
                    { 3, "Thomson", false, 3, new DateTime(2022, 12, 18, 16, 11, 0, 248, DateTimeKind.Local).AddTicks(7620), "https://th.bing.com/th/id/R.246f8ee1936955f5f1fa148c87e338d0?rik=6nmiN8y2BcarAQ&riu=http%3a%2f%2fwww.kroobannok.com%2fnews_pic%2fp37928861815.jpg&ehk=Hz7fNzyb41xHC%2fnEZkqMtkAX2OUAdzSezzeo5AympSQ%3d&risl=&pid=ImgRaw&r=0", "Thợ Săn Bóng Đêm", 69999.0, "PDF" },
                    { 5, "Denta", false, 3, new DateTime(2022, 12, 18, 16, 11, 0, 248, DateTimeKind.Local).AddTicks(7624), "https://th.bing.com/th/id/R.246f8ee1936955f5f1fa148c87e338d0?rik=6nmiN8y2BcarAQ&riu=http%3a%2f%2fwww.kroobannok.com%2fnews_pic%2fp37928861815.jpg&ehk=Hz7fNzyb41xHC%2fnEZkqMtkAX2OUAdzSezzeo5AympSQ%3d&risl=&pid=ImgRaw&r=0", "Dải Ngân Hà", 69999.0, "PDF" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BookId",
                table: "Orders",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomersId",
                table: "Orders",
                column: "CustomersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
