using System;
using MongoDB.Bson;

namespace uShopConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person { Name = "Bill", Surname = "Gates", Age = 48 };
            p.Company = new Company { Name = "Microsoft" };

            Console.WriteLine(p.ToJson());
            Console.ReadLine();
        }
    }
}