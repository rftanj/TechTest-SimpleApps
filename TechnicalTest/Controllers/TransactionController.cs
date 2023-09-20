using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnicalTest.Models.DBContext;
using TechnicalTest.Models.DTO;
using TechnicalTest.Models.DB;
using Newtonsoft.Json;
using TechnicalTest.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;
using TechnicalTest.Helper;

namespace TechnicalTest.Controllers
{
    public class TransactionController : Controller
    {
        private readonly AppDBContext _context;
        private readonly IConfiguration _configuration;

        public TransactionController(AppDBContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
        }
        // GET: TransactionController
        public async Task<ActionResult> Index(int? pageNumber)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_configuration["ApiUrl"]);
            var response = await httpClient.GetAsync("GetTransaction");
            var content = await response.Content.ReadAsStringAsync();
            var transactions = JsonConvert.DeserializeObject<List<TransactionDTO>>(content);

            int pagesize = 10;
            var result = PaginationHelper<TransactionDTO>.Create(transactions, pageNumber ?? 1, pagesize);

            return View(result);
        }
        
        // GET: TransactionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TransactionController/Create
        public ActionResult Create()
        {
            var datas = new TransactionsParameter();
            datas.Books = _context.Books.Where(x => x.Stock >= 1)
                .Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Title
                });

            datas.Customers = _context.Customers
                .Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                });

            return View(datas);
        }

        // POST: TransactionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TransactionsParameter collection)
        {
            try
            {
                var json = JsonConvert.SerializeObject(collection);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(_configuration["ApiUrl"]);

                var response = await httpClient.PostAsync("PostTransaction", content);
                ViewBag.Success = "Data create succefully!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                var err = ex.Message.ToString();
                return View(err);
            }
        }

        // GET: TransactionController/Edit/5
        public async Task<IActionResult> Update(int id)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_configuration["ApiUrl"]);
            var response = await httpClient.GetAsync($"GetTransactionById/{id}");
            var contents = await response.Content.ReadAsStringAsync();
            var transactions = JsonConvert.DeserializeObject<TransactionAPIDTO>(contents);

            transactions.Customers = _context.Customers
                .Where(x => x.Id == transactions.CustomerId)
                .Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name,
                    Selected = true
                });
            transactions.Books = _context.Books
                .Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Title,
                    Selected = x.Id == transactions.BookId
                });

            return View(transactions);
        }

        // POST: TransactionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(TransactionAPIDTO dto)
        {
            try
            {
                var json = JsonConvert.SerializeObject(dto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(_configuration["ApiUrl"]);

                var response = await httpClient.PutAsync("UpdateTransaction", content);
                ViewBag.Success = true;
                ViewBag.Message = "Data update succefully!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = "Failed update the data!";
                return View();
            }
        }

        // POST: TransactionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(_configuration["ApiUrl"]);
                var response = await httpClient.DeleteAsync($"DeleteTransaction/{id}");
                ViewBag.Success = "Data delete succefully!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
