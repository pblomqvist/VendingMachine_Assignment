using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine_Assignment.Models.Products
{
    public class Drink : Product
    {
        public Drink(string name, int price, string desc) : base(name, price, desc)
        {
            this.Name = name;
            this.Price = price;
            this.Description = desc;
        }

        public new string Info()
        {
            return base.Info();
        }

        public override string UserManual()
        {
            return "Drink me";
        }

    }
}
