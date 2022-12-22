using Microsoft.EntityFrameworkCore.Migrations;

namespace IsekaiDb.Migrations
{
    public partial class v01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "228ffaab-c99b-497e-ac86-80a53eaf2e9a", "88729eff-efdf-4742-bce8-dc5bb62de12d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "938d72f8-7a76-4ba9-ae7f-43438ae3f4a6", "c839d1ec-2861-42d0-9a3a-cc798f484f9c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "228ffaab-c99b-497e-ac86-80a53eaf2e9a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "938d72f8-7a76-4ba9-ae7f-43438ae3f4a6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "88729eff-efdf-4742-bce8-dc5bb62de12d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c839d1ec-2861-42d0-9a3a-cc798f484f9c");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Weapons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "20aa6fd0-6644-4b29-b79c-cd98ec738cf8", "1a1149ed-cc49-4f22-a75a-65a5e74abc00", "ADMINISTRATOR", null },
                    { "dcaf37ef-4c11-4ce7-b2ef-e32e51a65aff", "89d54669-b6e6-4e80-a5cf-1a0f91307b12", "VISITOR", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "06efe430-9fe9-4357-a84d-6a72c9ec5d80", 0, "d1a8c612-e2af-4745-be72-6c4cbecd945c", "ApplicationUser", "lordardyn26@gmail.com", false, false, null, "LORDARDYN26@GMAIL.COM", "ARDYN", "AQAAAAEAACcQAAAAEGnHb0HxnM/BHa0fbCcO5am3Liz0TE8VZQdeB49LL+anV0v9datlIeH8UxR9cIKF/w==", null, false, "4f545099-5972-4353-bbef-2bdd4867171b", false, "Ardyn" },
                    { "276d7131-a53d-46fb-999e-c2d8b4210d97", 0, "4a2a95b3-e1e3-4bfe-ba29-ff5f55564d2b", "ApplicationUser", "remi-bellefleur71@gmail.com", false, false, null, "REMI-BELLEFLEUR71@GMAIL.COM", "GUTTENBERG71", "AQAAAAEAACcQAAAAEPxPLCD8K53aTqPdlNE4pcHMFvuFQU58mTx7LhJsuD3p9FygUr1WAPgWoKmrbiLjMA==", null, false, "4a1f1ac2-58e2-4605-8e3a-e6429fb50b59", false, "Guttenberg71" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "20aa6fd0-6644-4b29-b79c-cd98ec738cf8", "06efe430-9fe9-4357-a84d-6a72c9ec5d80" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "dcaf37ef-4c11-4ce7-b2ef-e32e51a65aff", "276d7131-a53d-46fb-999e-c2d8b4210d97" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "20aa6fd0-6644-4b29-b79c-cd98ec738cf8", "06efe430-9fe9-4357-a84d-6a72c9ec5d80" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "dcaf37ef-4c11-4ce7-b2ef-e32e51a65aff", "276d7131-a53d-46fb-999e-c2d8b4210d97" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20aa6fd0-6644-4b29-b79c-cd98ec738cf8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcaf37ef-4c11-4ce7-b2ef-e32e51a65aff");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06efe430-9fe9-4357-a84d-6a72c9ec5d80");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "276d7131-a53d-46fb-999e-c2d8b4210d97");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "Characters");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "938d72f8-7a76-4ba9-ae7f-43438ae3f4a6", "c98772ab-dff4-4f3d-8d88-715d4297ebfb", "ADMINISTRATOR", null },
                    { "228ffaab-c99b-497e-ac86-80a53eaf2e9a", "7bd82da3-bdd3-44c4-91e6-6c82b0dd072b", "VISITOR", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "c839d1ec-2861-42d0-9a3a-cc798f484f9c", 0, "83458b4a-43a5-45f6-98f4-130984ec6ad7", "ApplicationUser", "lordardyn26@gmail.com", false, false, null, "LORDARDYN26@GMAIL.COM", "ARDYN", "AQAAAAEAACcQAAAAEDEesOT/FSK5UColNuo8ZQWOE6lN3vHyBb6QkNJhG0+1KlM2xymY3upat9B1Kuu35Q==", null, false, "d4ae7bca-b975-4c7d-8f82-cadfecf7792e", false, "Ardyn" },
                    { "88729eff-efdf-4742-bce8-dc5bb62de12d", 0, "4e71eec7-21d1-4a88-9e05-fbbd7b2425da", "ApplicationUser", "remi-bellefleur71@gmail.com", false, false, null, "REMI-BELLEFLEUR71@GMAIL.COM", "GUTTENBERG71", "AQAAAAEAACcQAAAAECCKwkG0ZvfFYN3G6edk1jgOUL6yOgbX1bHX42BZINbf2HTJ2aWGxU69n+O+3E8+mw==", null, false, "1b2b2afc-b906-465c-804a-fb6c89f36f82", false, "Guttenberg71" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "938d72f8-7a76-4ba9-ae7f-43438ae3f4a6", "c839d1ec-2861-42d0-9a3a-cc798f484f9c" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "228ffaab-c99b-497e-ac86-80a53eaf2e9a", "88729eff-efdf-4742-bce8-dc5bb62de12d" });
        }
    }
}
