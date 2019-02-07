using Capstone.Classes;
using System;
using System.Collections.Generic;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Vendo-Matic 200!\n");

            //Create vending machine and stock initial values
            VendingMachine vendoMatic500 = new VendingMachine();

            //Create vending machine stock (Take off truck and cart to the machine)
            //StockVendingMachine vendingMachineStock = new StockVendingMachine();



            // Console.WriteLine($"{vendoMatic500.Balance}");

        }
    }
}
