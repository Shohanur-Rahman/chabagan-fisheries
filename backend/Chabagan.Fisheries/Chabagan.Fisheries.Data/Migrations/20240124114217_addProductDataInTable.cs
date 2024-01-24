using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Chabagan.Fisheries.Data.Migrations
{
    /// <inheritdoc />
    public partial class addProductDataInTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Avatar", "CategoryId", "CreatedBy", "Description", "IsDeleted", "MRP", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, null, 1L, null, "First, make sure you have Material-UI installed in your project:", false, 50.65m, "Napa Extra", null, null },
                    { 2L, null, 1L, null, "First, make sure you have Material-UI installed in your project:", false, 50.65m, "Peracitamol", null, null },
                    { 3L, null, 1L, null, "First, make sure you have Material-UI installed in your project:", false, 50.65m, "Filmate", null, null }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "die03m4DfbwcSQYW4HS8Cap1odoImprFv039WNTXDVE=", "rzVQjx1izZr54tywr4pz9w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "KmPRIKTwDFIJwTGIc41KIizKSMbWhWb6qfRzMRpPKAY=", "rzVQjx1izZr54tywr4pz9w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "die03m4DfbwcSQYW4HS8Cap1odoImprFv039WNTXDVE=", "rzVQjx1izZr54tywr4pz9w==" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_StockCategories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "StockCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_StockCategories_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "qYoY0I43OQxxEowDdKKcwybAtBa5puzQtcUwpirku44=", "m7U/J0PykrCb/eUIUDZ2UQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "eLMi63dOBmtp9bawOoz+rtoMx6tcUtG37m8PeV2MT7E=", "m7U/J0PykrCb/eUIUDZ2UQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "qYoY0I43OQxxEowDdKKcwybAtBa5puzQtcUwpirku44=", "m7U/J0PykrCb/eUIUDZ2UQ==" });
        }
    }
}
