using System;
using System.Threading.Tasks;

namespace P01_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\tHello World!");


            #region MyRegion
            //string newCommand = "";
            //do
            //{
            //    // Menu:
            //    Console.ForegroundColor = ConsoleColor.Green;
            //    Console.WriteLine("\nEnter one of these commands (consider capital letters):\nPerson List\nPerson New" +
            //                        "\nPerson Edit (record id)\nPerson Delete (record id)\nPerson View (record id)" +
            //                        "\nPhoneBook Add (record id)\nPhoneBook Add (record id) (count)\nPhoneBook Delete (record id)" +
            //                        "\nPhoneBook Delete (record id) (All)\nPhoneBook List\nexit");
            //    Console.ResetColor();
            //    // read user's command
            //    newCommand = Console.ReadLine();
            //    // analyze user's command
            //    switch (newCommand)
            //    {
            //        case "Person List":
            //            Person.printAllPersons();
            //            break;
            //        case "Person New":
            //            Person.addNewPerson();
            //            Person.checkArePersonNamesUnique();
            //            break;
            //        case "Showcase List":
            //            Person.printAllShowcased();
            //            break;
            //        case "PhoneBook List":
            //            UserPhoneBook.showAllPhoneBooks();
            //            break;
            //        case "exit":
            //            ForTest writerToFile = new ForTest();
            //            writerToFile.rewriteTheTextFile(Person.staticListOfPersons);
            //            break;
            //        default:
            //            if (newCommand.Contains("Edit") && newCommand.Contains("Person"))
            //            {
            //                string theId = newCommand.Substring(12);
            //                Person.findAndEdit(theId);
            //            }
            //            else if (newCommand.Contains("Delete") && newCommand.Contains("Person"))
            //            {
            //                string theId = newCommand.Substring(14);
            //                Person.findAndDelete(theId);
            //            }
            //            else if (newCommand.Contains("View") && newCommand.Contains("Person"))
            //            {
            //                string theId = newCommand.Substring(12);
            //                Person.printThePerson(theId);
            //            }
            //            else if (newCommand.Contains("Add") && newCommand.Contains("Showcase"))
            //            {
            //                string theId = newCommand.Substring(12);
            //                Person.findAndSetTrueForShowcase(theId);
            //            }
            //            else if (newCommand.Contains("Delete") && newCommand.Contains("Showcase"))
            //            {
            //                string theId = newCommand.Substring(15);
            //                Person.findAndSetFalseForShowcase(theId);
            //            }
            //            else if (newCommand.Contains("Add") && newCommand.Contains("PhoneBook"))
            //            {
            //                string[] partsOfNewCommand = newCommand.Split(" ");
            //                Console.WriteLine("Enter PhoneBook id:\nEnter new if you want to have a new PhoneBook.");
            //                string entry = Console.ReadLine();
            //                int PhoneBookId = 0;
            //                if (entry == "new")
            //                {
            //                    PhoneBookId = 123;
            //                }

            //                if (entry != "new")
            //                {
            //                    PhoneBookId = int.Parse(entry);
            //                }

            //                if (partsOfNewCommand.Length == 3)
            //                {
            //                    string theId = newCommand.Substring(10);
            //                    UserBasket.addPersonToBasket(theId, basketId);
            //                }
            //                if (partsOfNewCommand.Length == 4)
            //                {
            //                    string requiredCount = partsOfNewCommand[3];
            //                    string theId = partsOfNewCommand[2];
            //                    UserBasket.addPersonToBasket(theId, requiredCount, basketId);
            //                }
            //            }
            //            else if (newCommand.Contains("Delete") && newCommand.Contains("PhoneBook"))
            //            {
            //                string[] partsOfNewCommand = newCommand.Split(" ");
            //                if (partsOfNewCommand.Length == 3)
            //                {
            //                    string theId = partsOfNewCommand[2];
            //                    Console.WriteLine("From which basket?\nEnter basket id:");
            //                    string basketid = Console.ReadLine();
            //                    UserBasket.findBasketAndDeleteOnePerson(theId, basketid);
            //                }
            //                else if (partsOfNewCommand.Length == 4)
            //                {
            //                    string aWord = partsOfNewCommand[3];
            //                    string theId = partsOfNewCommand[2];
            //                    if (aWord == "All")
            //                    {
            //                        Console.WriteLine("From which basket?\nEnter basket id:");
            //                        string basketid = Console.ReadLine();
            //                        UserBasket.findBasketAndDeleteAllPerson(theId, basketid);
            //                    }
            //                }
            //            }
            //            break;
            //    }
            //} while (newCommand != "exit"); 
            #endregion


            Console.WriteLine("\n\t\tGoodBye World!");
            Console.ReadLine();
        }
    }
}
