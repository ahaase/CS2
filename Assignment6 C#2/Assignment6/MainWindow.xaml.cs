using Microsoft.Win32;
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

namespace Assignment6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Invoice selectedInvoice;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            invoiceContainer.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Uppdaterar GUI så att den passar en vald Invoice.
        /// </summary>
        /// <param name="invoice">Den valda invoice.</param>
        private void SetGuiToInvoice(Invoice invoice)
        {
            listView.ItemsSource = invoice.ItemList;
            invoiceNumberLabelResult.Content = invoice.InvoiceNumber;
            invoiceDateDatePicker.SelectedDate = invoice.InvoiceDate;
            dueDateDatePicker.SelectedDate = invoice.DueDate;

            receiverCompanyNameLabel.Content = invoice.ReceiverCompany;
            receiverPersonNameLabel.Content = invoice.ReceiverPerson;
            receiverStreetLabel.Content = invoice.ReceiverStreet;
            receiverZipCodeLabel.Content = invoice.ReceiverZipCode;
            receiverCityLabel.Content = invoice.ReceiverCity;
            receiverCountryLabel.Content = invoice.ReceiverCountry;

            senderCompanyNameLabel.Content = invoice.SenderCompany;
            senderStreetLabel.Content = invoice.SenderStreet;
            senderZipCodeLabel.Content = invoice.SenderZipCode;
            senderCityLabel.Content = invoice.SenderCity;
            senderCountryLabel.Content = invoice.SenderCountry;

            senderPhoneNumberLabel.Content = invoice.SenderPhoneNumber;
            senderURLLabel.Content = invoice.SenderURL;

            updateTotalCostTextBox();
            invoiceContainer.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Räknar ihop och uppdaterar det totala priset.
        /// </summary>
        private void updateTotalCostTextBox()
        {
            double cost = 0;
            foreach (Item item in selectedInvoice.ItemList)
            {
                cost += item.TotalPrice;
            }
            double discount;
            if (double.TryParse(discountTextBox.Text, out discount))
            {
                cost -= discount;
            }
            else
            {
                discountTextBox.Text = "";
            }
            totalPriceTextBox.Text = (Math.Truncate(cost * 100) / 100).ToString();
        }

        private void openCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";
            openFileDialog.DefaultExt = ".txt";
            openFileDialog.ShowDialog();
            if(openFileDialog.FileName != null && openFileDialog.FileName != string.Empty)
            {
                try
                {
                    selectedInvoice = new InvoiceLoader().Load(openFileDialog.FileName);
                    SetGuiToInvoice(selectedInvoice);
                }
                catch(Exception exception)
                {
                    MessageBox.Show("Could not load file.\n" + exception.Message, "Error");
                }
            }
        }

        private void closeCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure?", "Exit program", MessageBoxButton.YesNo);
            if(result == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        private void discountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            updateTotalCostTextBox();
        }
    }
}
