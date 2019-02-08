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

            //Create main menu
            Menu main = new Menu();
            main.Run(vendoMatic500);
        }
    }
}

//TO Do List
//1 - Print Sales Report
//2 - Add logic for existing Sales Report
//3 - UNIT TESTS
        //Feed Money
//test that quantity is reduced when purchased
//exceptions arent preventing purchases
//Write tests for methods
//4 - style cop