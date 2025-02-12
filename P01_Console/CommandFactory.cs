﻿using System;
using System.Linq;
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
                        "\nShow All" +
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
                case "Show All":
                    ShowAllInfos();
                    break;
                case "Person New":
                    person.Add();
                    break;
                case "Person Edit":
                    person.FindPerson().UpdatePersonTotally();
                    break;
                case "Person Delete":
                    person.Delete();
                    break;
                case "Person View Info":
                    person.PrintPersonNumbers();
                    break;
                case "PhoneBook New":
                    phonebook.Add();
                    break;
                case "PhoneBook Edit":
                    phonebook.UpdatePhonebook();
                    break;
                case "PhoneBook Delete":
                    phonebook.Delete();
                    break;
                case "Number New":
                    number.Add();
                    break;
                case "Number Edit":
                    number.UpdateNumber();
                    break;
                case "Number Delete":
                    number.Delete();
                    break;
                case "exit":
                    Console.WriteLine("\n\t\tSee you later.");
                    break;
                default:
                    break;
            }
        }

        public static void ShowAllInfos()
        {
            AppDbContext db = ObjectProvider.MakeDbInstance();
            db.Persons.ToList().ForEach(eachPerson =>
            {
                Console.WriteLine($"\tPerson id is : {eachPerson.Id}");
                var personPhonebooks = eachPerson.FindPhonebooksWithBelongingNumbers(eachPerson.Id);
                personPhonebooks.ToList().ForEach(phonebook =>
                {
                    Console.WriteLine($"\t\tphonebook id is : {phonebook.Id}");
                    phonebook.PhonebookNumbers.ToList().ForEach(number =>
                    {
                        Console.WriteLine($"\t\t\t{number.ContactTitle}  {number.ContactValue}");
                    });
                });
            });
        }

    }
}

