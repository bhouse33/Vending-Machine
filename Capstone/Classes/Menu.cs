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


        public void Run()
        {


        }

        public void Display()
        {


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
