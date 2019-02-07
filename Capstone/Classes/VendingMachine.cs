using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        public decimal Balance;

        private Dictionary<string, int> SalesReportDictionary = new Dictionary<string, int>();

        public Dictionary<string, VendingMachineItem> VendingMachineItems = new Dictionary<string, VendingMachineItem>();

        public VendingMachine()
        {
            //Create vending machine stock
            StockVendingMachine ourStock = new StockVendingMachine();

            //Put the stock into Propery: dictionaryOfVendingMachineItems
            VendingMachineItems = ourStock.SendVendingItems();
        }

        //Future Methods

        //TODO Write this
        public void PrintReport()
        {


        }

        /// <summary>
        /// Dispense item to user.
        /// </summary>
        /// <param name="productChoice"></param>
        public void Dispense(string productChoice)
        {
            //Update the quantity of the item in vending machine dictionary.
            string productType = VendingMachineItems[productChoice].ProductType;
            if(productType == "Chip")
            {
                Console.WriteLine("Crunch Crunch, Yum!");
            }

            else if (productType == "Drink")
            {
                Console.WriteLine("Glug Glug, Yum!");
            }

            else if (productType == "Candy")
            {
                Console.WriteLine("Munch Munch, Yum!");
            }

            else if (productType == "Gum")
            {
                Console.WriteLine("Chew Chew, Yum!");
            }

            //Update Quantity
            VendingMachineItems[productChoice].Quantity--;

            //Update Balance of user
            Balance -= VendingMachineItems[productChoice].Price;
        }



        /// <summary>
        /// Displays current vending machine state.
        /// </summary>
        /// <param name="vendoMatic500">n</param>
        public void Display()
        {
            Console.Write("Slot_Location", -14);
            Console.Write(" Name\t\t", -25);
            Console.Write(" \tPrice\t\t", -17);
            Console.Write(" Amount_Left", -10);
            Console.Write(" Type\n");
            //Console.ReadLine();

            foreach (KeyValuePair<string, VendingMachineItem> kvp in VendingMachineItems)
            {
                Console.Write($"{kvp.Value.SlotLocation,-14}");
                Console.Write($"{kvp.Value.ProductName,-25}");
                Console.Write($"${kvp.Value.Price,-17}");
                Console.Write($"{kvp.Value.Quantity.ToString(),-10}");
                Console.Write(kvp.Value.ProductType);
                Console.WriteLine();
            }
        }

    }
}
