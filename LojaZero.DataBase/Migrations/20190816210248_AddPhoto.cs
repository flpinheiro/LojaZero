using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaZero.Migrations
{
    public partial class AddPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Companies_CompanyId",
                schema: "LojaZero",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Person_PersonId",
                schema: "LojaZero",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Phone_Companies_CompanyId",
                schema: "LojaZero",
                table: "Phone");

            migrationBuilder.DropForeignKey(
                name: "FK_Phone_Person_PersonId",
                schema: "LojaZero",
                table: "Phone");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Companies_CompanyId",
                schema: "LojaZero",
                table: "Address",
                column: "CompanyId",
                principalSchema: "LojaZero",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Person_PersonId",
                schema: "LojaZero",
                table: "Address",
                column: "PersonId",
                principalSchema: "LojaZero",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Phone_Companies_CompanyId",
                schema: "LojaZero",
                table: "Phone",
                column: "CompanyId",
                principalSchema: "LojaZero",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Phone_Person_PersonId",
                schema: "LojaZero",
                table: "Phone",
                column: "PersonId",
                principalSchema: "LojaZero",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Companies_CompanyId",
                schema: "LojaZero",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Person_PersonId",
                schema: "LojaZero",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Phone_Companies_CompanyId",
                schema: "LojaZero",
                table: "Phone");

            migrationBuilder.DropForeignKey(
                name: "FK_Phone_Person_PersonId",
                schema: "LojaZero",
                table: "Phone");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Companies_CompanyId",
                schema: "LojaZero",
                table: "Address",
                column: "CompanyId",
                principalSchema: "LojaZero",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Person_PersonId",
                schema: "LojaZero",
                table: "Address",
                column: "PersonId",
                principalSchema: "LojaZero",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Phone_Companies_CompanyId",
                schema: "LojaZero",
                table: "Phone",
                column: "CompanyId",
                principalSchema: "LojaZero",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Phone_Person_PersonId",
                schema: "LojaZero",
                table: "Phone",
                column: "PersonId",
                principalSchema: "LojaZero",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
