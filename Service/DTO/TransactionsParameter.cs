using Microsoft.AspNetCore.Mvc.Rendering;

namespace Service.DTO 
{ 
    public class TransactionsParameter
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string BookId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
