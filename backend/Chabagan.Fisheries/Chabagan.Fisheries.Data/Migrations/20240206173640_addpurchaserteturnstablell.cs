using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chabagan.Fisheries.Data.Migrations
{
    /// <inheritdoc />
    public partial class addpurchaserteturnstablell : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseReturnItems_Purchases_PurchaseId",
                table: "PurchaseReturnItems");

            migrationBuilder.RenameColumn(
                name: "PurchaseId",
                table: "PurchaseReturnItems",
                newName: "PurchaseReturnId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseReturnItems_PurchaseId",
                table: "PurchaseReturnItems",
                newName: "IX_PurchaseReturnItems_PurchaseReturnId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "aYCxPtaSdSdn8UPLggPgEMYS+1t6zI1ZHNFxDSEnPYs=", "GG+AU56DFHTLelZXU4nYHQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "IrH3r7bLIaZyoDKhTVvmBQ3zRthn2qzWfkWUjw6WXX8=", "GG+AU56DFHTLelZXU4nYHQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "aYCxPtaSdSdn8UPLggPgEMYS+1t6zI1ZHNFxDSEnPYs=", "GG+AU56DFHTLelZXU4nYHQ==" });

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseReturnItems_Purchases_PurchaseReturnId",
                table: "PurchaseReturnItems",
                column: "PurchaseReturnId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseReturnItems_Purchases_PurchaseReturnId",
                table: "PurchaseReturnItems");

            migrationBuilder.RenameColumn(
                name: "PurchaseReturnId",
                table: "PurchaseReturnItems",
                newName: "PurchaseId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseReturnItems_PurchaseReturnId",
                table: "PurchaseReturnItems",
                newName: "IX_PurchaseReturnItems_PurchaseId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "VUuYe8cBmFbAutIbR4L9K2sRR3ve8SxSHj3wQvuIQb8=", "5Nn+b6wZ3Qv4EKUu+Lx4tg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "ufEz/+1pJtRnz9KKT8Qkm72NznrCzkurdjz3f+Ef/5c=", "5Nn+b6wZ3Qv4EKUu+Lx4tg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { "VUuYe8cBmFbAutIbR4L9K2sRR3ve8SxSHj3wQvuIQb8=", "5Nn+b6wZ3Qv4EKUu+Lx4tg==" });

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseReturnItems_Purchases_PurchaseId",
                table: "PurchaseReturnItems",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
