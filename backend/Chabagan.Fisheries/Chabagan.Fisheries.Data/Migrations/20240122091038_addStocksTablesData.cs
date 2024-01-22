using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Chabagan.Fisheries.Data.Migrations
{
    /// <inheritdoc />
    public partial class addStocksTablesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedBy", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, null, false, "Squre", null, null },
                    { 2L, null, false, "Beximco", null, null },
                    { 3L, null, false, "Ibn Sina", null, null }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "07iV+rF43zDBz2df1uReV7B4gTKPpY0cP3d6NU3QF8Q=", "57TETcjwkafQZPlZihyp6w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "c7L0YxMPzjlioab6cRGqNSWKb/uXTw8QKgunEs+t1pg=", "57TETcjwkafQZPlZihyp6w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "07iV+rF43zDBz2df1uReV7B4gTKPpY0cP3d6NU3QF8Q=", "57TETcjwkafQZPlZihyp6w==" });
        }
    }
}
