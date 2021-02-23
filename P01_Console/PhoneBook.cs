using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_Console
{
    class PhoneBook
    {

        public int Id { get; set; }
        public string PhonebookTitle { get; set; }
        public ICollection<Person> PhonebookPersonsList { get; set; }

        public int AddPhonebookAndPersons_OldWay()
        {
            AppDbContext db = new AppDbContext();

            PhoneBook phonebookObject = new PhoneBook();
            db.PhoneBooks.Add(phonebookObject);
            db.SaveChanges();

            Person person01 = new Person() { PersonPhonebookId = phonebookObject.Id, PersonFirstName = "reza" };
            Person person02 = new Person() { PersonPhonebookId = phonebookObject.Id, PersonFirstName = "ali" };
            db.Persons.Add(person01);
            db.Persons.Add(person02);
            db.SaveChanges();

            return phonebookObject.Id;
        }

        public int AddPhonebookAndPersons_NewWay()
        {
            PhoneBook phBook = new PhoneBook();
            phBook.PhonebookPersonsList = new List<Person>();
            Person person03 = new Person() { PersonFirstName = "sanaz" };
            Number numObject = new Number() { NumberCity = "shiraz" };
            person03.PersonNumbers = new List<Number>();
            Person person04 = new Person() { PersonFirstName = "somaye" };

            person03.PersonNumbers.Add(numObject);
            phBook.PhonebookPersonsList.Add(person03);
            phBook.PhonebookPersonsList.Add(person04);

            AppDbContext db = new AppDbContext();
            db.Add(phBook);
            db.SaveChanges();

            return phBook.Id;
        }

        public void PrintPhonebookWithPersonsInside(int id)
        {
            AppDbContext db = new AppDbContext();
            var phoneBookWithPersons = db.PhoneBooks.Include(x => x.PhonebookPersonsList);
            PhoneBook thePhonebook = phoneBookWithPersons.FirstOrDefault(v => v.Id == id);
            Console.WriteLine($"phone book id is: {thePhonebook.Id}");
            thePhonebook.PhonebookPersonsList.ToList().ForEach(p => Console.WriteLine(p));
        }



    }
}
