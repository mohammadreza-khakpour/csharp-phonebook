using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace P01_Console.Model.classes
{
    class Email : IContactType
    {
        public int Id { get; set; }
        public string ContactTitle { get; set; }
        public string ContactValue { get; set; }

        public int PhonebookId { get; set; }
        [ForeignKey("PhonebookId")]
        public PhoneBook EmailPhonebook { get; set; }

        public int Add()
        {
            var db = ObjectProvider.MakeDbInstance();
            Email anEmail = ObjectProvider.MakeEmailInstance();
            Console.Write("Enter email address: ");
            anEmail.ContactTitle = Console.ReadLine();
            Console.Write("Enter the id of belonging phonebook: ");
            anEmail.PhonebookId = int.Parse(Console.ReadLine());
            db.Add(anEmail);
            db.SaveChanges();
            return anEmail.Id;
        }

        public int Delete()
        {
            var db = ObjectProvider.MakeDbInstance();
            Console.Write("Enter email's id: ");
            int id = int.Parse(Console.ReadLine());
            db.Remove(db.Emails.FirstOrDefault(x => x.Id == id));
            db.SaveChanges();
            return id;
        }
    }
}
