using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Haase
/// </summary>
namespace Assignment_5
{
    /// <summary>
    /// Hanterar en lista med information om flygens äventyr.
    /// </summary>
    public class Log
    {
        private List<string> list;
        public EventHandler NotifyLogWindow;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="ctw">Den som vill skriva till loggen.</param>
        public Log(ControlTowerWindow ctw)
        {
            ctw.LoggingHandler += write;
            list = new List<string>();
            list.Add($"{DateTime.Now:HH:mm:ss}" + " - Logging started.");
        }
        
        /// <summary>
        /// Skriver en rad i Loggen och lägger till den som ett element i Listan.
        /// </summary>
        /// <param name="o">Objektet som skickar.</param>
        /// <param name="e">Flygargument.</param>
        private void write(object o, FlightEventArgs e)
        {
            switch(e.Action)
            {
                case FlightAction.TakeOff:
                    list.Add($"{e.Time:HH:mm:ss}" + " - Flight " + e.FlightCode + " took off.");
                    break;
                case FlightAction.Land:
                    list.Add($"{e.Time:HH:mm:ss}" + " - Flight " + e.FlightCode + " landed.");
                    break;
                case FlightAction.ChangeRoute:
                    list.Add($"{e.Time:HH:mm:ss}" + " - Flight " + e.FlightCode + " is now heading " + e.Destination);
                    break;

            }
            NotifyLogWindow?.Invoke(this, null);
        }

        /// <summary>
        /// Hämtar Listan.
        /// </summary>
        /// <returns>Loggen.</returns>
        public List<string> GetList()
        {
            return list;
        }
    }
}
