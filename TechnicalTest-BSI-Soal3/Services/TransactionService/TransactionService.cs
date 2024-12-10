using TechnicalTest_BSI_Soal3.DTO;
using TechnicalTest_BSI_Soal3.Models;
using TechnicalTest_BSI_Soal3.Repositories.Interfaces;
using TechnicalTest_BSI_Soal3.Services.Interfaces;

namespace TechnicalTest_BSI_Soal3.Services.TransactionService
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _repository;

        public TransactionService(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public List<CustomerSalesDto> GetTopSales()
        {
            return _repository.GetTopSales();
        }

        public void AddTransactions(List<Transaction> transactions)
        {
            _repository.AddTransactions(transactions);
        }
    }
}
