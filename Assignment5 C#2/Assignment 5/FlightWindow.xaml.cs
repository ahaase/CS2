using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

/// <summary>
/// Haase
/// </summary>
namespace Assignment_5
{
    /// <summary>
    /// Interaction logic for PlaneWindow.xaml
    /// </summary>
    public partial class FlightWindow : Window
    {
        private Flight flight;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="f">Flyget som fönstret ska visa upp.</param>
        public FlightWindow(Flight f)
        {
            flight = f;
            InitializeComponent();
            InitializeGUI();
        }

        private void InitializeGUI()
        {
            Title = flight.FlightCode;
            changeRouteComboBox.ItemsSource = Enum.GetValues(typeof(Destinations));
            RefreshGUI(flight.Status);
            flight.TakeOff += flight_StatusChanged;
            flight.ChangeRoute += flight_StatusChanged;
            flight.Landing += flight_StatusChanged;
        }

        /// <summary>
        /// Uppdaterar fönstret så att den visar en lämplig bild och så rätt knappar är aktiva.
        /// </summary>
        /// <param name="status">Flygets status.</param>
        private void RefreshGUI(StatusType status)
        {
            switch (status)
            {
                case StatusType.SentToRunway:
                    startButton.IsEnabled = true;
                    changeRouteComboBox.IsEnabled = false;
                    landButton.IsEnabled = false;
                    image.Source = new BitmapImage(new Uri("Images/senttorunway.png", UriKind.Relative));
                    break;
                case StatusType.Started:
                    startButton.IsEnabled = false;
                    changeRouteComboBox.IsEnabled = true;
                    landButton.IsEnabled = false;
                    image.Source = new BitmapImage(new Uri("Images/started.png", UriKind.Relative));
                    break;
                case StatusType.NowHeading:
                    startButton.IsEnabled = false;
                    changeRouteComboBox.IsEnabled = true;
                    landButton.IsEnabled = true;
                    image.Source = new BitmapImage(new Uri("Images/flying.jpg", UriKind.Relative));
                    break;
                case StatusType.Landing:
                    startButton.IsEnabled = false;
                    changeRouteComboBox.IsEnabled = false;
                    landButton.IsEnabled = false;
                    image.Source = new BitmapImage(new Uri("Images/landing.jpg", UriKind.Relative));
                    break;
                default:
                    break;
            }
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            flight.OnTakeOff();
            RefreshGUI(flight.Status);
        }

        private void changeRouteComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            flight.OnChangeRoute((Destinations)changeRouteComboBox.SelectedItem);
            RefreshGUI(flight.Status);
        }

        private void landButton_Click(object sender, RoutedEventArgs e)
        {
            flight.OnLanding();
            RefreshGUI(flight.Status);
        }
        
        /// <summary>
        /// Detta finns främst för att användaren kan öppna flera fönster för 
        /// varje Flight. Jag vill på ett objektorienterat sätt, utan någon collection
        /// informera varje instans av den Flights fönster att status är ändrat.
        /// Alltså att användaren har tryckt på en knapp.
        /// </summary>
        private void flight_StatusChanged(object sender, EventArgs e)
        {
            RefreshGUI(flight.Status);
        }
    }
}
