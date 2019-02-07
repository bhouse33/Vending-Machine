using System;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            //Object to stock the vending machine.
            Stock vendingMachineStock = new Stock(string fileName);

            //Create vending machine
            VendingMachine vendoMatic500 = new VendingMachine(vendingMachineStock.dictOfItems);


        }
    }
}
