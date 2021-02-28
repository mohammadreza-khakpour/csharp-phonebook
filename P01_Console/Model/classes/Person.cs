using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_Console
{
    class Person : IAnimal
    {
        private AppDbContext db;
        public Person(AppDbContext _db)
        {
            db = _db;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string EmailAddress { get; set; }
        public string WebsiteAddress { get; set; }
        public bool IsFemale { get; set; }
        public ICollection<PhoneBook> PersonPhonebooks { get; set; }




        public int Add()
        {
            //var db = ObjectProvider.MakeDbInstance();

            Person aPerson = ObjectProvider.MakePersonInstanceWithFullDetails();
            db.Add(aPerson);
            db.SaveChanges();
            return aPerson.Id;
        }

        public int Delete()
        {
            //var db = ObjectProvider.MakeDbInstance();
            
            Console.Write("Enter Person's id: ");
            int id = int.Parse(Console.ReadLine());
            db.Remove(db.Persons.FirstOrDefault(x => x.Id == id));
            db.SaveChanges();
            return id;
        }
        
        public int UpdatePersonTotally()
        {
            Person foundedPerson = FindPerson();
            // ask client if it just needs some specific editions
            Person person = ObjectProvider.MakePersonInstanceWithFullDetails();
            foundedPerson.FirstName = person.FirstName;
            foundedPerson.LastName = person.LastName;
            foundedPerson.FatherName = person.FatherName;
            foundedPerson.EmailAddress = person.EmailAddress;
            foundedPerson.WebsiteAddress = person.WebsiteAddress;
            //var db = ObjectProvider.MakeDbInstance();
            db.Update(foundedPerson);
            db.SaveChanges();
            return foundedPerson.Id;
        }

        public Person FindPerson()
        {
            Console.Write("Enter person's id: ");
            int id = int.Parse(Console.ReadLine());
            //var db = ObjectProvider.MakeDbInstance();
            return db.Persons.FirstOrDefault(x => x.Id == id);
        }

        public void PrintPersonNumbers()
        {
            //AppDbContext db = ObjectProvider.MakeDbInstance();
            Person person = FindPersonWithBelongingPhonebooks();
            person.PersonPhonebooks = FindPhonebooksWithBelongingNumbers(person.Id);
            person.PersonPhonebooks.ToList().ForEach(x =>
            {
                foreach (Number number in x.PhonebookNumbers)
                {
                    Console.WriteLine($"The number is: {number.ContactTitle}  {number.ContactValue}" +
                                         $" and belongs to {person.FirstName} {person.LastName}");
                }
                Console.WriteLine("--------------------");
            });
        }

        public Person FindPersonWithBelongingPhonebooks()
        {
            Console.Write("Enter person's id: ");
            int id = int.Parse(Console.ReadLine());
            //AppDbContext db = ObjectProvider.MakeDbInstance();
            var fromAllPersons = db.Persons.Include(x => x.PersonPhonebooks);
            Person person = fromAllPersons.FirstOrDefault(x => x.Id == id);
            return person;
        }

        public ICollection<PhoneBook> FindPhonebooksWithBelongingNumbers(int personId)
        {
            //AppDbContext db = ObjectProvider.MakeDbInstance();
            var fromAllPhonebooks = db.PhoneBooks.Include(x => x.PhonebookNumbers);
            var phonebooksIncludingNumbers = fromAllPhonebooks.Where(x => x.PhonebookPersonId == personId).ToList();
            return phonebooksIncludingNumbers;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {FirstName}, Family: {LastName}," +
                    $" Father's name: {FatherName},\n Email address: {EmailAddress}," +
                    $" Website address: {WebsiteAddress}" +
                    $"Gender: {IsFemale}";
        }

    }
}
