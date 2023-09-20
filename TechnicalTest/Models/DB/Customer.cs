using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechnicalTest.Models.DB
{

    [Table("customers")]
    public class Customer
    {

        [Key]
        public int Id { get; set; }

        //[Required]
        //public string MemberNumber { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
