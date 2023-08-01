using Microsoft.EntityFrameworkCore;
using XCompanyWebUI.Models.Entities;

namespace XCompanyWebUI.Models.DataAccess
{
    public class XCompanyDb:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-KGO885A;Database=XSirketdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Expense> Expenses { get; set; }
    }
}
