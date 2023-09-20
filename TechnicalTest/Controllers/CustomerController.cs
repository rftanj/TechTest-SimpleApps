using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnicalTest.Helper;
using TechnicalTest.Models.DB;
using TechnicalTest.Models.DBContext;

namespace TechnicalTest.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDBContext _context;

        public CustomerController(AppDBContext context)
        {
            _context = context;
        }
        public ActionResult Index(int? pageNumber)
        {

            int pageSize = 5;
            List<Customer> data = _context.Customers.ToList();

            var result = PaginationHelper<Customer>.Create(
                data,
                pageNumber ?? 1,
                pageSize
            );

            return View(result);
        }
    }
}
