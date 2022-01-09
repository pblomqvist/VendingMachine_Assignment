using System;
using Xunit;
using VendingMachine_Assignment.Models.Features;
using VendingMachine_Assignment.Models.Products;
using System.Collections.Generic;
using VendingMachine_Assignment;

namespace TestVendingMachine
{
    public class UnitTest1
    {
       
        [Fact]
        public void CorrectExamine()
        {
            IVending Test = new VendingOptions();
            int expected = 1;
            int selected = 1;
            int productID = 0;

            productID = Test.Examine(selected);

            Assert.Equal(expected, productID);

        }

        [Fact]
        public void RemoveItemAfterUse()
        {
            IVending Test = new VendingOptions();
            List<Product> customerItems = new List<Product>();
            Food Chips = new Food("Chips", 50, "Tasty snack made of potato"); ;
            customerItems.Add(Chips);

            int selected = 1;

            Test.Use(customerItems, selected);

            Assert.Empty(customerItems);

        }

        [Theory]
        [InlineData(2, 2)]
        [InlineData(4, 4)]
        [InlineData(5, 5)]
        [InlineData(8, 8)]
        [InlineData(3, 3)]
        public void MultipleExamine(int expected, int selected)
        {
            IVending Test = new VendingOptions();
            int productID;

            productID = Test.Examine(selected);

            Assert.Equal(expected, productID);

        }

        [Fact]
        public void TestZeroChange()
        {
            int balance = 0;

            Change change = new Change();
            string msg = "";

            msg = change.GiveChange(balance, msg);

            Assert.Equal("No money to return", msg);

        }

        [Fact]
        public void TestAppropriateChangeMsg()
        {
            int balance = 450;

            Change change = new Change();
            string msg = "";

            msg = change.GiveChange(balance, msg);

            Assert.Equal("Your change is:\n4 x 100 kr\n1 x 50 kr\n", msg);

        }

        [Theory]
        [InlineData(300, 50, 1)]
        [InlineData(500, 100, 3)]
        [InlineData(10, 10, 6)]
        [InlineData(1000, 80, 2)]
        public void CorrectBalanceAfterPurchase(int balance, int price, int userpurchase)
        {
            IVending Test = new VendingOptions();

            int expectedResult = balance - price;

            balance = Test.Purchase(balance, price, userpurchase);

            Assert.Equal(expectedResult, balance);
        }

        [Theory]
        [InlineData(30, 1020)]
        [InlineData(1020, 800)]
        [InlineData(510, 550)]
        [InlineData(600, 600)]
        [InlineData(90, 720)]
        [InlineData(10000000, 0)]
        [InlineData(800, 10)]
        public void DenyInvalidDenoms(int fill, int balance)
        {
            IVending Test = new VendingOptions();

            string errorMsg = "Not a valid amount. Try again.";

            Test.InsertMoney(fill, balance);

            Assert.Equal("Not a valid amount. Try again.", errorMsg);


        }
    }
}
