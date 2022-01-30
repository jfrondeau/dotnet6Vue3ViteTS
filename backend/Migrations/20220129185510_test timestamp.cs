using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnePunch.Migrations
{
    public partial class testtimestamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RecordAt2",
                table: "Record",
                type: "BLOB",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecordAt2",
                table: "Record");
        }
    }
}
