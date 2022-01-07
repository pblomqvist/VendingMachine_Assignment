using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine_Assignment.Models.Products;
using VendingMachine_Assignment.Models.Features;

namespace VendingMachine_Assignment.Models.Features
{
    interface IVending
    {
        List<Product> ShowProducts();
        void Purchase();
        int InsertMoney(int fill, int moneypool);
        int EndTransaction(int moneypool);
    }

    class VendingOptions : IVending
    {
        //Show all products
        List<Product> IVending.ShowProducts()
        {

            List<Product> prodList = new List<Product>();

            Food Chips = new Food("Chips", 50, "Tasty snack made of potato");
            Food Chocolate = new Food("Chocolate", 80, "Tasty snack made of cocoa");
            Food Carbonara = new Food("Carbonara", 100, "Tasty pasta dish that will keep you full all day");

            Drink CocaCola = new Drink("Coca Cola", 50, "Sugary drink");
            Drink Fanta = new Drink("Fanta", 20, "Sugary orange drink");
            Drink Water = new Drink("Water", 10, "Just some plain water");

            prodList.Add(Chips);
            prodList.Add(Chocolate);
            prodList.Add(Carbonara);
            prodList.Add(CocaCola);
            prodList.Add(Fanta);
            prodList.Add(Water);

            Product.ResetCounter();

            foreach (Product prod in prodList)
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

            return prodList;

        }

        //Buy a product
        void IVending.Purchase()
        {

        }

        //Add money to the pool
        int IVending.InsertMoney(int fill, int moneypool)
        {
            moneypool = moneypool += fill;

            return moneypool;

        }

        // Returns money left in appropriate amount of change
        int IVending.EndTransaction(int moneypool)
        {

            var change = new Change(moneypool);
            int i = 0;

            Console.WriteLine($"{change.thousandBills} x 1000 SEK\n" +
                              $"{change.fiveHundredBills} x 500 SEK\n" +
                              $"{change.hundredBills} x 100 SEK\n" +
                              $"{change.fiftyBills} x 50 SEK\n" +
                              $"{change.twentyBills} x 20 SEK\n" +
                              $"{change.tenCoins} x 10 SEK\n" +
                              $"{change.fiveCoins} x 5 SEK\n" +
                              $"{change.twoCoins} x 2 SEK\n" +
                              $"{change.oneCoins} x 1 SEK\n"
                );


            //while (moneypool >= 1000)
            //{
            //    a = moneypool / 1000;
            //    moneypool = moneypool % 1000;

            //    Console.WriteLine(a + "x 1000 kr");

            //}

            //while (moneypool >= 500)
            //{
            //    b = moneypool / 500;
            //    moneypool = moneypool % 500;

            //    Console.WriteLine(b + "x 500 kr" + " ");
            //}

            //while (moneypool >= 100)
            //{
            //    c = moneypool / 100;
            //    moneypool = moneypool % 100;

            //    Console.WriteLine(c + "x 100 kr" + " ");
            //}

            //while (moneypool >= 50)
            //{
            //    d = moneypool / 50;
            //    moneypool = moneypool % 50;

            //    Console.WriteLine(d + "x 50 kr" + " ");
            //}

            //while (moneypool >= 20)
            //{
            //    e = moneypool / 20;
            //    moneypool = moneypool % 20;

            //    Console.WriteLine(e + "x 20 kr" + " ");
            //}

            //while (moneypool >= 10)
            //{
            //    f = moneypool / 10;
            //    moneypool = moneypool % 10;

            //    Console.WriteLine(f + "x 10 kr" + " ");
            //}

            //while (moneypool >= 5)
            //{
            //    g = moneypool / 5;
            //    moneypool = moneypool % 5;

            //    Console.WriteLine(g + "x 5 kr" + " ");
            //}

            //while (moneypool >= 2)
            //{
            //    h = moneypool / 2;
            //    moneypool = moneypool % 2;

            //    Console.WriteLine(h + "x 50 kr" + " ");
            //}

            //while (moneypool >= 1)
            //{
            //    ii = moneypool / 1;
            //    moneypool = moneypool % 1;

            //    Console.WriteLine(ii + "x 1 kr" + " ");
            //}

            return moneypool;
        }

    }
}
