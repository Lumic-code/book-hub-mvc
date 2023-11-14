using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookHub.API.Migrations
{
    public partial class seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT Books (Id, Name, ISBN, DatePublished, Author, TotalPages, Portrait)" + 
                "VALUES('1', 'Jungle Book', '333-555-AB', '2000', 'Mogli', 30, 'Null')");

            migrationBuilder.Sql("INSERT Books (Id, Name, ISBN, DatePublished, Author, TotalPages, Portrait)" +
               "VALUES('2', 'The Gods are dead', '345-532-CD', '2001', 'Baba Ali', 10, 'Null')");

            migrationBuilder.Sql("INSERT Books (Id, Name, ISBN, DatePublished, Author, TotalPages, Portrait)" +
               "VALUES('3', 'Mothers Choice', '243-255-AB', '2005', 'Chike', 35, 'Null')");

            migrationBuilder.Sql("INSERT Books (Id, Name, ISBN, DatePublished, Author, TotalPages, Portrait)" +
             "VALUES('4', 'Fiery Blade', '350-200-FG', '2007', 'Bisi Akande', 50, 'Null')");

            migrationBuilder.Sql("INSERT Books (Id, Name, ISBN, DatePublished, Author, TotalPages, Portrait)" +
               "VALUES('5', 'Kung-fu Master', '167-535-ST', '2009', 'Josh', 100, 'Null')");

            migrationBuilder.Sql("INSERT Books (Id, Name, ISBN, DatePublished, Author, TotalPages, Portrait)" +
               "VALUES('6', 'The Incorruptible Judge', '245-515-UP', '2010', 'Bola', 150, 'Null')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
