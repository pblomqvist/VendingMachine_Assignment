using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine_Assignment
{
    public abstract class Product
    {
        static int idCounter = 0;
        private readonly int id;
        public int ID { get { return id; } }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }

        public Product(string name, int price, string desc)
        {
            this.id = ++idCounter;
            this.Name = name;
            this.Price = price;
            this.Description = desc;
        }

        public string Info()
        {
            return $"   [{ID}] {Name}";
        }

        public string Examine()
        {
            return $"[{ID}] {Name} -- {Price} kr \nDescription: {Description}";
        }

        public virtual string UserManual()
        {
            return "Instructions how to use product";
        }

        public static void ResetCounter()
        {
            idCounter = 0;
        }

    }
}
