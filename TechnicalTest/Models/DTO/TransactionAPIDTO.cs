using Microsoft.AspNetCore.Mvc.Rendering;

namespace TechnicalTest.Models.DTO
{
    public class TransactionAPIDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int BookId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public IEnumerable<SelectListItem> Customers { get; set; }
        public IEnumerable<SelectListItem> Books { get; set; }
    }
}
