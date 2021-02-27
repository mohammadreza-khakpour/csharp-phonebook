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

        public static PhoneBook MakePhonebookInstance()
        {
            return new PhoneBook();
        }

        public static Person MakePersonInstance()
        {
            return new Person();
        }

        public static Person MakePersonInstanceWithFullDetails()
        {
                var personInstance = MakePersonInstance();

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

    }
}
