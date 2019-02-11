using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        public decimal Balance;

        public Dictionary<string, int> SalesReportDictionary = new Dictionary<string, int>();

        //Should be updated every time an item is dispensed.
        public Dictionary<string, VendingMachineItem> VendingMachineItems = new Dictionary<string, VendingMachineItem>();

        public VendingMachine()
        {
            //Create vending machine stock
            StockVendingMachine ourStock = new StockVendingMachine();

            //Put the stock into Propery: dictionaryOfVendingMachineItems
            VendingMachineItems = ourStock.SendVendingItems();

            // Populate SalesReport Dictionary if the file does not exist
            if (!File.Exists("SalesReport.txt"))
            {
                foreach (KeyValuePair<string, VendingMachineItem> kvp in VendingMachineItems)
                {
                    SalesReportDictionary.Add(kvp.Value.SlotLocation, 0);
                }
            }
            //If the file already exists, populate the SalesReportDictionary with the file
            else
            {
                try
                {
                    using (StreamReader sr = new StreamReader("SalesReport.txt"))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            string[] reportLineArray = line.Split('|');

                            if(line.Equals(""))
                            {
                                break;
                            }

                            foreach (KeyValuePair<string, VendingMachineItem> kvp in VendingMachineItems)
                            {
                                if(reportLineArray[0] == kvp.Value.ProductName)
                                {
                                    SalesReportDictionary.Add(kvp.Value.SlotLocation, int.Parse(reportLineArray[1]));
                                }
                            }
                        }
                    }
                }

                catch (IOException iox)
                {
                    Console.WriteLine("Error writing to the sales report");
                    Console.WriteLine(iox.Message);
                }
            }
        }

        //Called with vendoMatic500.PrintReport();
        //Print the pipe delimited sales report to a file
        public void PrintReport()
        {
            decimal totalSales = 0;
            //Create an output file
            try
            {
                using (StreamWriter sr = new StreamWriter("SalesReport.txt"))
                {
                    //Loop through the SalesReport dictionary and write to SalesReport.txt file
                    foreach (KeyValuePair<string, int> item in SalesReportDictionary)
                    {
                        //Potoato crisps|10
                        string line = VendingMachineItems[item.Key].ProductName.ToString() + "|" + item.Value.ToString();
                        sr.WriteLine(line);
                        totalSales += VendingMachineItems[item.Key].Price * item.Value;
                    }

                    //print total sales to date
                    sr.WriteLine();
                    sr.WriteLine($"**TOTAL SALES** {totalSales:C2}");

                }
            }
            catch (IOException iox)
            {
                Console.WriteLine("Error writing to the sales report");
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
                Console.Clear();
                Console.WriteLine("Crunch Crunch, Yum!");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine(@"````````       .::::::::-::::///::-       ````````");
                Console.WriteLine(@"`````          /mmmmmmmmmmmmmmmmmmo          `````");
                Console.WriteLine(@"```             sdmmmmmmmmmmmmmmds`            ```");
                Console.WriteLine(@"`               -hddmmmmmmmmmmmdy.               `");
                Console.WriteLine(@"                 /hhdmmmmmmmmddyo                 ");
                Console.WriteLine(@"                 +hhdmmmmmmmmdhh/                 ");
                Console.WriteLine(@"                 :hhd        dhh.                 ");
                Console.WriteLine(@"                 .yhd  Chips hhh.                 ");
                Console.WriteLine(@"                 `hhd        dhh:                 ");
                Console.WriteLine(@"                 `hyhdmmmmmmmdhh/                 ");
                Console.WriteLine(@"                 .hhydmmmmmmmdhh+                 ");
                Console.WriteLine(@"                 :hhhdmmmmmmmdhh+                 ");
                Console.WriteLine(@"                 +yhdmmmmmmmmmhys                 ");
                Console.WriteLine(@"                +yhdmmmmmmmmmmmdy/                ");
                Console.WriteLine(@"`              /dmmmmmmmmmmmmmmmmdo              `");
                Console.WriteLine(@"```            `-......```...-----.            ```");
                Console.WriteLine(@"`````          ````````````````````          `````");
                Console.WriteLine(@"`````````       `````````````````         ````````");
                Console.ResetColor();
            }

            else if (productType == "Drink")
            {
                Console.Clear();
                Console.WriteLine("Glug Glug, Yum!");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(@"     `.---:::::-`  `     ");
                Console.WriteLine(@"   :yhyooooosso+-.-oo/`  ");
                Console.WriteLine(@"  `oyo/:/+ooyyso++osyy.  ");
                Console.WriteLine(@" -syyys+ooooooo+o+oosss/ ");
                Console.WriteLine(@" +ssss++++/++++/++/++oys ");
                Console.WriteLine(@" ossss/++/++so++/++/osys ");
                Console.WriteLine(@" +ssss+/+-/yoso/+//+oyys ");
                Console.WriteLine(@" +ysss+//`:+::///:/:+dms ");
                Console.WriteLine(@" +yssyo///osyo/sssso/mmo ");
                Console.WriteLine(@" +o/sdhyy          hsdso ");
                Console.WriteLine(@" +s-sdyys   Soda   ohhhs ");
                Console.WriteLine(@" +o-dds/s          :o+yo ");
                Console.WriteLine(@" +ssdd:-syhhy+hyh//+oyhs ");
                Console.WriteLine(@" +y+/+o-:/oo+/++so++osyo ");
                Console.WriteLine(@" +yo-:y/+o+//sss++++osy+ ");
                Console.WriteLine(@" +yooso/+++oooo++++++sy+ ");
                Console.WriteLine(@" /ysss+++/+ooo++++/+oss/ ");
                Console.WriteLine(@"  :oss+++++ooo++++++oo:` ");
                Console.WriteLine(@"    :ososo+oooooooss/`   ");
                Console.WriteLine(@"      `..-:-:-..``       ");
                Console.ResetColor();
            }

            else if (productType == "Candy")
            {   //9 spaces max - "  Candy  "
                string candyName = VendingMachineItems[productChoice].ProductName;
                Console.Clear();
                Console.WriteLine("Munch Munch, Yum!");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(@"                               ``.-/+os-          ");
                Console.WriteLine(@"                       ``.-:+osyhhhhhhhh:         ");
                Console.WriteLine(@"               ``.-:/osyhhhhhhdddddhhhhhh/        ");
                Console.WriteLine(@"       ```.:/+osyhhhhddddhddddddddhhhhhhhho`      ");
                Console.WriteLine(@"  `-/+osyhhhddhhhhhdhdddddddddddddddhhhhhhhs.     ");
                Console.WriteLine(@"  .yhhhhhhhhhddhhhh         ddddddddhhhhhhhhy.    ");
                Console.WriteLine(@"   :hhhhhhhhhdddddd  Candy  dddddddddddddddhhy:   ");
                Console.WriteLine(@"    +hhhdhhhhhddddd         dddddddddddddhdhhhy-  ");
                Console.WriteLine(@"    `yhhhhhhhddddddddddddddddddddddhhdhhhyso/:.`  ");
                Console.WriteLine(@"     -hhdhdddddddddddddddddddhhhhhyso/:-.`        ");
                Console.WriteLine(@"      +hdhhhhdhdddddddhhhhhyso+/-.``              ");
                Console.WriteLine(@"      `shdddddhhhhhhhyso/:.``                     ");
                Console.WriteLine(@"       .hhhhhhyso+:-```                           ");
                Console.WriteLine(@"        -o+:-.`                                   ");
                Console.ResetColor();
            }

            else if (productType == "Gum")
            {
                Console.Clear();
                Console.WriteLine("Chew Chew, Yum!");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(@":::::::::::::::::::::::://////////////+++++++ooo ");
                Console.WriteLine(@"/////:::::::::::////////////////++++++++ooooooss`");
                Console.WriteLine(@"/////////////////         ////////++++++++ooooos`");
                Console.WriteLine(@"/+///////////////   Gum   ////////////++++++oooo.");
                Console.WriteLine(@"++++++///////////         //////////////++++++oo.");
                Console.WriteLine(@"+++++++++////////////////:::::::://///////+++++o.");
                Console.WriteLine(@"+++++++/////////:::::::::::::--:-:::::::::::////.");
                Console.ResetColor();
            }
            Console.ReadLine();

            //Update Quantity

            VendingMachineItems[productChoice].Quantity--;

            //Update Balance of user
            Balance -= VendingMachineItems[productChoice].Price;

            foreach (KeyValuePair<string, int> item in SalesReportDictionary)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }

            //Add to report dictionary
            SalesReportDictionary[VendingMachineItems[productChoice].SlotLocation]++;
        }


        /// <summary>
        /// Displays current vending machine state.
        /// </summary>
        /// <param name="vendoMatic500">n</param>
        public void Display()
        {
            Console.Write("\nSlot_Location", -10);
            Console.Write("\tName", -20);
            Console.Write("\t\t   Price", -6);
            Console.Write("  Amount_Left", -6);
            Console.Write("\t Type\n");
            //Console.ReadLine();

            foreach (KeyValuePair<string, VendingMachineItem> kvp in VendingMachineItems)
            {
                //Logic to color-code based on type
                if (kvp.Value.ProductType == "Chip")
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                if(kvp.Value.ProductType == "Candy")
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                if (kvp.Value.ProductType == "Drink")
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                if (kvp.Value.ProductType == "Gum")
                    Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($" {kvp.Value.SlotLocation,-14}");
                Console.Write($"{kvp.Value.ProductName,-20}");
                Console.Write($"${kvp.Value.Price,-10}");
                Console.Write($"{kvp.Value.Quantity.ToString(),-11}");
                Console.Write(kvp.Value.ProductType);
                Console.WriteLine();
            }
            Console.ResetColor();
        }
    }
}

