using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TempoDeJogoAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddTempoDeJogoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataRegistro",
                table: "TemposDeJogo");

            migrationBuilder.AddColumn<int>(
                name: "Nota",
                table: "TemposDeJogo",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nota",
                table: "TemposDeJogo");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataRegistro",
                table: "TemposDeJogo",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");
        }
    }
}
