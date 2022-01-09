using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine_Assignment.Models.Products
{
    public class ItemFactory
    {
        
        public List<Product> AllProducts = new List<Product>();

        public List<Product> AllProds()
        {
            Food Chips = new Food("Chips", 50, "Tasty snack made of potato");
            Food Chocolate = new Food("Chocolate", 80, "Tasty snack made of cocoa");
            Food Carbonara = new Food("Carbonara", 100, "Tasty pasta dish that will keep you full all day");

            Drink CocaCola = new Drink("Coca Cola", 50, "Sugary drink");
            Drink Fanta = new Drink("Fanta", 20, "Sugary orange drink");
            Drink Water = new Drink("Water", 10, "Just some plain water");

            Phone iPhone = new Phone("iPhone 12", 7000, "A smartphone produced by Apple");
            Phone Samsung = new Phone("Samsung Galaxy S21", 5000, "A smartphone produced by Samsung");
            Phone Huawei = new Phone("Huawei P40", 4500, "A smartphone produced by Huawei");

            List<Product> prods = new List<Product>
            {
                Chips,
                Chocolate,
                Carbonara,
                CocaCola,
                Fanta,
                Water,
                iPhone,
                Samsung,
                Huawei
            };


            return prods;

        }

        public ItemFactory(List<Product> AllProducts)
        {
            this.AllProducts = AllProducts;
        }

    }
}
