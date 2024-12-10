using System.ComponentModel.DataAnnotations;

namespace TechnicalTest_BSI_Soal3.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public string Customer_ID { get; set; }
        public DateTime Transaction_Date { get; set; }
    }
}
