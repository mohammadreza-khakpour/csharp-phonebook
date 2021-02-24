using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_Console
{
    class PhoneBook
    {

        public int Id { get; set; }
        public string PhonebookTitle { get; set; }
        public ICollection<Number> PhonebookNumbers { get; set; }

        public int PhonebookPersonId { get; set; }
        [ForeignKey("PhonebookPersonId")]
        public Person PhonebookPerson { get; set; }


        public int AddPhonebook()
        {
            var db = ObjectProvider.MakeDbInstance();
            PhoneBook aPhonebook = ObjectProvider.MakePhonebookInstance();
            Console.Write("Enter phonebook's title: ");
            aPhonebook.PhonebookTitle = Console.ReadLine();
            Console.Write("Enter the id of belonging person: ");
            aPhonebook.PhonebookPersonId = int.Parse(Console.ReadLine());
            db.Add(aPhonebook);
            db.SaveChanges();
            return aPhonebook.Id;
        }

        public int DeletePhonebook()
        {
            var db = ObjectProvider.MakeDbInstance();
            Console.Write("Enter phonebook's id: ");
            int id = int.Parse(Console.ReadLine());
            db.Remove(db.PhoneBooks.FirstOrDefault(x => x.Id == id));
            db.SaveChanges();
            return id;
        }

        public PhoneBook FindPhonebook()
        {
            Console.Write("Enter phonebook's id: ");
            int id = int.Parse(Console.ReadLine());
            var db = ObjectProvider.MakeDbInstance();
            return db.PhoneBooks.FirstOrDefault(x => x.Id == id);
        }

        public int UpdatePhonebook()
        {
            PhoneBook foundPhonebook = FindPhonebook();
            Console.Write("Enter new phonebook title: ");
            foundPhonebook.PhonebookTitle = Console.ReadLine();
            Console.Write("Enter the id of belonging person: ");
            foundPhonebook.PhonebookPersonId = int.Parse(Console.ReadLine());
            var db = ObjectProvider.MakeDbInstance();
            db.Update(foundPhonebook);
            db.SaveChanges();
            return foundPhonebook.Id;
        }

        //public int AddPhonebookAndPersons_OldWay()
        //{
        //    AppDbContext db = new AppDbContext();

        //    PhoneBook phonebookObject = new PhoneBook();
        //    db.PhoneBooks.Add(phonebookObject);
        //    db.SaveChanges();

        //    Person person01 = new Person() { PersonPhonebookId = phonebookObject.Id, PersonFirstName = "reza" };
        //    Person person02 = new Person() { PersonPhonebookId = phonebookObject.Id, PersonFirstName = "ali" };
        //    db.Persons.Add(person01);
        //    db.Persons.Add(person02);
        //    db.SaveChanges();

        //    return phonebookObject.Id;
        //}


        //public int AddPhonebookAndPersons_NewWay()
        //{
        //    PhoneBook phBook = new PhoneBook();
        //    phBook.PhonebookPersonsList = new List<Person>();
        //    Person person03 = new Person() { PersonFirstName = "sanaz" };
        //    Number numObject = new Number() { NumberCity = "shiraz" };
        //    person03.PersonNumbers = new List<Number>();
        //    Person person04 = new Person() { PersonFirstName = "somaye" };

        //    person03.PersonNumbers.Add(numObject);
        //    phBook.PhonebookPersonsList.Add(person03);
        //    phBook.PhonebookPersonsList.Add(person04);

        //    AppDbContext db = new AppDbContext();
        //    db.Add(phBook);
        //    db.SaveChanges();

        //    return phBook.Id;
        //}


        //public void PrintPhonebookWithPersonsInside(int id)
        //{
        //    AppDbContext db = new AppDbContext();
        //    var phoneBookWithPersons = db.PhoneBooks.Include(x => x.PhonebookPersonsList);
        //    PhoneBook thePhonebook = phoneBookWithPersons.FirstOrDefault(v => v.Id == id);
        //    Console.WriteLine($"phone book id is: {thePhonebook.Id}");
        //    thePhonebook.PhonebookPersonsList.ToList().ForEach(p => Console.WriteLine(p));
        //}



    }
}
