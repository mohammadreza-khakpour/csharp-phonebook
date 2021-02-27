using System.Collections.Generic;

namespace P01_Console
{
    interface IBookType
    {
        int Id { get; set; }
        string Title { get; set; }

        int Add();
        int Delete();
    }
}