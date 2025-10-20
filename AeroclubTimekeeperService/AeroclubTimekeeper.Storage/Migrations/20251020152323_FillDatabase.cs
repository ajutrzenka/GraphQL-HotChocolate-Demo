using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AeroclubTimekeeper.Storage.Migrations
{
    /// <inheritdoc />
    public partial class FillDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = Utils.EmbeddedFileReader.ReadContent("SQL/FillDatabase.sql");
            migrationBuilder.Sql(sql);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

