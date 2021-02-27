using Microsoft.EntityFrameworkCore;
using P01_Console.Model.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_Console
{
    class PhoneBook : IBookType
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Number> PhonebookNumbers { get; set; }
        public ICollection<Email> PhonebookEmails { get; set; }

        public int PhonebookPersonId { get; set; }
        [ForeignKey("PhonebookPersonId")]
        public Person PhonebookPerson { get; set; }


        public int Add()
        {
            var db = ObjectProvider.MakeDbInstance();
            PhoneBook aPhonebook = ObjectProvider.MakePhonebookInstance();
            Console.Write("Enter phonebook's title: ");
            aPhonebook.Title = Console.ReadLine();
            Console.Write("Enter the id of belonging person: ");
            aPhonebook.PhonebookPersonId = int.Parse(Console.ReadLine());
            db.Add(aPhonebook);
            db.SaveChanges();
            return aPhonebook.Id;
        }

        public int Delete()
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
            foundPhonebook.Title = Console.ReadLine();
            var db = ObjectProvider.MakeDbInstance();
            db.Update(foundPhonebook);
            db.SaveChanges();
            return foundPhonebook.Id;
        }


    }
}
