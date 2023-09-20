using Microsoft.AspNetCore.Mvc.Rendering;

namespace TechnicalTest.Models
{
    public class TransactionsParameter
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string BookId { get; set; }
        public IEnumerable<SelectListItem> Customers { get; set; }
        public IEnumerable<SelectListItem> Books { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
