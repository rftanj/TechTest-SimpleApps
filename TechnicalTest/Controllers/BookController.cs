using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnicalTest.Helper;
using TechnicalTest.Models.DB;
using TechnicalTest.Models.DBContext;

namespace TechnicalTest.Controllers
{
    public class BookController : Controller
    {
        private readonly AppDBContext _context;

        public BookController(AppDBContext context)
        {
            _context = context;
        }
        public ActionResult Index(int? pageNumber)
        {
            int pageSize = 5;
            List<Book> data = _context.Books.ToList();

            var result = PaginationHelper<Book>.Create(
                data,
                pageNumber ?? 1,
                pageSize
            );

            return View(result);
        }

    }
}
