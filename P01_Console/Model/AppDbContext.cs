using Microsoft.EntityFrameworkCore;
using P01_Console.Model.classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Console
{
    class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<PhoneBook> PhoneBooks { get; set; }
        public DbSet<Number> Numbers { get; set; }
        public DbSet<Email> Emails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=PhonebookProjDB;Integrated Security=True");
        }

    }
}
