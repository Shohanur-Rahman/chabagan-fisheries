using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Chabagan.Fisheries.Data.Migrations
{
    /// <inheritdoc />
    public partial class addTransectionTypeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransectionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransectionTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TransectionTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Purchase" },
                    { 2, "Purchase Return" },
                    { 3, "Sales" },
                    { 4, "Sales Return" },
                    { 5, "Income" },
                    { 6, "Expense" },
                    { 7, "Payment" },
                    { 8, "Collection" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "yqFks0YIf8g5HZp4mEaGshaSZGrq2aAd17LeGmWHpI0=", "9USm4RAo4WH1+OOCSgUUMw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "vZSr2Nch0/enjgqkTdcTWsBljnbqGfcBGiiKMoAPECg=", "9USm4RAo4WH1+OOCSgUUMw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "yqFks0YIf8g5HZp4mEaGshaSZGrq2aAd17LeGmWHpI0=", "9USm4RAo4WH1+OOCSgUUMw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransectionTypes");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "/ewFmFhxVt51uKq20Un339tCx5pKvuXAN+Lrj7391po=", "l1tllzd6wyBuqx/hhmvfUQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "OxFqBh1lRhPRH2Ag1CiI+636Ogrh+wjpHEhor79k4Tc=", "l1tllzd6wyBuqx/hhmvfUQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "/ewFmFhxVt51uKq20Un339tCx5pKvuXAN+Lrj7391po=", "l1tllzd6wyBuqx/hhmvfUQ==" });
        }
    }
}
