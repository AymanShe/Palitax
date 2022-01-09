using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class seeddatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Country", "FullName", "State", "ZipCode" },
                values: new object[,]
                {
                    { 1, "US", "Bruno Mars", "NY", "10118" },
                    { 2, "CA", "Jim Carrey", "BC", "V6G 3E2" },
                    { 3, "FR", "Thierry Henry", null, "75008" },
                    { 4, "AU", "Nicole Kidman", null, "NSW 2000" },
                    { 5, "CA", "Carey Price", "QC", "H3G 0B7" },
                    { 6, "FR", "Jean Reno", null, "13281" },
                    { 7, "AU", "Mel Gibson", null, "VIC 3002" }
                });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "Id", "Description", "Price" },
                values: new object[,]
                {
                    { 1, "Hand Sanitizer", 13.95f },
                    { 2, "Dell p2419h Monitor", 449.99f },
                    { 3, "Delonghi Dedica Coffee Machine", 269.99f },
                    { 4, "Logitech MX Master 3 Mouse", 129.99f },
                    { 5, "BlackVue DR900X-2CH Plus DASH​CAM", 489.99f },
                    { 6, "Arduino Uno Rev3", 23f }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
