using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using XCompanyWebUI.Models;
using XCompanyWebUI.Models.DataAccess;
using XCompanyWebUI.Models.Entities;

namespace XCompanyWebUI.Controllers
{
    public class CompanyController : Controller
    {
        public static int companyId {get; set;}
        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CompanyExpens(int company,string? search)
        {
            companyId = company;

            XCompanyDb context = new();

            var Model = new CompanyViewModel
            {
                ExpenseList = search != null ?
                context.Expenses.ToList().Where(x => x.CompanyId == company && x.ExpensName.Contains(search)).ToList() :
                context.Expenses.ToList().Where(x => x.CompanyId == company).ToList(),
                
                
                CompanyList = context.Companies.ToList(),
                GetCompany= context.Companies.ToList().FirstOrDefault(x => x.CompanyId == company),
            };


           

            Model.GetCompany.CompanyDebt=VeriableSplitter.Split(Model.GetCompany.CompanyDebt); 
            foreach (var item in Model.ExpenseList)
            {
                item.ExpenseAmount = VeriableSplitter.Split(item.ExpenseAmount);
            }

            return View(Model);
        }
        [HttpPost]
        public IActionResult CompanyExpensAdd(Expense expense)
        {

            XCompanyDb context = new();

            context.Expenses.Add(expense);
            context.SaveChanges();
            

            DebtUpdate(expense);

            return Redirect($"/Company/CompanyExpens?company={companyId}");
        }

        public IActionResult CompanyDeptEdit(Expense expense)
        {

            XCompanyDb context = new();

            var UpdateCompany = context.Companies.FirstOrDefault(x => x.CompanyId == companyId);
            UpdateCompany.CompanyDebt = expense.ExpenseAmount;

            context.SaveChanges();


            return Redirect($"/Company/CompanyExpens?company={companyId}");

        }
        public IActionResult CompanyExpenseDelete(int delete)
        {

            XCompanyDb context = new();
            var DeleteExpensCompany = context.Expenses.FirstOrDefault(x => x.ExpendId == delete);

            context.Remove(DeleteExpensCompany);
            context.SaveChanges();

            return Redirect($"/Company/CompanyExpens?company={companyId}");
        }
        private void DebtUpdate(Expense expense)
        {
            XCompanyDb context = new();

            var UpdateCompany = context.Companies.FirstOrDefault(x => x.CompanyId == expense.CompanyId);
            UpdateCompany.CompanyDebt -= expense.ExpenseAmount;

            context.SaveChanges();


        }

        [HttpGet]
        public IActionResult CompanyAdd()
        {


            return View();
        }
        [HttpPost]
        public IActionResult CompanyAdd(Company company)
        {
            var contex = new XCompanyDb();

            contex.Add(company);
            contex.SaveChanges();


            return RedirectToAction("Index","Default");
        }
        [HttpGet]
        public IActionResult CompanyEdit()
        {
            var contex = new XCompanyDb();
            var result=contex.Companies.ToList();
            return View(result);
        }
        public IActionResult CompanyEdit(Company company)
        {

            return View();
        }
        public IActionResult CompanyDelete(int id)
        {
            XCompanyDb context = new();
            var DeleteCompany = context.Companies.FirstOrDefault(x => x.CompanyId == id);
            context.Remove(DeleteCompany);
            context.SaveChanges();
            return RedirectToAction("CompanyEdit");
        }
        
    }
}
