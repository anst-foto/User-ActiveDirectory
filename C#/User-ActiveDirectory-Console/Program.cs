using System;
using System.Collections.Generic;
using System.Text;
using User_ActiveDirectory_lib;

namespace User_ActiveDirectory_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            UserAD userAD = new UserAD();

            name = Console.ReadLine();

            userAD.Find(name);

            Console.WriteLine(userAD.SearchResultCollection.ToString());
            Console.ReadKey();
        }
    }
}
