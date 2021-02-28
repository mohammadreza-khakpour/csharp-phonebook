using P01_Console.Model.classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Console
{
    static class ObjectProvider
    {

        public static AppDbContext MakeDbInstance()
        {
            return new AppDbContext();
        }

        public static Number MakeNumberInstance()
        {
            return new Number();
        }
        public static Email MakeEmailInstance()
        {
            return new Email();
        }

        public static PhoneBook MakePhonebookInstance()
        {
            return new PhoneBook();
        }

        public static Person MakePersonInstance()
        {
            return new Person(MakeDbInstance());
        }

        public static Person MakePersonInstanceWithFullDetails()
        {
                var personInstance = MakePersonInstance();

                Console.Write("Enter new person's first name: ");
                personInstance.FirstName = Console.ReadLine();
                Console.Write("Enter new person's last name: ");
                personInstance.LastName = Console.ReadLine();
                Console.Write("Enter new person's father name: ");
                personInstance.FatherName = Console.ReadLine();
                Console.Write("Enter new person's email address: ");
                personInstance.EmailAddress = Console.ReadLine();
                Console.Write("Enter new person's website address: ");
                personInstance.WebsiteAddress = Console.ReadLine();
                Console.Write("Enter true if it is female and false if it is male: ");
                personInstance.IsFemale = bool.Parse(Console.ReadLine());

                return personInstance;
        }

    }
}
