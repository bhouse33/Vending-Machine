﻿using Capstone.Classes;
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

///TO Do List
///

    //Print Sales Report
    //Write tests for methods
    //formatting for display()
    //test that quantity is reduced when purchased
    //exceptions arent preventing purchases