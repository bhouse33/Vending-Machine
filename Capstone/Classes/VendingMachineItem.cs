using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachineItem
    {
        /// <summary>
        /// Represents the slot code.
        /// </summary>
        public string SlotLocation { get; }

        /// <summary>
        /// Represents the name of the product (what's on the packaging).
        /// </summary>
        public string ProductName { get; }

        /// <summary>
        /// Price of the item.
        /// </summary>
        public decimal Price { get; }

        /// <summary>
        /// Type of product: candy, gum, beverage, chips
        /// </summary>
        public string ProductType { get; }

        /// <summary>
        /// Number of items left, starts at 5.
        /// </summary>
        public int Quantity { get; set; }

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
