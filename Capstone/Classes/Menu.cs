using System;
using System.IO;

namespace Capstone.Classes
{
    public class Menu
    {
        protected string GetString(string message)
        {
            string output = string.Empty;
            Console.Write(message + " ");
            output = Console.ReadLine();
            return output;
        }

        protected int GetInteger(string message)
        {
            string output = string.Empty;
            Console.Write(message + " ");
            output = Console.ReadLine();
            int numberOutput = int.Parse(output);
            return numberOutput;
        }

        public decimal GetDecimal(string message)
        {
            string output = string.Empty;
            Console.Write(message + " ");
            output = Console.ReadLine();
            int.Parse(output);
            if (int.Parse(output) == 1 || int.Parse(output) == 2 || int.Parse(output) == 5
                || int.Parse(output) == 10 || int.Parse(output) == 20 || int.Parse(output) == 50 || int.Parse(output) == 100)
            {
                decimal numberOutput = decimal.Parse(output);
                return numberOutput;
            }
            Console.WriteLine("Invalid dollar amount");
            Console.ReadLine();

            return 0m;
        }

        /// <summary>
        /// Print out the menu.
        /// </summary>
        public void Run(VendingMachine vendoMatic500)
        {
            string choice = string.Empty;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(@"__     __             _             __  __       _   _        ____   ___   ___  ");
                Console.WriteLine(@"\ \   / /__ _ __   __| | ___       |  \/  | __ _| |_(_) ___  | ___| / _ \ / _ \ ");
                Console.WriteLine(@" \ \ / / _ \ '_ \ / _` |/ _ \ _____| |\/| |/ _` | __| |/ __| |___ \| | | | | | |");
                Console.WriteLine(@"  \ V /  __/ | | | (_| | (_) |_____| |  | | (_| | |_| | (__   ___) | |_| | |_| |");
                Console.WriteLine(@"   \_/ \___|_| |_|\__,_|\___/      |_|  |_|\__,_|\__|_|\___| |____/ \___/ \___/ ");
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Welcome to Vendo-Matic 500\n");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green ^ ConsoleColor.DarkBlue;
                //Console.ForegroundColor = ConsoleColor.Dared;
                Console.WriteLine("(1) Display Vending Machine Item");
                Console.WriteLine("(2) Purchase");
                Console.WriteLine("(Q) Quit");
                Console.ResetColor();
                choice = GetString("> Choose an option: ");

                if (choice.ToLower() == "q")
                {
                    return;
                }

                //Run the sales report
                else if (choice == "0101")
                {
                    vendoMatic500.PrintReport();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\nSales report generated.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.Clear();

                    //Print report to screen
                    try
                    {
                        using (StreamReader sr = new StreamReader("SalesReport.txt"))
                        {
                            while (!sr.EndOfStream)
                            {
                                string line = sr.ReadLine();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine(line);
                            }
                        }
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("Press enter to continue:");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    catch (IOException iox)
                    {
                        Console.WriteLine("Error writing to the sales report");
                        Console.WriteLine(iox.Message);
                    }
                }

                //Display Vending Machine Item
                else if (choice == "1")
                {
                    Console.Clear();
                    vendoMatic500.Display();
                    Console.WriteLine("\nPlease press enter to return to main menu");
                    Console.ReadLine();
                    Console.Clear();
                }

                //Call Purchase Menu
                else if (choice == "2")
                {
                    Console.Clear();
                    PurchaseMenu(vendoMatic500);
                }

                else
                {
                    Console.WriteLine("Invalid Option");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }


        /// <summary>
        /// Moves to the purchase menu.
        /// </summary>
        /// <param name="balance"></param>
        public void PurchaseMenu(VendingMachine vendoMatic500)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("(1) Feed Money");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("(2) Select Product");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("(3) Finish Transaction");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"Current Money Provided: {vendoMatic500.Balance:c2} ");
            Console.ResetColor();
            string choice = GetString(">Please enter your choice.");

            if (choice == "1")
            {
                vendoMatic500.Balance = FeedMoney(vendoMatic500.Balance);
                Console.Clear();
                PurchaseMenu(vendoMatic500);
            }
            else if (choice == "2")
            {
                //Display Items for user to see what's there and make a choice
                vendoMatic500.Display();
                string productChoice = "";
                while (true)
                {
                    //Prompt user for item and hold choice in variable
                    productChoice = GetString(">Please enter the slot of your choice.").ToUpper();

                    if (vendoMatic500.VendingMachineItems.ContainsKey(productChoice) &&
                        vendoMatic500.VendingMachineItems[productChoice].Quantity != 0)
                    {
                        break;
                    }

                    else if (!vendoMatic500.VendingMachineItems.ContainsKey(productChoice))
                    {
                        Console.WriteLine("That code does not exist. TRY AGAIN.");
                        Console.ReadLine();
                    }

                    //Check to see if the item selected is sold out
                    else if (vendoMatic500.VendingMachineItems[productChoice].Quantity == 0)
                    {
                        Console.WriteLine("Item is sold out :(");
                        Console.ReadLine();
                    }
                }

                //Dispense item - if quantity is available and they have enough money and if code exists
                if (vendoMatic500.Balance >= vendoMatic500.VendingMachineItems[productChoice].Price)
                {
                    vendoMatic500.Dispense(productChoice);
                }
                else
                {
                    Console.WriteLine("Insufficient funds. Please feed me money.");
                    Console.ReadLine();
                    Console.Clear();
                    PurchaseMenu(vendoMatic500);
                }

                //Update the audit report
                LogMessage($"{vendoMatic500.VendingMachineItems[productChoice].ProductName} {productChoice} ",
                    vendoMatic500.Balance + vendoMatic500.VendingMachineItems[productChoice].Price, vendoMatic500.Balance);

                //Return to purchase menu
                Console.Clear();
                PurchaseMenu(vendoMatic500);
            }

            //Finish Transaction
            else if (choice == "3")
            {
                Console.Clear();
                //Return the customer's money in quarters, dimes, nickels (using smallest amount possible)
                //Look at the Balance and Call method to calculate return money
                PrintChange(vendoMatic500);

                //Update machine's balance to $0
                vendoMatic500.Balance = 0;
                Console.WriteLine($"Balance: {vendoMatic500.Balance}");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Invalid Option");
                Console.ReadLine();
                Console.Clear();
                PurchaseMenu(vendoMatic500);

            }
        }

        /// <summary>
        /// Prints change in coins.
        /// </summary>
        public void PrintChange(VendingMachine vendoMatic500)
        {
            int quarters = 0;
            int dimes = 0;
            int nickels = 0;

            while (vendoMatic500.Balance >= (decimal).25)
            {
                vendoMatic500.Balance -= (decimal).25;
                quarters++;
            }
            while (vendoMatic500.Balance >= (decimal).10)
            {
                vendoMatic500.Balance -= (decimal).10;
                dimes++;
            }
            while (vendoMatic500.Balance >= (decimal).05)
            {
                vendoMatic500.Balance -= (decimal).05;
                nickels++;
            }

            Console.WriteLine("Change returned:");
            Console.WriteLine($"Quarters: {quarters}");
            Console.WriteLine($"Dimes: {dimes}");
            Console.WriteLine($"Nickels: {nickels}");
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
                {
                    sw.WriteLine($"{DateTime.Now.ToString()} {message,-23} {$"{adjustment:c2}",-8}  {balance:c2}");
                }
            }
            catch (Exception ex)
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
            Console.Clear();
            Console.WriteLine("How much money do you want to feed into the vending machine?");
            decimal moneyFed = GetDecimal("Enter bill amount in whole bills only (eg. $1, $2, $5 or $10): $");
            balance += moneyFed;
            LogMessage("FEED MONEY", moneyFed, balance);
            return balance;
        }
    }
}
