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
            Change denoms = new Change();
            Customer customer = new Customer();

            int fill = 0;
            int inputSelect = 0;
            int balance = customer.Money;

            bool running = true;
            bool keepRunning = false;

            IList<int> values = Array.AsReadOnly(denoms.denominations);
            List<Product> AllProducts = new List<Product>();
            List<Customer> AvailableInventory = new List<Customer>
            {
                customer
            };
            List<Product> customerItems = customer.Inventory;
            
            IVending vendAction = new VendingOptions();

            WriteLine("\n\n\nWELCOME TO VENDING MACHINE!\n");
            while (running)
            {
                WriteLine("\n---\nWhat would you like to do?\n" +
                    "\n0: Exit" +
                    "\n1: Show all products" +
                    "\n2: Insert money " +
                    "\n3: Purchase" +
                    "\n4: Use products" );
                
                Write($"\nBALANCE: {balance} kr \nINVENTORY: ");
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
                        WriteLine("Empty");
                    }

                }
                WriteLine("\n---\n\n");

               int action = GetIntFromUser();

                switch (action)
                {
                    case 0:
                        running = false;
                        break;

                    case 1:

                        AllProducts = vendAction.ShowAll(AllProducts);

                        do
                        {
                            WriteLine("\nType ID to examine product, 0 to quit\n---\n");
                            inputSelect = GetIntFromUser();
                            
                            if (inputSelect.Equals(0))
                            {
                                keepRunning = false;
                                break;
                            } else
                            {
                                vendAction.Examine(inputSelect);
                                keepRunning = true;
                            }

                            
                        }
                        while (keepRunning);

                        break;

                    case 2:

                        do
                        {
                            Console.WriteLine("\n---\n\nWhat would you like to insert? Choose any amount below.");
                            foreach (int val in values)
                            {
                                Console.Write(val.ToString() + " kr | ");
                            }
                            Console.WriteLine("\n\nEnter '0' to stop refill.\n\n---\n");

                            fill = GetIntFromUser();

                            if (fill.Equals(0))
                            {
                                WriteLine($"\n---\n\nThank you!\n\nBalance: {balance} kr\n\n---");
                                keepRunning = false;
                                break;
                            }
                            else
                            {
                                balance = vendAction.InsertMoney(fill, balance);
                                keepRunning = true;
                            }
                        }
                        while (keepRunning);
                        
                        break;

                    case 3:

                        do
                        {
                            Console.WriteLine("\nWhat would you like to purchase? Choose any product below.");
                            Console.WriteLine("\nType product ID to purchase, 0 to quit");

                            AllProducts = vendAction.ShowAll(AllProducts);

                            WriteLine($"\nAvailable funds: {balance} kr");

                            inputSelect = GetIntFromUser();
                            int price = 0;

                            if (inputSelect.Equals(0))
                            {
                                WriteLine("\nThank you!\n");
                                vendAction.EndTransaction(balance);
                                keepRunning = false;
                                break;

                            }
                            else
                            {

                                foreach (Product prod in AllProducts)
                                {
                                    if (balance > prod.Price || balance == prod.Price)
                                    {
                                        if (prod.ID.Equals(inputSelect))
                                        {
                                            if (prod is Food)
                                            {
                                                customer.AddInventory(prod);
                                            }
                                            else if (prod is Drink)
                                            {
                                                customer.AddInventory(prod);
                                            }
                                            else if (prod is Phone)
                                            {
                                                customer.AddInventory(prod);
                                            }

                                        }
                                    }
                                    else
                                    {
                                        
                                        Console.WriteLine("\n---\nYou don't have enough money for that product!\n");
                                        keepRunning = false;
                                        break;
                                    }

                                }

                                balance = vendAction.Purchase(balance, price, inputSelect);
                                keepRunning = true;
                            }


                        }
                        while (keepRunning);

                        break;

                    case 4:

                        do
                        {
                            
                            if (customerItems.Any())
                            {
                                Console.WriteLine("\nType item ID to select and use product, 0 to quit");
                                WriteLine("\nYour items\n---");
                                foreach (Product item in customerItems)
                                {

                                    Console.Write($"{item.Info()} -- How to use: {item.UserManual()}\n");

                                }
                                WriteLine("---\n");

                                inputSelect = GetIntFromUser();

                                if (inputSelect.Equals(0))
                                {
                                    keepRunning = false;
                                    break;

                                } else
                                {
                                    customerItems = vendAction.Use(customerItems, inputSelect);
                                    keepRunning = true;
                                }
                                
                            }
                            else
                            {
                                WriteLine("\n---\nYou don't have any items!\n\n");
                                keepRunning = false;
                            }


                        } while (keepRunning);

                        
                        break;

                    default:
                        WriteLine("\nOops! Something went wrong.\n");
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
                        WriteLine("\n\nEnter number:");
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

