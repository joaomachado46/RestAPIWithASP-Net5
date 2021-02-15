using Microsoft.EntityFrameworkCore;

namespace RestAPIWithASP_Net5.Model.DataContext
{
    public class MySqlContext : DbContext
    {
        public MySqlContext()
        {
        }

        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }

    }
}
