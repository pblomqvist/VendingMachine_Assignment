using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine_Assignment.Models.Products
{
    
        public class Phone : Product
        {
            public Phone(string name, int price, string desc) : base(name, price, desc)
            {
                this.Name = name;
                this.Price = price;
                this.Description = desc;
            }

            public override string UserManual()
            {
                return "Exchange ticket to receive phone";
            }

            public new string Info()
            {
                return base.Info();
            }


        }

}
