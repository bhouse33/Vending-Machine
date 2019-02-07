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

        public Menu ()
        {

        }

        /// <summary>
        /// Print out the menu.
        /// </summary>
        public void Run()
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
                    Display();
                    
                }

                //Call Purchase Menu
                else if (choice == "2")
                {
                    Console.Clear();
                    PurchaseMenu();
                }

                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Option");
                    Console.ReadLine();
                }

                
            }

            


        }

        public void Display()
        {
            Console.Write("Slot_Location", -15);
            Console.Write("Name", -7);
            Console.Write("Price", -7);
            Console.Write("Amount Left", -3);
            Console.Write("Type");
            Console.ReadLine();
        }

        public void PrintReport()
        {


        }

        public void PurchaseMenu()
        {


        }

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

    }
}
