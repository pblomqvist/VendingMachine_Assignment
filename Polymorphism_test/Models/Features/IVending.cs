using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine_Assignment.Models.Products;
using VendingMachine_Assignment.Models.Features;
using System.Linq;

namespace VendingMachine_Assignment.Models.Features
{
    public interface IVending
    {
        List<Product> ShowAll(List<Product> AllProducts);
        int Purchase(int balance, int price, int userpurchase);
        int Examine(int userExamine);
        int InsertMoney(int fill, int balance);
        int EndTransaction(int balance);
        List<Product> Use(List<Product> customerItems, int selected);
    
    }

    public class VendingOptions : IVending
    {
        //Show all products
        List<Product> IVending.ShowAll(List<Product> AllProducts)
        {
            ItemFactory AllItems = new ItemFactory(AllProducts);
            AllProducts = AllItems.AllProds();

            Console.WriteLine("\nPRODUCTS\n---\n\n");
            
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
                else if (prod is Phone)
                {
                    Console.WriteLine((prod as Phone).Info());
                }
            }

            Console.WriteLine("\n\n---\n");

            Product.ResetCounter();

            return AllProducts;

        }

        //Examine product
        int IVending.Examine(int userExamine)
        {
            List<Product> AllProducts = new List<Product>();
            ItemFactory AllItems = new ItemFactory(AllProducts);
            AllProducts = AllItems.AllProds();
            Product.ResetCounter();

            foreach (Product prod in AllProducts)
            {
                if (prod.ID.Equals(userExamine))
                {
                    Console.WriteLine("\n---");
                    if (prod is Food)
                    {
                        
                        Console.WriteLine("\n" + (prod as Food).Examine() + "\n");
                    }
                    else if (prod is Drink)
                    {
                        Console.WriteLine("\n" + (prod as Drink).Examine() + "\n");
                    }
                    else if (prod is Phone)
                    {
                        Console.WriteLine("\n" + (prod as Phone).Examine() + "\n");
                    }
                    Console.WriteLine("---\n");

                    userExamine = prod.ID;

                }

            }

            return userExamine;
        }

        //Buy a product
        int IVending.Purchase(int balance, int price, int userpurchase)
        {
            List<Product> AllProducts = new List<Product>();
            ItemFactory AllItems = new ItemFactory(AllProducts);
            AllProducts = AllItems.AllProds();

            Product.ResetCounter();

            foreach (Product prod in AllProducts)
            {

                if (prod.ID.Equals(userpurchase))
                {
                    if (balance > prod.Price || balance == prod.Price)
                    {
                        Console.WriteLine("\n---");
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
                        Console.WriteLine("\n---\n");

                        price = prod.Price;
                        balance -= price;
                    }

                }

            }


            return balance;
        }

        //Add money to the pool
        int IVending.InsertMoney(int fill, int balance)
        {
            Change denoms = new Change();
            IList<int> values = Array.AsReadOnly(denoms.denominations);

            if (values.Contains(fill))
            {
                balance = balance += fill;
                Console.WriteLine($"\n---\n\nAdded {fill} kr to your account! \n\nCurrent balance: {balance} kr\n\n---\n");
            }
            else
            {
                Console.WriteLine("\n---\n\nNot a valid amount. Try again.\n\n---\n");
            }

            return balance;

        }

        // Returns money left in appropriate amount of change
        int IVending.EndTransaction(int balance)
        {
            string msg = "";
            var change = new Change();

            msg = change.GiveChange(balance, msg);

            Console.WriteLine(msg);

            return balance;
        }

        List<Product> IVending.Use(List<Product> customerItems, int selected)
        {

            foreach (Product tobeRemoved in customerItems.Reverse<Product>())
            {
                if (tobeRemoved.ID.Equals(selected))
                {
                    if (tobeRemoved is Food)
                    {
                        customerItems.Remove(tobeRemoved);
                        Console.WriteLine($"\n---\n\nAte {tobeRemoved.Name}!\n\n---\n");
                    }
                    else if (tobeRemoved is Drink)
                    {
                        customerItems.Remove(tobeRemoved);
                        Console.WriteLine($"\n---\n\nDrank the {tobeRemoved.Name}!\n\n---\n");
                    }
                    else if (tobeRemoved is Phone)
                    {
                        customerItems.Remove(tobeRemoved);
                        Console.WriteLine($"\n---\n\nReceived the {tobeRemoved.Name}!\n\n---\n");
                    }

                }
            }

            return customerItems;
        }

    }
}
