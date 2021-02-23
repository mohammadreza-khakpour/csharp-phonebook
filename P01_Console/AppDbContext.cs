using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Console
{
    class AppDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<PhoneBook> PhoneBooks { get; set; }
        public DbSet<Number> Numbers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=PhonebookProjDB;Integrated Security=True");
        }

    }
}
