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
                    vendoMatic500.PrintReport();
                }

                //Display Vending Machine Item
                else if (choice == "1")
                {
                    Console.Clear();
                    vendoMatic500.Display();
                    
                }

                //Call Purchase Menu
                else if (choice == "2")
                {
                    Console.Clear();
                    PurchaseMenu(vendoMatic500);
                }

                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Option");
                    Console.ReadLine();
                }
            }
        }

      
        /// <summary>
        /// Moves to the purchase menu.
        /// </summary>
        /// <param name="balance"></param>
        public void PurchaseMenu(VendingMachine vendoMatic500)
        {
            Console.WriteLine("(1) Feed Money");
            Console.WriteLine("(2) Select Product");
            Console.WriteLine("(3) Finish Transaction");
            Console.WriteLine($"Current Money Provided: {vendoMatic500.Balance:c2} ");
            string choice = GetString(">Please enter your choice.");

            if (choice =="1")
            {
               vendoMatic500.Balance=FeedMoney(vendoMatic500.Balance);
               Console.Clear();
               PurchaseMenu(vendoMatic500);
            }
            else if (choice == "2")
            {
                //Display Items for user to see what's there and make a choice
                vendoMatic500.Display();
                //Prompt user for item and hold choice in variable
                string productChoice=GetString(">Please enter the slot of your choice.");                

                //Check if product code does not exist
                if(!vendoMatic500.VendingMachineItems.ContainsKey(productChoice))
                {
                    Console.WriteLine("That code does not exist. TRY AGAIN.");
                    PurchaseMenu(vendoMatic500);
                }

                //Dispense item - if quantity is available and they have enough money and if code exists
                vendoMatic500.Dispense(productChoice);

                //Update the audit report
                LogMessage($"{vendoMatic500.VendingMachineItems[productChoice].ProductName} {productChoice} ", 
                    vendoMatic500.Balance + vendoMatic500.VendingMachineItems[productChoice].Price, vendoMatic500.Balance);

                //Return to purchase menu
                Console.Clear();
                PurchaseMenu(vendoMatic500);
            }
        }

        /// <summary>
        /// Writes to Log.txt for audit report.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="adjustment"></param>
        /// <param name="balance"></param>
        public void LogMessage(string message, decimal adjustment, decimal balance)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("Log.txt", true))
                    sw.WriteLine($"{DateTime.Now.ToString()} {message,-20} ${adjustment,-10} {balance:c2}");
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
