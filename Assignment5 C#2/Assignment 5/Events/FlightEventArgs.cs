using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Haase
/// </summary>
namespace Assignment_5
{
    /// <summary>
    /// För att särskilja mellan när flyget startar och slutar.
    /// </summary>
    public enum FlightAction
    {
        TakeOff,
        Land,
        ChangeRoute
    }

    /// <summary>
    /// Klass som hanterar argument för när ett flyg startar och slutar.
    /// </summary>
    public class FlightEventArgs : EventArgs
    {
        /// <summary>
        /// Flygets identifierande kod.
        /// </summary>
        public string FlightCode { get; set; }
        /// <summary>
        /// Tiden som FlightEventArgs instansen skapades.
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// Vad flyget gjorde.
        /// </summary>
        public FlightAction Action { get; set; }
        /// <summary>
        /// Nya destinationen.
        /// </summary>
        public Destinations Destination { get; set; }
    }
}
