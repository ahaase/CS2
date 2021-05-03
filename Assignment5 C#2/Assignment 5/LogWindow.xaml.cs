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
    /// Interaction logic for LogWindow.xaml
    /// </summary>
    public partial class LogWindow : Window
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="log">Loggen som fönstret ska visa upp.</param>
        public LogWindow(Log log)
        {
            InitializeComponent();
            updateListBox(log.GetList());
            log.NotifyLogWindow += logList_Updated;
        }

        /// <summary>
        /// Uppdaterar ListBoxen med den nya Listan.
        /// </summary>
        /// <param name="list">Listan som ListBoxen ska innehålla.</param>
        private void updateListBox(List<string> list)
        {
            listBox.Items.Clear();
            foreach(string s in list)
            {
                listBox.Items.Add(s);
            }
        }

        /// <summary>
        /// När det skrivs till Loggen så kallas den här metoden i varje instans
        /// av LogWindow.
        /// </summary>
        /// <param name="sender">Log objektet.</param>
        /// <param name="e">Behövs inga argument.</param>
        private void logList_Updated(object sender, EventArgs e)
        {
            updateListBox(((Log)sender).GetList());
        }
    }
}
