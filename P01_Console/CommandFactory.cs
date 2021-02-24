using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Console
{
    static class CommandFactory
    {
        public static string UserCommand { get; private set; }
        public static void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nEnter one of these commands (consider capital letters):" +
                        "\nPerson New\nPerson Edit\nPerson Delete\nPerson View Info" +
                        "\nPhoneBook New\nPhoneBook Edit\nPhoneBook Delete" +
                        "\nNumber New\nNumber Edit\nNumber Delete" +
                        "\nexit");
            Console.ResetColor();
        }

        public static string ReceiveUserCommand()
        {
            UserCommand = Console.ReadLine();
            return UserCommand;
        }

        public static void AnalyzeUserCommand()
        {
            Person person = ObjectProvider.MakePersonInstance();
            PhoneBook phonebook = ObjectProvider.MakePhonebookInstance();
            Number number = ObjectProvider.MakeNumberInstance();
            switch (UserCommand)
            {
                case "Person New":
                    person.AddPerson();
                    break;
                case "Person Edit":
                    person.FindPerson().UpdatePerson();
                    break;
                case "Person Delete":
                    person.DeletePerson();
                    break;
                case "Person View Info":
                    person.FindAndPrintPersonNumbers();
                    break;
                case "PhoneBook New":
                    phonebook.AddPhonebook();
                    break;
                case "PhoneBook Edit":
                    phonebook.UpdatePhonebook();
                    break;
                case "PhoneBook Delete":
                    phonebook.DeletePhonebook();
                    break;
                case "Number New":
                    number.AddNumber();
                    break;
                case "Number Edit":
                    number.UpdateNumber();
                    break;
                case "Number Delete":
                    number.DeleteNumber();
                    break;
                case "exit":
                    Console.WriteLine("\n\t\tSee you later.");
                    break;
                default:
                    break;
            }
        }

    }
}

