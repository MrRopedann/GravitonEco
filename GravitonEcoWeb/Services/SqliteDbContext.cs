using GravitonEcoWeb.Model.DataBaseModel;
using Microsoft.EntityFrameworkCore;

namespace GravitonEcoWeb.Services
{
    public class SqliteDbContext : DbContext
    {
        public DbSet<ModbusParametrModel> ModbusParameters { get; set; }

        public SqliteDbContext(DbContextOptions<SqliteDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Дополнительные настройки для сущностей, если нужно
        }
    }

}
