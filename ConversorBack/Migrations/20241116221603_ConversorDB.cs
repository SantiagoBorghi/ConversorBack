using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConversorBack.Migrations
{
    /// <inheritdoc />
    public partial class ConversorDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Symbol = table.Column<string>(type: "TEXT", nullable: false),
                    IC = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    MaxConversions = table.Column<ulong>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SubscriptionId = table.Column<int>(type: "INTEGER", nullable: true),
                    TotalConversions = table.Column<ulong>(type: "INTEGER", nullable: true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Currencys",
                columns: new[] { "Id", "Code", "IC", "Name", "Symbol" },
                values: new object[,]
                {
                    { 1, "ARS", 0.0050000000000000001, "Peso Argentino", "$" },
                    { 2, "USD", 1.0, "US Dollar", "$" },
                    { 3, "EUR", 1.1000000000000001, "Euro", "€" },
                    { 4, "GBP", 1.3, "British Pound", "£" },
                    { 5, "JPY", 0.0070000000000000001, "Japanese Yen", "¥" },
                    { 6, "CAD", 0.75, "Canadian Dollar", "$" },
                    { 7, "AUD", 0.71999999999999997, "Australian Dollar", "$" },
                    { 8, "CHF", 1.05, "Swiss Franc", "$" }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "MaxConversions", "Type" },
                values: new object[,]
                {
                    { 1, 10ul, "Free" },
                    { 2, 100ul, "Standard" },
                    { 3, 999ul, "Pro" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Role", "SubscriptionId", "TotalConversions", "Username" },
                values: new object[] { 1, "admin@admin.com", "123456", 0, 3, 999ul, "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currencys");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
