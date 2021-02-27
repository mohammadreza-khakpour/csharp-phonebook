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
            var db = ObjectProvider.MakeDbInstance();
            db.Update(foundPhonebook);
            db.SaveChanges();
            return foundPhonebook.Id;
        }


    }
}
