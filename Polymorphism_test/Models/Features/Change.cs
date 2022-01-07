using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine_Assignment.Models.Products;

namespace VendingMachine_Assignment.Models.Features
{
    public class Change
    {
        public int thousandBills { get; }
        public int fiveHundredBills { get; }
        public int hundredBills { get; }
        public int fiftyBills { get; }
        public int twentyBills { get; }
        public int tenCoins { get; }
        public int fiveCoins { get; }
        public int twoCoins { get; }
        public int oneCoins { get; }

        public Change(int change)
        {

            thousandBills = (change / 1000);
            change %= 1000;

            fiveHundredBills = (change / 500);
            change %= 500;

            hundredBills = (change / 100);
            change %= 100;

            fiftyBills = (change / 50);
            change %= 50;

            twentyBills = (change / 20);
            change %= 20;

            tenCoins = (change / 10);
            change %= 10;

            fiveCoins = (change / 5);
            change %= 5;

            twoCoins = (change / 2);
            change %= 2;

            oneCoins = (change / 1);
            change %= 1;

        }

    }
}
