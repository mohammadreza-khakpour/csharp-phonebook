using Microsoft.EntityFrameworkCore;
using P01_Console.Model.classes;

namespace P01_Console
{
    interface IAppDbContext
    {
        DbSet<Number> Numbers { get; set; }
        DbSet<Person> Persons { get; set; }
        DbSet<PhoneBook> PhoneBooks { get; set; }
    }
}