using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SearchEngine.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Brand = table.Column<string>(type: "TEXT", nullable: false),
                    Model = table.Column<string>(type: "TEXT", nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    FuelType = table.Column<string>(type: "TEXT", nullable: false),
                    TyreSize = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    YearBorn = table.Column<string>(type: "TEXT", nullable: false),
                    Sex = table.Column<string>(type: "TEXT", nullable: false),
                    Height = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    AuthorName = table.Column<string>(type: "TEXT", nullable: false),
                    DocumentFormat = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "FuelType", "Model", "TyreSize", "Year" },
                values: new object[,]
                {
                    { 1, "Brand1", "Petrol", "Model1", 18, 2020 },
                    { 2, "Brand2", "Diesel", "Model2", 18, 2021 },
                    { 3, "Brand3", "Petrol", "Model3", 18, 2022 },
                    { 4, "Brand4", "Diesel", "Model4", 18, 2023 },
                    { 5, "Brand5", "Petrol", "Model5", 18, 2024 }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Height", "Name", "Sex", "YearBorn" },
                values: new object[,]
                {
                    { 1, 170, "Person 1", "Male", "1990" },
                    { 2, 170, "Person 2", "Female", "1990" },
                    { 3, 170, "Person 3", "Male", "1990" },
                    { 4, 170, "Person 4", "Female", "1990" },
                    { 5, 170, "Person 5", "Male", "1990" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "AuthorName", "DocumentFormat", "Name", "Year" },
                values: new object[,]
                {
                    { 1, "Author 1", "PDF", "Project 1", 2020 },
                    { 2, "Author 2", "DOCX", "Project 2", 2021 },
                    { 3, "Author 3", "PDF", "Project 3", 2022 },
                    { 4, "Author 4", "DOCX", "Project 4", 2023 },
                    { 5, "Author 5", "PDF", "Project 5", 2024 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
