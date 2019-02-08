using Capstone.Classes;
using System;
using System.Collections.Generic;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create vending machine and stock initial values
            VendingMachine vendoMatic500 = new VendingMachine();

            Menu main = new Menu();
            main.Run(vendoMatic500);
        }
    }
}

//TO Do List
//1 - add soldout logic
//2 - catch all exceptions for incorrect inputs
//3 - style cop
//4 - add fancy images for each type of product - for dispense method
//5 - perhaps color coded in display of items - either by row or type
//6 - Print Sales Report


//UNIT TESTS
//test that quantity is reduced when purchased
//exceptions arent preventing purchases
//Write tests for methods