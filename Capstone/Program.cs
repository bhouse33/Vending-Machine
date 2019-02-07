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

            //Create vending machine stock (Take off truck and cart to the machine)
            StockVendingMachine vendingMachineStock = new StockVendingMachine();

            //Create vending machine - take items off cart and load to machine
            VendingMachine vendoMatic500 = new VendingMachine();

        }
    }
}
