using Microsoft.AspNetCore.Mvc;
using XCompanyWebUI.Models.DataAccess;

namespace XCompanyWebUI.ViewComponents.Default
{
    public class _Navbar:ViewComponent
    {
        
        public IViewComponentResult Invoke()
        {
            using (XCompanyDb context=new())
            {
               var result= context.Companies.ToList();
               return View(result);

            }
            
        }
    }
}
