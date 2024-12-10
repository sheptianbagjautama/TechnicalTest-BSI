using Microsoft.EntityFrameworkCore;
using TechnicalTest_BSI_Soal3.Data;
using TechnicalTest_BSI_Soal3.DTO;
using TechnicalTest_BSI_Soal3.Models;
using TechnicalTest_BSI_Soal3.Repositories.Interfaces;

namespace TechnicalTest_BSI_Soal3.Repositories.TransactionRepository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _context;

        public TransactionRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<CustomerSalesDto> GetTopSales()
        {
            return _context.Transactions
                .FromSqlRaw(@"
                    SELECT 
                        TOP 100 PERCENT 
                        Customer_ID, 
                        COUNT(*) AS Total_Penjualan
                    FROM Transactions
                    GROUP BY Customer_ID
                    ORDER BY Total_Penjualan DESC
                ")
                .Select(x => new CustomerSalesDto
                {
                    Customer_ID = x.Customer_ID,
                    Total_Penjualan = _context.Transactions
                    .Count(t => t.Customer_ID == x.Customer_ID)
                })
                .ToList();
        }

        public void AddTransactions(List<Transaction> transactions)
        {
            _context.Transactions.AddRange(transactions);
            _context.SaveChanges();
        }
    }
}
