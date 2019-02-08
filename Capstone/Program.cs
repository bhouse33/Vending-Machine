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
//1** - formatting for display() - Display the "Display the Vending Machine Item" formatting fix (Brandon) - done
//2 - Feed in only read dollar amounts ($1, $2, $20, $100, $10, $5, $50)
//3** - Code for (3) Finish Transaction - while loop (Brandon) - done
//4 - add soldout logic
//5 - Change wording on FeedMoney menu
//6 - Add to upper and to lower in enter product menu
//7 - get the log.txt to display feedmoney amounts with the $.00
//8 - add fancy images for each type of product - for dispense method
//9 - perhaps color coded in display of items - either by row or type
//10 - catch all exceptions for incorrect inputs


    //Print Sales Report
    //Write tests for methods
    
    //UNIT TESTS
    //test that quantity is reduced when purchased
    //exceptions arent preventing purchases