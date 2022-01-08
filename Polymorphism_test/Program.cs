using System;
using System.Collections.Generic;
using static System.Console;
using VendingMachine_Assignment.Models.Features;
using VendingMachine_Assignment.Models.Products;
using System.Linq;

namespace VendingMachine_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            
            bool running = true;
            bool keepFill = false;

            int[] denominations = { 1, 2, 5, 10, 20, 50, 100, 500, 1000 };
            IList<int> values = Array.AsReadOnly(denominations);

            IVending show = new VendingOptions();

            List<Product> showProd = new List<Product>();
            List<Product> AllProducts = new List<Product>();

            Customer customer = new Customer();
            List<Customer> AvailableInventory = new List<Customer>();

            int moneypool = customer.Money;
            int fill = 0;

            AvailableInventory.Add(customer);
            List<Product> customerItems = customer.Inventory;



            WriteLine("Welcome to Vending Machine!");
            while (running)
            {
                WriteLine("\n\nWhat would you like to do?\n" +
                    "\n0: Exit" +
                    "\n1: Show all products" +
                    "\n2: Insert money " +
                    "\n3: Purchase" +
                    "\n4: Use products" );
                
                Write($"\nAvailable funds: {moneypool} kr \nYour inventory: ");
                foreach (Customer cust in AvailableInventory)
                {
                    if (AvailableInventory.Any())
                    {
                        foreach (Product item in customerItems)
                        {
                            Console.Write($"1x {item.Name}, ");
                        }
                    } else
                    {
                        WriteLine("N/A");
                    }

                }

                int action = GetIntFromUser();

                switch (action)
                {
                    case 0:
                        running = false;
                        break;

                    case 1:
                        WriteLine("\nProducts\n================\n");
                        AllProducts = show.ShowProducts(AllProducts);
                        WriteLine("\n================\n");

                        do
                        {
                            WriteLine("\nType ID to examine product, 0 to quit");
                            int userExamine = GetIntFromUser();
                            
                            foreach (Product prod in AllProducts)
                            {
                                if (prod.ID.Equals(userExamine))
                                {
                                    if (prod is Food)
                                    {
                                        Console.WriteLine("\n"+ (prod as Food).Examine()+ "\n");
                                    }
                                    else if (prod is Drink)
                                    {
                                        Console.WriteLine("\n"+ (prod as Drink).Examine()+ "\n");
                                    }
                                    keepFill = true;

                                }
                                else if (userExamine.Equals(0))
                                {
                                    keepFill = false;
                                    break;
                                }

                            }
                        }
                        while (keepFill);

                        break;

                    case 2:

                        do
                        {
                            Console.WriteLine("\nWhat would you like to insert? Choose any amount below.");
                            foreach (int val in values)
                            {
                                Console.Write(val.ToString() + " kr | ");
                            }
                            Console.WriteLine("\n\nEnter '0' to stop refill.\n\n");

                            fill = GetIntFromUser();

                            if (fill.Equals(0))
                            {
                                WriteLine($"\nThank you!\nAvailable funds: {moneypool} kr");
                                keepFill = false;
                                break;
                            }
                            else
                            {
                                moneypool = show.InsertMoney(fill, moneypool);
                                keepFill = true;
                            }
                        }
                        while (keepFill);
                        
                        break;

                    case 3:

                        do
                        {
                            Console.WriteLine("\nWhat would you like to purchase? Choose any product below.");
                            Console.WriteLine("\nType product ID to purchase, 0 to quit");

                            WriteLine("\nProducts\n================\n");
                            AllProducts = show.ShowProducts(AllProducts);
                            WriteLine("\n================\n");

                            WriteLine($"\nAvailable funds: {moneypool} kr");

                            int userpurchase = GetIntFromUser();
                            int price = 0;

                            if (userpurchase.Equals(0))
                            {
                                WriteLine("\nThank you!\n");
                                show.EndTransaction(moneypool);
                                keepFill = false;
                                break;

                            }
                            else
                            {

                                foreach (Product prod in AllProducts)
                                {

                                    if (prod.ID.Equals(userpurchase))
                                    {
                                        WriteLine("hello");
                                        if (prod is Food)
                                        {
                                            customer.AddInventory(prod);
                                        }
                                        else if (prod is Drink)
                                        {
                                            customer.AddInventory(prod);
                                        }


                                    }

                                }

                                moneypool = show.Purchase(moneypool, price, userpurchase);
                                keepFill = true;
                            }


                        }
                        while (keepFill);

                        break;

                    case 4:
                        
                        if (customerItems.Any())
                        {
                            Console.WriteLine("\nType item ID to select and use product, 0 to quit");
                            WriteLine("\nYour items\n================\n");
                            foreach (Product item in customerItems)
                            {
                                
                                Console.Write($"{item.Info()} -- How to use: {item.UserManual()}\n");

                            }
                            WriteLine("\n================\n");

                            int userSelect = GetIntFromUser();

                            foreach (Product tobeRemoved in customerItems.Reverse<Product>())
                            {
                                if (tobeRemoved.ID.Equals(userSelect))
                                {
                                    if (tobeRemoved is Food)
                                    {
                                        customerItems.Remove(tobeRemoved);
                                        Console.WriteLine($"Ate {tobeRemoved.Name}!!\n");
                                    }
                                    else if (tobeRemoved is Drink)
                                    {
                                        customerItems.Remove(tobeRemoved);
                                        Console.WriteLine($"Drank {tobeRemoved.Name}!!\n");
                                    }
                                    
                                }
                            }

                        } else
                        {
                            WriteLine("\nYou don't have any items!");
                        }

                        break;

                    case 5:
                        
                        break;

                    default:
                        WriteLine("Something went wrong");
                        break;
                }

            }


            static int GetIntFromUser()
            {
                int userInput = 0;
                bool success = false;

                do
                {
                    try
                    {
                        WriteLine("\nEnter number:");
                        success = int.TryParse(ReadLine(), out userInput);
                    }
                    catch (OverflowException)
                    {
                        WriteLine("Your value is too big");
                    }
                    catch (ArgumentNullException)
                    {
                        WriteLine("Could not parse, value was null");
                    }
                    catch (FormatException error)
                    {
                        WriteLine(error.Message);

                        WriteLine("Wrong format");
                    }

                } while (!success);

                return userInput;
            }

        }
    }
}

