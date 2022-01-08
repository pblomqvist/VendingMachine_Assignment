using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine_Assignment.Models.Products;
using VendingMachine_Assignment.Models.Features;
using System.Linq;

namespace VendingMachine_Assignment.Models.Features
{
    interface IVending
    {
        List<Product> ShowProducts(List<Product> AllProducts);
        int Purchase(int moneypool, int price, int userpurchase);
        int InsertMoney(int fill, int moneypool);
        int EndTransaction(int moneypool);
    }

    class VendingOptions : IVending
    {
        //Show all products
        List<Product> IVending.ShowProducts(List<Product> AllProducts)
        {
            ItemFactory AllItems = new ItemFactory(AllProducts);
            AllProducts = AllItems.allProds();

            foreach (Product prod in AllProducts)
            {
                if (prod is Food)
                {
                    Console.WriteLine((prod as Food).Info());
                }
                else if (prod is Drink)
                {
                    Console.WriteLine((prod as Drink).Info());
                }
            }

            Product.ResetCounter();

            return AllProducts;

        }

        //Buy a product
        int IVending.Purchase(int moneypool, int price, int userpurchase)
        {
            List<Product> AllProducts = new List<Product>();
            ItemFactory AllItems = new ItemFactory(AllProducts);
            AllProducts = AllItems.allProds();

            Product.ResetCounter();

            foreach (Product prod in AllProducts)
            {

                if (prod.ID.Equals(userpurchase))
                {
                    if (moneypool > prod.Price || moneypool == prod.Price)
                    {
                        if (prod is Food)
                        {
                            Console.WriteLine($"\nPurchased {prod.Name} for {prod.Price} kr!!");
                            Console.WriteLine($"How to use: {prod.UserManual()}");
                        }
                        else if (prod is Drink)
                        {
                            Console.WriteLine($"\nPurchased {prod.Name} for {prod.Price} kr!!");
                            Console.WriteLine($"How to use: {prod.UserManual()}");
                        }

                        price = prod.Price;
                        moneypool -= price;
                    }
                    else
                    {
                        Console.WriteLine("\nYou don't have enough money for that product!\n");
                        break;
                    }

                }

            }


            return moneypool;
        }


        //Add money to the pool
        int IVending.InsertMoney(int fill, int moneypool)
        {
            int[] denominations = { 1, 2, 5, 10, 20, 50, 100, 500, 1000 };
            IList<int> values = Array.AsReadOnly(denominations);

            if (values.Contains(fill))
            {
                moneypool = moneypool += fill;
                Console.WriteLine($"\n\nAdded {fill} kr!! \nAvailable funds: {moneypool} kr");
            }
            else
            {
                Console.WriteLine("\nNot a valid amount. Try again.\n");
            }

            return moneypool;

        }

        // Returns money left in appropriate amount of change
        int IVending.EndTransaction(int moneypool)
        {
            string msg = "";
            var change = new Change();

            msg = change.GiveChange(moneypool, msg);

            Console.WriteLine(msg);

            return moneypool;
        }

    }
}
