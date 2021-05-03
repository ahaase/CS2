using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Haase
/// </summary>
namespace Assignment_5
{
    /// <summary>
    /// Klass som hanterar EventArgs för när flyget ändrar rutt.
    /// </summary>
    public class ChangeRouteEventArgs : EventArgs
    {
        /// <summary>
        /// Flyget som ändrade rutt.
        /// </summary>
        public string FlightCode { get; set; }
        /// <summary>
        /// Nya destinationen.
        /// </summary>
        public Destinations Destination { get; set; }
        /// <summary>
        /// Tiden som ChangeRouteEventArgs instansen skapades.
        /// </summary>
        public DateTime Time { get; set; }
    }
}
