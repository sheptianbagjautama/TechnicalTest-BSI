using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnicalTest_BSI_Soal3.Data;
using TechnicalTest_BSI_Soal3.DTO;
using TechnicalTest_BSI_Soal3.Models;
using TechnicalTest_BSI_Soal3.Services.Interfaces;

namespace TechnicalTest_BSI_Soal3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _service;

        public TransactionController(ITransactionService service)
        {
            _service = service;
        }

        [HttpPost("AddTransactions")]
        public IActionResult AddTransactions([FromBody] List<Transaction> transactions)
        {
            if (transactions == null || transactions.Count == 0)
                return BadRequest("Data transaksi kosong.");

            _service.AddTransactions(transactions);
            return Ok("Data berhasil disimpan.");
        }

        [HttpGet("GetTopSales")]
        public IActionResult GetTopSales()
        {
            var result = _service.GetTopSales();
            return Ok(result);
        }
    }
}
