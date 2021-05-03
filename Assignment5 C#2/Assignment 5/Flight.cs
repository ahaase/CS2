using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

/// <summary>
/// Haase
/// </summary>
namespace Assignment_5
{
    /// <summary>
    /// Vad flyget har för status.
    /// </summary>
    public enum StatusType
    {
        SentToRunway,
        Started,
        NowHeading,
        Landing
    }

    /// <summary>
    /// Olika fina destinationer.
    /// </summary>
    public enum Destinations
    {
        North,
        West,
        East,
        South
    }

    /// <summary>
    /// Klass som beskriver ett flygplans färd.
    /// </summary>
    public class Flight : INotifyPropertyChanged
    {
        private string flightCode;
        private string statusString;

        private StatusType status;
        private Destinations destination;

        private DateTime startTime;

        /// <summary>
        /// Olika Events:
        /// </summary>
        public event EventHandler<FlightEventArgs> TakeOff;
        public event EventHandler<FlightEventArgs> ChangeRoute;
        public event EventHandler<FlightEventArgs> Landing;

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// När Status ändras så kallas det här så att ListView automatiskt uppdaterar.
        /// </summary>
        private void NotifyPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        /// <summary>
        /// Flygets identifierande kod.
        /// </summary>
        public string FlightCode
        {
            get
            {
                return flightCode;
            }
        }

        /// <summary>
        /// Hämtar eller ställer in en string som beskriver Flight-objektets status.
        /// </summary>
        public string StatusString
        {
            get
            {
                return statusString;
            }
            private set
            {
                if(value != statusString)
                {
                    statusString = value;
                    NotifyPropertyChanged(); // För att ListViewn ska uppdateras.
                }
            }
        }

        public StatusType Status
        {
            get
            {
                return status;
            }
            private set
            {

                /*
                 * I denna switchen omvandlas status till en lämplig string.
                 * 
                 */
                switch (value)
                {
                    case StatusType.SentToRunway:
                        StatusString = "Sent to runway";
                        break;
                    case StatusType.Started:
                        StatusString = "Started";
                        break;
                    case StatusType.NowHeading:
                        StatusString = "Now heading towards " + destination.ToString();
                        break;
                    case StatusType.Landing:
                        StatusString = "Landing";
                        break;
                    default:
                        StatusString = "Confused";
                        break;
                }
                status = value;
            }
        }

        /// <summary>
        /// Hämtar start-tiden. Hämtas endast av ListViewen.
        /// </summary>
        public string Time
        {
            get
            {
                return $"{startTime:HH:mm:ss}";
            }
        }

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="flightCode">En sträng som identifierar flyget.</param>
        public Flight(string flightCode)
        {
            this.flightCode = flightCode;
            startTime = DateTime.Now;
            Status = StatusType.SentToRunway;
            statusString = "Sent to runway";
        }

        /// <summary>
        /// Kallas när användaren trycker på Start-knappen.
        /// </summary>
        public void OnTakeOff()
        {
            if(status == StatusType.SentToRunway)
            {
                Status = StatusType.Started;
                FlightEventArgs args = new FlightEventArgs
                {
                    FlightCode = flightCode,
                    Destination = destination,
                    Time = DateTime.Now,
                    Action = FlightAction.TakeOff
                };
                TakeOff(this, args);
            }
        }

        /// <summary>
        /// Kallas när användaren ändrar val i ComboBoxen.
        /// </summary>
        /// <param name="destination">Nya destinationen.</param>
        public void OnChangeRoute(Destinations destination)
        {
            if(status == StatusType.Started)
            {
                Status = StatusType.NowHeading;
            }
            if(status == StatusType.NowHeading)
            {
                this.destination = destination;
                Status = status; // För att göra så att ListView informeras.
                FlightEventArgs args = new FlightEventArgs
                {
                    FlightCode = flightCode,
                    Destination = destination,
                    Time = DateTime.Now,
                    Action = FlightAction.ChangeRoute
                };
                ChangeRoute(this, args);
            }
        }

        /// <summary>
        /// Kallas när användaren trycker på Land-knappen.
        /// </summary>
        public void OnLanding()
        {
            if(status == StatusType.NowHeading)
            {
                Status = StatusType.Landing;
                FlightEventArgs args = new FlightEventArgs
                {
                    FlightCode = flightCode,
                    Destination = destination,
                    Time = DateTime.Now,
                    Action = FlightAction.Land
                };
                Landing(this, args);
            }
        }
    }
}
