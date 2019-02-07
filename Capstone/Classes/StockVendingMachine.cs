using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class StockVendingMachine
    {
        //=new Dictionary<string, VendingMachineItem>()

        /// <summary>
        /// Dictionary of vending machine items.
        /// </summary>
        private Dictionary<string, VendingMachineItem> VendingMachineItems;

        public StockVendingMachine(string fileName)
        {
            this.VendingMachineItems = new Dictionary<string, VendingMachineItem>();
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

                           // VendingMachineItems.Add
                            }
                    }
                }



            }
            catch (Exception ex)
            {

            }
        }




    }
}
