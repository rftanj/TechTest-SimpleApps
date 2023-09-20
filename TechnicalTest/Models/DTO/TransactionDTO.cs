namespace TechnicalTest.Models.DTO
{
    public class TransactionDTO
    {
        public int TransactionId { get; set; }
        public string CustomerName { get; set; }
        public string BookTitle { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
