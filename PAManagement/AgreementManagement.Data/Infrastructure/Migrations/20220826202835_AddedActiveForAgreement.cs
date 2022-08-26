using Microsoft.EntityFrameworkCore.Migrations;

namespace AgreementManagement.Data.Infrastructure.Migrations
{
    public partial class AddedActiveForAgreement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Agreement",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Agreement");
        }
    }
}
