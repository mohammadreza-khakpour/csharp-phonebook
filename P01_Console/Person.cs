using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_Console
{
    class Person
    {
        
        public int Id { get; set; }
        public string PersonFirstName { get; set; }
        public string PersonLastName { get; set; }
        public string PersonFatherName { get; set; }
        public string PersonEmailAddress { get; set; }
        public string PersonWebsiteAddress { get; set; }
        public bool PersonIsFemale { get; set; }
        public ICollection<PhoneBook> PersonPhonebooks { get; set; }




        public int AddPerson()
        {
            var db = ObjectProvider.MakeDbInstance();
            Person aPerson = ObjectProvider.MakePersonInstanceWithFullDetails();
            db.Add(aPerson);
            db.SaveChanges();
            return aPerson.Id;
        }

        public int DeletePerson()
        {
            var db = ObjectProvider.MakeDbInstance();
            Console.Write("Enter Person's id: ");
            int id = int.Parse(Console.ReadLine());
            db.Remove(db.Persons.FirstOrDefault(x => x.Id == id));
            db.SaveChanges();
            return id;
        }

        public Person FindPerson()
        {
            Console.Write("Enter person's id: ");
            int id = int.Parse(Console.ReadLine());
            var db = ObjectProvider.MakeDbInstance();
            return db.Persons.FirstOrDefault(x => x.Id == id);
        }

        public int UpdatePerson()
        {
            Person foundedPerson = FindPerson();
            Person resultedPersonToGetReplaced = ObjectProvider.MakePersonInstanceWithFullDetails();
            foundedPerson.PersonFirstName = resultedPersonToGetReplaced.PersonFirstName;
            foundedPerson.PersonLastName = resultedPersonToGetReplaced.PersonLastName;
            foundedPerson.PersonFatherName = resultedPersonToGetReplaced.PersonFatherName;
            foundedPerson.PersonEmailAddress = resultedPersonToGetReplaced.PersonEmailAddress;
            foundedPerson.PersonWebsiteAddress = resultedPersonToGetReplaced.PersonWebsiteAddress;
            var db = ObjectProvider.MakeDbInstance();
            db.Update(foundedPerson);
            db.SaveChanges();
            return foundedPerson.Id;
        }

        //public void PrintTheListOfPersons()
        //{
        //    List<Person> people =  GetAllPersons();
        //    people.ForEach(p => Console.WriteLine(p));
        //}

        //public List<Person> GetAllPersons()
        //{
        //    AppDbContext db = new AppDbContext();
        //    return db.Persons.ToList();
        //}

        public void FindAndPrintPersonNumbers()
        {
            Console.Write("Enter person's id: ");
            int personId = int.Parse(Console.ReadLine());
            AppDbContext db = new AppDbContext();
            var fromAllPersons = db.Persons.Include(x => x.PersonPhonebooks);
            var fromAllPhonebooks = db.PhoneBooks.Include(x => x.PhonebookNumbers);
            Person person = fromAllPersons.FirstOrDefault(x=>x.Id==personId);
            person.PersonPhonebooks = fromAllPhonebooks.Where(x=>x.PhonebookPersonId==person.Id).ToList();
            person.PersonPhonebooks.ToList().ForEach(x=> {
                foreach (Number number in x.PhonebookNumbers)
                {
                    Console.WriteLine(number);
                }
                Console.WriteLine("--------------------");
            });
        }

        //public void PrintPersonWithPhonebookNumbers(int personId)
        //{
        //    AppDbContext db = new AppDbContext();
        //    Person per01 = db.Persons.Include(x => x.PersonPhonebooks).FirstOrDefault(p => p.Id == personId);
        //    Console.WriteLine($"person is : {per01} and it's phone books are: {per01.PersonPhonebooks}");
        //}

        public override string ToString()
        {
            return $"Id: {Id}, Name: {PersonFirstName}, Family: {PersonLastName}," +
                    $" Father's name: {PersonFatherName},\n Email address: {PersonEmailAddress}," +
                    $" Website address: {PersonWebsiteAddress}" +
                    $"Gender: {PersonIsFemale}";
        }

    }
}
