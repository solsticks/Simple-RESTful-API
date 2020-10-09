using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestfulAPI.Web.Migrations
{
    public partial class intialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 30, nullable: false),
                    Photo = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
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
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "9dcfa940-fab8-499d-bd81-6b3ba5d5c07c", 0, "25b40b3f-9b52-4d03-a39e-5420bd73df49", "olusola@adekan.com", false, "Olusola", "Adekan", false, null, null, null, null, null, false, "photo", "a28608e0-afa2-45b7-89e9-51cc957072a2", false, null },
                    { "20b7086c-dfb0-41ad-9a1b-ad554610be90", 0, "891f3762-b6c8-4eb8-b235-534f8fe2224e", "fred@chinazor.com", false, "Fred", "Chinazor", false, null, null, null, null, null, false, "photo", "c3764d59-5a4e-4661-a1e7-39fd5e7bbfd4", false, null },
                    { "22e227b5-14f2-4505-b569-ecdc1f249a20", 0, "0dbafa83-d6bf-4c7c-b0f0-a07dab21c2b5", "neto@anyankah.com", false, "Neto", "Anyankah", false, null, null, null, null, null, false, "photo", "14f43587-e410-42f1-beae-929e43790ef0", false, null },
                    { "5fbe4d7e-b93f-4ddd-93df-164345b37695", 0, "d3414c0b-45c1-4acd-84e7-204dea62786a", "law@mang.com", false, "Lawrence", "Mangdong", false, null, null, null, null, null, false, "photo", "ea4393bf-4789-422d-84a2-a8a770262eea", false, null },
                    { "ab4d4862-3306-48dc-8ecd-36c3950df6d3", 0, "9ffc0cd9-d5ca-4067-bbc0-56be60cc6883", "louis@otu.com", false, "Louis", "Otu", false, null, null, null, null, null, false, "photo", "98f3d5c8-e652-4c08-8902-2802baba06b2", false, null },
                    { "222fa466-f7d3-4085-819d-b4f2cdf804c7", 0, "2d3f91fd-f69e-4ad9-9671-b34052c7b0fe", "segun@maja.com", false, "Olusegun", "Adaramaja", false, null, null, null, null, null, false, "photo", "dc8e8383-8555-4020-9a71-7396095d4e59", false, null },
                    { "a6216ca3-6515-4702-a5c8-348c49b34c96", 0, "bbdeb7fb-7e05-4564-9da7-d005e45ef073", "victor@nwike.com", false, "Victor", "Nwike", false, null, null, null, null, null, false, "photo", "ac0fc952-5abf-46fc-b1da-07911e9c26f0", false, null },
                    { "bc294d38-d44a-4195-bc1c-8742fa108f35", 0, "cf70eae5-d91c-4d6f-966d-c0402b918474", "michael@nwosu.com", false, "Michael", "Nwosu", false, null, null, null, null, null, false, "photo", "451fc33e-a470-4ef4-a935-5749500d80a2", false, null },
                    { "d4b33f2d-6162-4c22-89fc-b611d1d1a0d8", 0, "bde447de-2f0a-4cd1-b84a-37970ffb9141", "seun@oye.com", false, "Oluwaseun", "Oyetoyan", false, null, null, null, null, null, false, "photo", "4c3b1106-a259-49c1-8e10-701f58a87596", false, null },
                    { "e07ecf77-f03e-4e20-af70-005d26ce7fcc", 0, "95cf1a74-240d-48ad-b707-60c67986794e", "Kosi@anwizu.com", false, "Kosi", "Nwizu", false, null, null, null, null, null, false, "photo", "019a5d8f-7425-4cea-95c8-4b566e07ea64", false, null },
                    { "41653087-fd87-43c3-8f30-9955545dcabc", 0, "f164b9e7-7cc0-4c56-8a3a-4e1f5e3e1702", "chidi@oko.com", false, "Chidi", "Okobia", false, null, null, null, null, null, false, "photo", "b731ec87-6092-4fdb-8c9b-a3df5a353ca5", false, null },
                    { "be310ecc-305f-4fe3-850d-5d2d263ad715", 0, "c8f2fe54-b075-45d5-bd4d-2cce0e9f216c", "tunde@ope.com", false, "Tunde", "Ope", false, null, null, null, null, null, false, "photo", "f31d50f6-2dc9-4204-991e-4482173bca5e", false, null },
                    { "a1c95170-0a58-4df3-bb2c-6dc65cb02f92", 0, "af1377ce-df38-4f76-81e0-75412af71f39", "ran@isi.com", false, "Ransom", "Isiah", false, null, null, null, null, null, false, "photo", "8857fa3f-5f38-4b58-846d-84903cc78fad", false, null }
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
