using System;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_Console
{
    class Number
    {
        public int Id { get; set; }
        public string NumberPhoneNumber { get; set; }

        public int PhonebookId { get; set; }
        [ForeignKey("PhonebookId")]
        public PhoneBook NumberPhonebook { get; set; }

        public int AddNumber()
        {
            var db = ObjectProvider.MakeDbInstance();
            Number aNumber = ObjectProvider.MakeNumberInstance();
            Console.Write("Enter phone number: ");
            aNumber.NumberPhoneNumber = Console.ReadLine();
            Console.Write("Enter the id of belonging phonebook: ");
            aNumber.PhonebookId = int.Parse(Console.ReadLine());
            db.Add(aNumber);
            db.SaveChanges();
            return aNumber.Id;
        }

        public int DeleteNumber()
        {
            var db = ObjectProvider.MakeDbInstance();
            Console.Write("Enter number's id: ");
            int id = int.Parse(Console.ReadLine());
            db.Remove(db.Numbers.FirstOrDefault(x => x.Id == id));
            db.SaveChanges();
            return id;
        }

        public Number FindNumber()
        {
            Console.Write("Enter number's id: ");
            int id = int.Parse(Console.ReadLine());
            var db = ObjectProvider.MakeDbInstance();
            return db.Numbers.FirstOrDefault(x => x.Id == id);
        }

        public int UpdateNumber()
        {
            Number foundNumber = FindNumber();
            Console.Write("Enter new phone number: ");
            foundNumber.NumberPhoneNumber = Console.ReadLine();
            Console.Write("Enter the id of belonging phonebook: ");
            foundNumber.PhonebookId = int.Parse(Console.ReadLine());
            var db = ObjectProvider.MakeDbInstance();
            db.Update(foundNumber);
            db.SaveChanges();
            return foundNumber.Id;
        }
    }
}
