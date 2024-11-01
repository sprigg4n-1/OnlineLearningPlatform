using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TimeLimit = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestsQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestsQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestsQuestion_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "Id", "CourseId", "Description", "TimeLimit", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Цей курс знайомить студентів з основами програмування, використовуючи C#.", 120, "Вступ до програмування" },
                    { 2, 2, "Курс призначений для студентів, які хочуть глибше зануритися в мову C#.", 100, "Поглиблене вивчення C#" }
                });

            migrationBuilder.InsertData(
                table: "TestsQuestion",
                columns: new[] { "Id", "QuestionText", "TestId" },
                values: new object[,]
                {
                    { 1, "Що таке змінна в C#?", 1 },
                    { 2, "Яка з цих конструкцій є циклом у C#?", 1 },
                    { 3, "Що таке клас у об'єктно-орієнтованому програмуванні?", 1 },
                    { 4, "Що таке алгоритм?", 2 },
                    { 5, "Яка структура даних є найкращою для реалізації стеку?", 2 },
                    { 6, "Що таке складність алгоритму?", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestsQuestion_TestId",
                table: "TestsQuestion",
                column: "TestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestsQuestion");

            migrationBuilder.DropTable(
                name: "Tests");
        }
    }
}
