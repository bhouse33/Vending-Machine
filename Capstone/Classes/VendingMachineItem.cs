using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachineItem
    {
        /// <summary>
        /// Represents the slot code
        /// </summary>
        public string SlotLocation;

        /// <summary>
        /// Represents the name of the product (what's on the packaging).
        /// </summary>
        public string ProductName;

        /// <summary>
        /// Price of the item.
        /// </summary>
        public decimal Price;

        /// <summary>
        /// Type of product: candy, gum, beverage, chips
        /// </summary>
        public string ProductType;

        /// <summary>
        /// Number of items left, starts at 5.
        /// </summary>
        public int Quantity;

        /// <summary>
        /// Create new Vending Machine Item.
        /// </summary>
        /// <param name="slotLocation"></param>
        /// <param name="productName"></param>
        /// <param name="price"></param>
        /// <param name="productType"></param>
        public VendingMachineItem(string slotLocation, string productName, decimal price, string productType)
        {
            this.SlotLocation = slotLocation;
            this.ProductName = productName;
            this.Price = price;
            this.ProductType = productType;
            this.Quantity = 5;
        }
    }
}
