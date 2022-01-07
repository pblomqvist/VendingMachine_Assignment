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

        public Customer(int money)
        {
            this.Money = money;
            this.Inventory = new List<Product>();
        }

        public void AddInventory(Product newItem)
        {
            Inventory.Add(newItem);
        }

        public virtual List<Product> InventoryList()
        {
            return Inventory;
        }


    }
}
