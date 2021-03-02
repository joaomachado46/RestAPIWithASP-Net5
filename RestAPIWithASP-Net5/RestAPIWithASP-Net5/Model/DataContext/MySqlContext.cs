using Microsoft.EntityFrameworkCore;
using System;

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
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(
                 new Person
                 {
                     Id = 1,
                     FirstName = "João",
                     LastName = "Machado",
                     Address = "Famalicão",
                     Gender = "Masculino",
                 },
                 new Person
                 {
                     Id = 2,
                     FirstName = "Francisca",
                     LastName = "Machado",
                     Address = "Famalicão",
                     Gender = "Feminino",
                 },
                  new Person
                  {
                      Id = 3,
                      FirstName = "Vânia",
                      LastName = "Silva",
                      Address = "Famalicão",
                      Gender = "Feminino",
                  }, new Person
                  {
                      Id = 4,
                      FirstName = "Manel",
                      LastName = "Antonio",
                      Address = "Famalicão",
                      Gender = "Masculino",
                  }
                );
        }

    }
}
