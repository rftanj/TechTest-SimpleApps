using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.Service;
using TechnicalTest.Models.DB;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {

        private ITransaction _service;
        public TransactionController(ITransaction service) 
        {
            _service = service;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        [Route("GetTransaction")]
        public IEnumerable<TransactionDTO> Get()
        {
            return _service.GetTransaction();
        }

        // GET api/<ValuesController>/5
        [HttpGet("GetTransactionById/{id}")]
        public Transaction Get(int id)
        {
            return _service.GetTransactionById(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        [Route("PostTransaction")]
        public async Task<IActionResult> Post([FromBody] SaveTransactionDTO dto)
        {
            try
            {
                var transaction = new Transaction
                {
                    BookId = dto.BookId,
                    CustomerId = dto.CustomerId,
                    BorrowDate = dto.BorrowDate,
                    ReturnDate = dto.ReturnDate,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                };

                await _service.AddTransaction(transaction);

                return Ok("Data already saved!");
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDTO() { Status = "Error", Message = ex.Message.ToString() });
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        [Route("UpdateTransaction")]
        public async Task<IActionResult> Put([FromBody] SaveTransactionDTO dto)
        {
            try
            {
                var transaction = new Transaction
                {
                    Id = dto.Id,
                    BookId = dto.BookId,
                    CustomerId = dto.CustomerId,
                    BorrowDate = dto.BorrowDate,
                    ReturnDate = dto.ReturnDate,
                    UpdatedDate = DateTime.Now,
                };

                await _service.UpdateTransaction(transaction);
                return Ok("Data already updated");
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDTO() { Status = "Error", Message = ex.Message.ToString() });
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("DeleteTransaction/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteTransaction(id);
                return Ok("Data already deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDTO() { Status = "Error", Message = ex.Message });
            }
        }
    }
}
