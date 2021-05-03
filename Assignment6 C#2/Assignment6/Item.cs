using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Haase
/// </summary>
namespace Assignment6
{
    /// <summary>
    /// Klass som innehåller data för ett Item som är tänkt vara en del av en Invoice.
    /// </summary>
    public class Item
    {
        private string description;
        private int quantity;
        private double unitPrice;
        private int taxPercentage;
        private double totalTax;
        private double totalPrice;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public Item()
        {

        }

        /// <summary>
        /// Ställer in totala skatten och totala priset.
        /// </summary>
        public void SetTotals()
        {
            totalTax = (unitPrice * quantity) * ((double)taxPercentage / 100);
            totalPrice = unitPrice * quantity + totalTax;
        }

        /// <summary>
        /// Hämtar och ställer in items namn.
        /// </summary>
        public string Description { get => description; set => description = value; }

        /// <summary>
        /// Hämtar och ställer in items antal.
        /// </summary>
        public int Quantity { get => quantity; set => quantity = value; }

        /// <summary>
        /// Hämtar och ställer in items pris för varje.
        /// </summary>
        public double UnitPrice { get => unitPrice; set => unitPrice = value; }

        /// <summary>
        /// Hämtar och ställer in items skatt.
        /// </summary>
        public int TaxPercentage { get => taxPercentage; set => taxPercentage = value; }

        /// <summary>
        /// Hämtar och ställer in items totala skatt
        /// </summary>
        public double TotalTax { get => Math.Truncate(totalTax * 100) / 100; set => totalTax = value; }

        /// <summary>
        /// Hämtar och ställer in items totala pris.
        /// </summary>
        public double TotalPrice { get => Math.Truncate(totalPrice * 100) / 100; set => totalPrice = value; }
    }
}
