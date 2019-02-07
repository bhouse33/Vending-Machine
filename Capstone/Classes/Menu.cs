using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class Menu
    {
        protected string GetString(string message)
        {
            string output = String.Empty;
            Console.Write(message + " ");
            output = Console.ReadLine();
            return output;
        }

        protected int GetInteger(string message)
        {
            string output = String.Empty;
            Console.Write(message + " ");
            output = Console.ReadLine();
            int numberOutput = int.Parse(output);
            return numberOutput;
        }

        protected decimal GetDecimal(string message)
        {
            string output = String.Empty;
            Console.Write(message + " ");
            output = Console.ReadLine();
            decimal numberOutput = decimal.Parse(output);
            return numberOutput;
        }

        /// <summary>
        /// Print out the menu.
        /// </summary>
        public void Run(VendingMachine vendoMatic500)
        {

            while(true)
            {
                Console.WriteLine("Welcome to Vendo-Matic 500");
                Console.WriteLine("(1) Display Vending Machine Item");
                Console.WriteLine("(2) Purchase");
                Console.WriteLine("(Q) Quit");
                string choice = GetString("> Choose an option: ");

                if (choice == "Q" || choice == "q")
                {
                    break;
                }

                //Run the sales report
                else if (choice == "0101")
                {
                    Console.Clear();
                    PrintReport();
                }

                //Display Vending Machine Item
                else if (choice == "1")
                {
                    Console.Clear();
                    Display(vendoMatic500);
                    
                }

                //Call Purchase Menu
                else if (choice == "2")
                {
                    Console.Clear();
                    PurchaseMenu(vendoMatic500.Balance);
                }

                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Option");
                    Console.ReadLine();
                }
            }
        }

        public void Display(VendingMachine vendoMatic500)
        {
            Console.Write("Slot_Location", -14);
            Console.Write(" Name\t\t", -25);
            Console.Write(" \tPrice\t\t", -17);
            Console.Write(" Amount_Left", -10);
            Console.Write(" Type\n");
            //Console.ReadLine();

            foreach (KeyValuePair<string, VendingMachineItem> kvp in vendoMatic500.VendingMachineItems)
            {
                Console.Write($"{kvp.Value.SlotLocation, -14}");
                Console.Write($"{kvp.Value.ProductName, -25}");
                Console.Write($"${kvp.Value.Price,-17}");
                Console.Write($"{kvp.Value.Quantity.ToString(), -10}");
                Console.Write(kvp.Value.ProductType);
                Console.WriteLine();
            }
        }

        public void PrintReport()
        {


        }

        public void PurchaseMenu(decimal balance)
        {
            Console.WriteLine("(1) Feed Money");
            Console.WriteLine("(2) Select Product");
            Console.WriteLine("(3) Finish Transaction");
            Console.WriteLine($"Current Money Provided: {balance:c2} ");
            string choice = GetString(">Please enter your choice.");

            if (choice =="1")
            {
               balance=FeedMoney(balance);
               Console.Clear();
               PurchaseMenu(balance);
            }
            else if (choice == "2")
            {
                //Display();
            }




        }

        /// <summary>
        /// Writes to Log.txt
        /// </summary>
        /// <param name="message"></param>
        /// <param name="adjustment"></param>
        /// <param name="balance"></param>
        public void LogMessage(string message, decimal adjustment, decimal balance)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("Log.txt"))
                    sw.WriteLine(DateTime.Now.ToShortTimeString(), -15, (message, -15), (adjustment, -7), (balance));
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error cannot write to file");
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Feeding money into current vending machine balance.
        /// </summary>
        /// <param name="balance">current balance</param>
        /// <returns>new balance</returns>
        public decimal FeedMoney(decimal balance)
        {
            Console.WriteLine("How much money do you want to feed into the vending machine?");
            decimal moneyFed = GetDecimal("$1, $2, $5 or $10");
            balance += moneyFed;
            LogMessage("FEED MONEY", moneyFed, balance);
            return balance;
        }

    }
}
