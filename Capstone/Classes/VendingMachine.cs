using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        public decimal Balance;

        private Dictionary<string, int> SalesReportDictionary = new Dictionary<string, int>();

        //Should be updated every time an item is dispensed.
        public Dictionary<string, VendingMachineItem> VendingMachineItems = new Dictionary<string, VendingMachineItem>();

        public VendingMachine()
        {
            //Create vending machine stock
            StockVendingMachine ourStock = new StockVendingMachine();

            //Put the stock into Propery: dictionaryOfVendingMachineItems
            VendingMachineItems = ourStock.SendVendingItems();
        }

        //Called with vendoMatic500.PrintReport();
        //Print the pipe delimited sales report to a file
        public void PrintReport()
        {
            //Create an output file
            try
            {
                using (StreamWriter sr = new StreamWriter("SalesReport.txt", true))
                {
                    //Loop through the SalesReport dictionary and write to SalesReport.txt file
                    foreach (KeyValuePair<string, int> item in SalesReportDictionary)
                    {
                        //Potoato crisps|10
                        string line = item.Key.ToString() + item.Value.ToString();
                        sr.WriteLine(line);
                    }
                    sr.WriteLine("Hi, there");
                }
            }
            catch(IOException iox)
            {
                Console.WriteLine("Error writing to the sames report");
                Console.WriteLine(iox.Message);
            }
        }

        /// <summary>
        /// Dispense item to user.
        /// </summary>
        /// <param name="productChoice"></param>
        public void Dispense(string productChoice)
        {
            //Update the quantity of the item in vending machine dictionary.
            string productType = VendingMachineItems[productChoice].ProductType;
            if (productType == "Chip")
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
            Console.ReadLine();
            //Update Quantity
            VendingMachineItems[productChoice].Quantity--;

            //Update Balance of user
            Balance -= VendingMachineItems[productChoice].Price;

            //Add to report dictionary
            SalesReportDictionary[]
        }


        /// <summary>
        /// Displays current vending machine state.
        /// </summary>
        /// <param name="vendoMatic500">n</param>
        public void Display()
        {
            Console.Write("Slot_Location", -10);
            Console.Write("\tName", -20);
            Console.Write("\t\t   Price", -6);
            Console.Write("  Amount_Left", -6);
            Console.Write("\t Type\n");
            //Console.ReadLine();

            foreach (KeyValuePair<string, VendingMachineItem> kvp in VendingMachineItems)
            {
                Console.Write($" {kvp.Value.SlotLocation,-14}");
                Console.Write($"{kvp.Value.ProductName,-20}");
                Console.Write($"${kvp.Value.Price,-10}");
                Console.Write($"{kvp.Value.Quantity.ToString(),-11}");
                Console.Write(kvp.Value.ProductType);
                Console.WriteLine();
            }
        }
    }
}
