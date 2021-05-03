using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

/// <summary>
/// Haase
/// </summary>
namespace Assignment_5
{
    /// <summary>
    /// Denna delegate hanterar även EventHandlers i andra klasser.
    /// </summary>
    /// <typeparam name="TEventArgs">Vad för typ.</typeparam>
    /// <param name="sender">Objektet som skickar.</param>
    /// <param name="e">Argument.</param>
    public delegate void EventHandler<TEventArgs>(object sender, TEventArgs e);

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ControlTowerWindow : Window
    {
        public EventHandler<FlightEventArgs> LoggingHandler;
        private Log log;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public ControlTowerWindow()
        {
            InitializeComponent();
            log = new Log(this);
        }

        private void sendNextAirplaneButton_Click(object sender, RoutedEventArgs e)
        {
            if(nextFlightTextBox.Text != string.Empty)
            {
                FlightWindow fw = new FlightWindow(newFlight(nextFlightTextBox.Text));
                nextFlightTextBox.Text = string.Empty;
                fw.Show();
            }
            else
            {
                MessageBox.Show("Flight code can't be empty!", "Could not create flight");
            }
        }

        private void listView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(listView.SelectedIndex >= 0)
            {
                Flight f = (Flight)listView.SelectedItem;
                FlightWindow fw = new FlightWindow(f);
                fw.Show();
            }
        }

        /// <summary>
        /// Startar ett nytt flyg och försöker lägger till den i ListView.
        /// </summary>
        /// <param name="flightCode">String med Flight-koden.</param>
        private Flight newFlight(string flightCode)
        {
            Flight f = new Flight(flightCode);
            f.TakeOff += flight_TakeOff;
            f.ChangeRoute += flight_ChangeRoute;
            f.Landing += flight_Landing;
            listView.Items.Add(f);
            return f;
        }

        private void flight_TakeOff(object o, FlightEventArgs e)
        {
            LoggingHandler(this, e);
        }

        private void flight_ChangeRoute(object o, FlightEventArgs e)
        {
            LoggingHandler(this, e);
        }

        private void flight_Landing(object o, FlightEventArgs e)
        {
            LoggingHandler(this, e);
        }
        
        private void viewLogButton_Click(object sender, RoutedEventArgs e)
        {
            LogWindow lw = new LogWindow(log);
            lw.Show();
        }
    }
}
