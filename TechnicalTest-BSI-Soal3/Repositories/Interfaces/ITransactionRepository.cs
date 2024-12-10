using TechnicalTest_BSI_Soal3.DTO;
using TechnicalTest_BSI_Soal3.Models;

namespace TechnicalTest_BSI_Soal3.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        List<CustomerSalesDto> GetTopSales();
        void AddTransactions(List<Transaction> transactions);
    }
}
