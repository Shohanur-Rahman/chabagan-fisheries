using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Chabagan.Fisheries.Data.Migrations
{
    /// <inheritdoc />
    public partial class addProjectTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Union = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WordNumber = table.Column<int>(type: "int", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Avatar", "CreatedBy", "IsDeleted", "Name", "Union", "UpdatedBy", "UpdatedDate", "WordNumber" },
                values: new object[,]
                {
                    { 1L, null, null, false, "চা বাগান 1", "", null, null, 0 },
                    { 2L, null, null, false, "চা বাগান 2", "", null, null, 0 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "5J4xJ9PtQ/T8snFHWnkqCb4Oo4JDm8mGGIx5Zl/YBjE=", "c/MFMrMT++KGQ8Tsj+12yA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "2vD3ds25N5nlCZnjmjiLcSVfgpwXrT+D5PCEx+J12ZM=", "c/MFMrMT++KGQ8Tsj+12yA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "5J4xJ9PtQ/T8snFHWnkqCb4Oo4JDm8mGGIx5Zl/YBjE=", "c/MFMrMT++KGQ8Tsj+12yA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "e4yDuw4R782qz0LM+YB2PGlkeFrwMnf0uAOI6EJ0U7I=", "1DgL2ySPFbp75XsXvcAqEg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "++/lzqbO02ducZbhy1ndMFLQez3mBbm9yDo+C59A4Io=", "1DgL2ySPFbp75XsXvcAqEg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "e4yDuw4R782qz0LM+YB2PGlkeFrwMnf0uAOI6EJ0U7I=", "1DgL2ySPFbp75XsXvcAqEg==" });
        }
    }
}
