using XCompanyWebUI.Models.Entities;

namespace XCompanyWebUI.Models
{
    public class CompanyViewModel
    {
        public List<Expense>?  ExpenseList { get; set; }
        public List<Company>? CompanyList { get;set; }

        public Company? GetCompany { get; set; }
    }
}
