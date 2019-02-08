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

            //Create Sales report - only do this once
            //Add logic here to read the file if it exists already
            //Populate the dictionary
            SalesReport salesReport = new SalesReport();
            salesReport.CreateInitialSalesReportFileOnce("vendingmachine.csv", salesReport) ;

            //Create main menu
            Menu main = new Menu();
            main.Run(vendoMatic500);
        }
    }
}

//TO Do List
//1 - add fancy images for each type of product - for dispense method
//2 - perhaps color coded in display of items - either by row or type
//3 - Print Sales Report TIA
//4 - Line up report again
//5 - Add existing report logic


//UNIT TESTS
//test that quantity is reduced when purchased
//exceptions arent preventing purchases
//Write tests for methods
//3 - style cop