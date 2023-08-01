using System.ComponentModel.DataAnnotations;

namespace XCompanyWebUI.Models.Entities
{
    public class Expense
    {
        [Key]
        public int ExpendId { get; set; }
        public int CompanyId { get; set; }
        public decimal ExpenseAmount { get; set; }
        public string? ExpensName { get; set; }
        public DateTime ExpenseDate { get; set; }
    }
}
