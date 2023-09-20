using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnicalTest.Migrations
{
    /// <inheritdoc />
    public partial class InsertDefaultValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "books",
               columns: new[] { "Title", "Author", "ReleasedDate", "Stock", "CreatedDate", "UpdateDate" },
               values: new object[,]
               {
                    {"Harry Potter", "J.K. Rowling", Convert.ToDateTime("01/01/1997"), 100, DateTime.Now, DateTime.Now },
                    {"The Great Gatsby", "F. Scott Fitzgerald", Convert.ToDateTime("01/01/1925"), 100, DateTime.Now, DateTime.Now },
                    {"1984", "George Orwell", Convert.ToDateTime("01/01/1949"), 100, DateTime.Now, DateTime.Now },
                    {"Pride and Prejudice", "Jane Austen", Convert.ToDateTime("01/01/1813"), 100, DateTime.Now, DateTime.Now },
                    {"The Catcher in the Rye", "J.D. Salinger", Convert.ToDateTime("01/01/1951"), 100, DateTime.Now, DateTime.Now },
                    {"The Hobbit", "J.R.R. Tolkien", Convert.ToDateTime("01/01/1997"), 100, DateTime.Now, DateTime.Now },
                    {"The Da Vinci Code", "Dan Brown", Convert.ToDateTime("01/01/1937"), 100, DateTime.Now, DateTime.Now },
                    {"The Hunger Games", "Suzanne Collins", Convert.ToDateTime("01/01/2003"), 100, DateTime.Now, DateTime.Now },
                    {"Harry Potter", "Suzanne Collins", Convert.ToDateTime("01/01/2008"), 100, DateTime.Now, DateTime.Now },
                    {"The Alchemist", "Paulo Coelho", Convert.ToDateTime("01/01/1988"), 100, DateTime.Now, DateTime.Now },
               });

            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "Name", "Address", "City", "CreatedDate", "UpdatedDate" },
                values: new object[,]
                {
                    {"Harry", "Karet Kuningan", "South Jakarta", DateTime.Now, DateTime.Now },
                    {"Jhon", "Kemang", "South Jakarta", DateTime.Now, DateTime.Now },
                    {"Peter", "Tebet", "South Jakarta", DateTime.Now, DateTime.Now },
                    {"Derrick", "Kebayoran Baru", "South Jakarta", DateTime.Now, DateTime.Now },
                    {"Bryan", "Kebayoran Lama", "South Jakarta", DateTime.Now, DateTime.Now },
                    {"Sarah", "SCBD", "South Jakarta", DateTime.Now, DateTime.Now },
                    {"Sean", "Sudirman", "South Jakarta", DateTime.Now, DateTime.Now },
                    {"Scoot", "Pedurenan", "South Jakarta", DateTime.Now, DateTime.Now },
                    {"Samuel", "Kemayoran", "South Jakarta", DateTime.Now, DateTime.Now },
                    {"Yasmin", "Karet", "South Jakarta", DateTime.Now, DateTime.Now }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
