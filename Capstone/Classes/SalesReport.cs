using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class SalesReport
    {
        //Property to hold SalesReport

        public SalesReport()
        {
          ////Create new dictionary for sales report with ProductName and Amount sold
          //  this.VendingMachineItems = new Dictionary<string, int>();

          //  //Create the items
          //  PopulateVendingMachineWithInitialItems(fileName);
        }


        public void CreateInitialSalesReportFileOnce(string fileName, SalesReport salesReport)
        {
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    while (!sr.EndOfStream)
                    {
                        string item = sr.ReadLine();
                        string[] vendingItem = item.Split('|');
                        this.salesReport.Add(vendingItem[0], new VendingMachineItem(vendingItem[0], vendingItem[1], decimal.Parse(vendingItem[2]), vendingItem[3]));
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
