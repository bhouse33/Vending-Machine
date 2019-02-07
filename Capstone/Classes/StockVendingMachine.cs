using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// Represents stocking a vending machine.
    /// </summary>
    public class StockVendingMachine
    {
        /// <summary>
        /// Holds the vending items in a dictionary.
        /// </summary>
        private Dictionary<string, VendingMachineItem> VendingMachineItems;

        /// <summary>
        /// Initializes the vending machine inventory. 
        /// </summary>
        /// <param name="fileName"></param>
        public StockVendingMachine()
        {
            string fileName = "C:\\Users\\Brandon House\\Pairs\\capstones\\c - module - 1 - capstone - team - 0\\etc\\vendingmachine.csv";
            //Create new dictionary of vending items
            this.VendingMachineItems = new Dictionary<string, VendingMachineItem>();

            //Create the items
            PopulateVendingMachineWithInitialItems(fileName);

        }

        /// <summary>
        /// Populates vending machine with initial items.
        /// </summary>
        /// <param name="fileName"></param>
        void PopulateVendingMachineWithInitialItems(string fileName)
        {
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    while (!sr.EndOfStream)
                    {
                        string item = sr.ReadLine();
                        string[] vendingItem = item.Split('|');
                        for (int i = 0; i < 4; i++)
                        {
                            VendingMachineItems.Add(vendingItem[0], new VendingMachineItem(vendingItem[0], vendingItem[1], decimal.Parse(vendingItem[2]), vendingItem[3]));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Could not read file to stock vending machine.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
