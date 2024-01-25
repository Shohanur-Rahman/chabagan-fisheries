using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Chabagan.Fisheries.Data.Migrations
{
    /// <inheritdoc />
    public partial class addPondsTableAndData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ponds",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ponds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ponds_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ponds",
                columns: new[] { "Id", "Avatar", "CreatedBy", "IsDeleted", "Name", "ProjectId", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, null, null, false, "মধুমতি", 1L, null, null },
                    { 2L, null, null, false, "সূর্যমুখী", 1L, null, null },
                    { 3L, null, null, false, "নীলকন্যা", 2L, null, null }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "gINc8MVVO80vbeWwR0SCVwPDQQF071sZvt2fU8bF4TY=", "rjsXl/G6YskPK+k8vUm1BA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "LRI/ROFp9loy+1e+s566pzYHXqLc1xq2GfO7RShzbPQ=", "rjsXl/G6YskPK+k8vUm1BA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "gINc8MVVO80vbeWwR0SCVwPDQQF071sZvt2fU8bF4TY=", "rjsXl/G6YskPK+k8vUm1BA==" });

            migrationBuilder.CreateIndex(
                name: "IX_Ponds_ProjectId",
                table: "Ponds",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ponds");

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
    }
}
