using System;

namespace Company.Data.Entities
{
    public class Company
    {
        public string _id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
    }
}