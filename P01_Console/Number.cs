using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_Console
{
    class Number
    {
        public int Id { get; set; }
        public string NumberCity { get; set; }

        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public Person NumberPerson { get; set; }

        public int AddNumber()
        {
            var db = ObjectProvider.MakeDbInstance();
            Number aNumber = ObjectProvider.MakeNumberInstance();
            Console.Write("Enter number's city: ");
            aNumber.NumberCity = Console.ReadLine();
            db.Add(aNumber);
            db.SaveChanges();
            return aNumber.Id;
        }

        public bool DeleteNumber()
        {
            var db = ObjectProvider.MakeDbInstance();
            Console.Write("Enter number's id: ");
            int id = int.Parse(Console.ReadLine());
            db.Remove(db.Numbers.FirstOrDefault(x => x.Id == id));
            db.SaveChanges();
            return true;
        }
    }
}
