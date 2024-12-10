using TechnicalTest_BSI_Soal3.DTO;
using TechnicalTest_BSI_Soal3.Models;

namespace TechnicalTest_BSI_Soal3.Services.Interfaces
{
    public interface ITransactionService
    {
        List<CustomerSalesDto> GetTopSales();
        void AddTransactions(List<Transaction> transactions);
    }
}
