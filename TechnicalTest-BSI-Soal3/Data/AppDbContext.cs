using Microsoft.EntityFrameworkCore;
using TechnicalTest_BSI_Soal3.Models;

namespace TechnicalTest_BSI_Soal3.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
