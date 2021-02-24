using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

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
        public ICollection<Number> PersonNumbers { get; set; }

        public int PersonPhonebookId { get; set; }
        [ForeignKey("PersonPhonebookId")]
        public PhoneBook PersonPhonebook { get; set; }



        public int AddPerson()
        {
            var db = ObjectProvider.MakeDbInstance();
            Person aPerson = ObjectProvider.MakePersonInstance();
            Console.Write("enter person's first name");
            aPerson.PersonFirstName = Console.ReadLine();
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

        public static Person GetValuesOfPersonProperties()
        {
            var personInstance = ObjectProvider.MakePersonInstance();

            Console.Write("Enter new person's first name: ");
            personInstance.PersonFirstName = Console.ReadLine();
            Console.Write("Enter new person's last name: ");
            personInstance.PersonLastName = Console.ReadLine();
            Console.Write("Enter new person's father name: ");
            personInstance.PersonFatherName = Console.ReadLine();
            Console.Write("Enter new person's email address: ");
            personInstance.PersonEmailAddress = Console.ReadLine();
            Console.Write("Enter new person's website address: ");
            personInstance.PersonWebsiteAddress = Console.ReadLine();
            Console.Write("Enter true if it is female and false if it is male: ");
            personInstance.PersonIsFemale = bool.Parse(Console.ReadLine());

            return personInstance;
        }

        public int UpdatePerson()
        {
            Person foundedPerson = FindPerson();
            Person resultedPersonToGetReplaced = GetValuesOfPersonProperties();
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

        public void PrintPersonWithBelongingPhonebook(int personId)
        {
            AppDbContext db = new AppDbContext();
            Person per01 = db.Persons.Include(x => x.PersonPhonebook).FirstOrDefault(p => p.Id == personId);
            Console.WriteLine($"person is : {per01} and it's phone book id is: {per01.PersonPhonebook.Id}");
        }

        public override string ToString()
        {
            return $"Id: {Id}, Phonebook id: {PersonPhonebookId}, Name: {PersonFirstName}, Family: {PersonLastName}," +
                $" Father's name: {PersonFatherName},\n Email address: {PersonEmailAddress}, Website address: {PersonWebsiteAddress}" +
                $"Gender: {PersonIsFemale}";
        }

    }
}
