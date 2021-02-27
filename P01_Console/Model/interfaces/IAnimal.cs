using System.Collections.Generic;

namespace P01_Console
{
    interface IAnimal
    {
        int Id { get; set; }
        bool IsFemale { get; set; }

        int Add();
        int Delete();
    }
}