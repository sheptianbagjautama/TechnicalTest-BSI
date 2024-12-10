using Microsoft.AspNetCore.Mvc;
using TechnicalTest_BSI_Soal3.Data;
using TechnicalTest_BSI_Soal3.Models;

namespace TechnicalTest_BSI_Soal3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TransactionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("AddTransactions")]
        public IActionResult AddTransactions([FromBody] List<Transaction> transactions)
        {
            if (transactions == null || !transactions.Any())
                return BadRequest("Data transaksi tidak valid.");

            _context.Transactions.AddRange(transactions);
            _context.SaveChanges();
            return Ok("Data berhasil disimpan.");
        }

        [HttpGet("GetTopSales")]
        public IActionResult GetTopSales()
        {
            var result = _context.Transactions
                .GroupBy(t => t.Customer_ID)
                .Select(group => new
                {
                    Customer_ID = group.Key,
                    Total_Penjualan = group.Count()
                })
                .OrderByDescending(x => x.Total_Penjualan)
                .ToList();

            return Ok(result);
        }
    }
}
