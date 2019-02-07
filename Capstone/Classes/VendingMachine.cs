using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        public decimal Balance;

        private Dictionary<string, int> SalesReportDictionary = new Dictionary<string, int>();

        private Dictionary<string, VendingMachineItem> VendingMachineItems = new Dictionary<string, VendingMachineItem>();

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


    }
}
