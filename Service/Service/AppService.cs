using Microsoft.EntityFrameworkCore;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTest.Models.DB;
using TechnicalTest.Models.DBContext;

namespace Service.Service
{
    public interface ITransaction
    {
        public List<TransactionDTO> GetTransaction();
        public Task AddTransaction(Transaction dto);
        public Task UpdateTransaction(Transaction dto);
        public Task DeleteTransaction(int id);
        public Transaction GetTransactionById(int id);
    }
    public class AppService : ITransaction
    {
        public readonly AppDBContext _context;

        public AppService(AppDBContext context)
        {
            _context = context;
        }

        public List<TransactionDTO> GetTransaction()
        {
            var transaction = _context.Transactions
               .Include(c => c.Customer)
               .Include(b => b.Book)
               .Select(x => new TransactionDTO()
               {
                   TransactionId = x.Id,
                   CustomerName = x.Customer.Name,
                   BookTitle = x.Book.Title,
                   BorrowDate = x.BorrowDate,
                   ReturnDate = x.ReturnDate,
                   CreatedDate = x.CreatedDate,
                   UpdatedDate = x.UpdatedDate,
               });
            return transaction.OrderByDescending(x => x.UpdatedDate).ToList();
        }

        public async Task AddTransaction(Transaction dto)
        {
            int? stock = _context.Books.Where(x => x.Id == dto.BookId && x.Stock >= 1).Select(x => x.Stock).FirstOrDefault();
            var book = _context.Books.Where(x => x.Id == dto.BookId).FirstOrDefault();

            if (stock != null && book is not null)
            {
                book.Stock = stock.Value - 1;
            }

            _context.Transactions.Add(dto);
            await _context.SaveChangesAsync();
        }

        public Transaction GetTransactionById(int id)
        {
            var data =  _context.Transactions.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }

        public async Task UpdateTransaction(Transaction dto)
        {
            var data = _context.Transactions.Where(x => x.Id == dto.Id).FirstOrDefault();
            if (data is null) throw new Exception("Data doesn't exist!");

            data.BookId = dto.BookId;
            data.CustomerId = dto.CustomerId;
            data.BorrowDate = dto.BorrowDate;
            data.ReturnDate = dto.ReturnDate;
            data.UpdatedDate = dto.UpdatedDate;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteTransaction(int id)
        {
            var data = _context.Transactions.Where(x => x.Id == id).FirstOrDefault();
            if (data is null) return;

            _context.Transactions.Remove(data);
            await _context.SaveChangesAsync();

        }
    }
}
