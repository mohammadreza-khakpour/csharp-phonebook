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

        public static Person MakePersonInstance()
        {
            return new Person();
        }
    }
}
