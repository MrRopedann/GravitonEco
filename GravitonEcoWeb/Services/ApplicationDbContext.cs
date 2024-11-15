using GravitonEcoWeb.Model.DataBaseModel;
using Microsoft.EntityFrameworkCore;

namespace GravitonEcoWeb.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
            Database.EnsureCreated();
        }

        public DbSet<ModbusParametrModel> ModbusParameters { get; set; }
    }
}
