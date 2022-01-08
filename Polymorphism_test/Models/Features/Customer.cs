using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine_Assignment.Models.Features
{
    public class Customer
    {
        private int money = 0;
        public int Money { get => money; set { money = value; } }
        public List<Product> Inventory;


        public Customer()
        {
            this.Money = money;
            this.Inventory = new List<Product>();
        }


        public Product AddInventory(Product NewItem)
        {
            Inventory.Add(NewItem);

            return NewItem;
        }


    }
}
