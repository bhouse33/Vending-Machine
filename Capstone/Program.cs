using Capstone.Classes;
using System;
using System.Collections.Generic;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            //Object to stock the vending machine.
            StockVendingMachine vendingMachineStock = new StockVendingMachine();

            //Create vending machine
            VendingMachine vendoMatic500 = new VendingMachine(vendingMachineStock.dictOfItems);


        }
    }
}
