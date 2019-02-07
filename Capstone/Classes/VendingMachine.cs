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

            //Write out the stock in the vending machine to make sure we have the items
            //Iterate through dictionaryOfVendingMachineItems and print ProductName
            //foreach(KeyValuePair<string, VendingMachineItem> kvp in VendingMachineItems)
            //{
            //    Console.WriteLine($"ProductName: {kvp.Value.ProductName}");
            //}
        }

        //Future Methods

        //TODO Write this
        public void PrintReport()
        {


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
