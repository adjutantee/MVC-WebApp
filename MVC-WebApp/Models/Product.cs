using System;

namespace OnlineWebApp_MVC.Models
{
    public class Product
    {
        private int instanceCounter = 1;
        public int Id { get; }
        public string Name { get; }
        public string Description { get; }
        public string Brand { get; }
        public string Model { get; }
        public int Size { get; }
        public Decimal Cost { get; }

        public Product(string name, string description, string brand, string model, int size, decimal cost)
        {
            Id = instanceCounter;
            Name = name;
            Description = description;
            Brand = brand;
            Model = model;
            Size = size;
            Cost = cost;

            instanceCounter += 1;
        }
    }
}
 