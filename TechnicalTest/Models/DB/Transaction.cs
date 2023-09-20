using System.ComponentModel.DataAnnotations.Schema;

namespace TechnicalTest.Models.DB
{
    public class Transaction
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int BookId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Book Book { get; set; }
    }
}
