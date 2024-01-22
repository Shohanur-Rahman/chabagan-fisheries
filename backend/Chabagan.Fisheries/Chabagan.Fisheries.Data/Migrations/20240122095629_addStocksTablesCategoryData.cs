using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Chabagan.Fisheries.Data.Migrations
{
    /// <inheritdoc />
    public partial class addStocksTablesCategoryData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StockCategories",
                columns: new[] { "Id", "CreatedBy", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, null, false, "Medicine", null, null },
                    { 2L, null, false, "Feed", null, null },
                    { 3L, null, false, "Accessories", null, null }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StockCategories",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "StockCategories",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "StockCategories",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "7UaTfi1q2G3LePfz75Oe+xL/kDWP+tgBjomZyVDxLwo=", "jyCWitSTKtTtlmX3FeWTPg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "HnIsExf5nNoZqFQdGghIcmgwPIGBF6uqx2yM2pPk1sM=", "jyCWitSTKtTtlmX3FeWTPg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "7UaTfi1q2G3LePfz75Oe+xL/kDWP+tgBjomZyVDxLwo=", "jyCWitSTKtTtlmX3FeWTPg==" });
        }
    }
}
