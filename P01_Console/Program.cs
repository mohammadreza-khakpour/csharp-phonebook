using System;
using System.Threading.Tasks;

namespace P01_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\tHello World!");

            do
            {
                CommandFactory.ShowMenu();
                CommandFactory.ReceiveUserCommand();
                CommandFactory.AnalyzeUserCommand();
            } while (CommandFactory.UserCommand != "exit");

            Console.WriteLine("\n\t\tGoodBye World!");
            Console.ReadLine();
        }
    }
}
