using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        public decimal Balance;

        private Dictionary<string, int> SalesReportDictionary = new Dictionary<string, int>();

        public VendingMachine()
        {
            Dictionary<string, VendingMachineItem> stockIt = new Dictionary<string, VendingMachineItem>();
            StockVendingMachine y = new StockVendingMachine();
            stockIt=y.SendVendingItems();
            Console.WriteLine(stockIt);
            foreach( item in stockIt)
            {
                Console.WriteLine(item.SlotLocation);
                Console.WriteLine(item.Price);
                Console.WriteLine(item.ProductName);

            }
        }



    }
}
