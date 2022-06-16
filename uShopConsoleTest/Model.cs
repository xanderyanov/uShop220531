using MongoDB.Bson;
using System.Collections.Generic;
 
namespace uShopConsoleTest
{
    class Person
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public Company Company { get; set; }
        public List<string> Languages { get; set; }
    }
    class Company
    {
        public string Name { get; set; }
    }
}
