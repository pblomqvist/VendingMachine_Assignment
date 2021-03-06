using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine_Assignment.Models.Products
{
    public class Food : Product
    {
        public Food(string name, int price, string desc) : base(name, price, desc)
        {
            this.Name = name;
            this.Price = price;
            this.Description = desc;
        }

        public override string UserManual()
        {
            return "Eat the food";
        }

        public new string Info()
        {
            return base.Info();
        }


    }

}
