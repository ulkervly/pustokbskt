using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PustokPractice.Migrations
{
    public partial class IsFeatured_New_Bestseller : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Sliders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Genre",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "BookTags",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Books",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Authors",
                newName: "Id");

            migrationBuilder.AddColumn<bool>(
                name: "IsBestseller",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFeatured",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNew",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "BookImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPoster = table.Column<bool>(type: "bit", nullable: true),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookImages_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookImages_BookId",
                table: "BookImages",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookImages");

            migrationBuilder.DropColumn(
                name: "IsBestseller",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IsFeatured",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IsNew",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Sliders",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Genre",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BookTags",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Books",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Authors",
                newName: "id");
        }
    }
}
