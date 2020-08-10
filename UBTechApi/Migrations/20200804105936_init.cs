using Microsoft.EntityFrameworkCore.Migrations;

namespace UBTechApi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Role = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Age", "FirstName", "LastName", "Role" },
                values: new object[,]
                {
                    { 1, 30, "John", "Doe", "CTO" },
                    { 2, 25, "Mosh", "Zeev", "Dev" },
                    { 3, 28, "Guy", "Tzof", "QA" },
                    { 4, 24, "Noam", "Cohen", "Dev" },
                    { 5, 30, "Avi", "Avraham", "PO" },
                    { 6, 22, "Yochai", "Moalem", "Dev" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
