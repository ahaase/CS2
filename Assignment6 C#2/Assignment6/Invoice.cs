using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

/// <summary>
/// Haase
/// </summary>
namespace Assignment6
{
    /// <summary>
    /// Klass som håller information av en Invoice.
    /// </summary>
    public class Invoice
    {
        /// <summary>
        /// Innehållande data:
        /// </summary>
        
        private int invoiceNumber;

        private DateTime invoiceDate;
        private DateTime dueDate;

        private string recieverCompany;
        private string recieverPerson;
        private string recieverStreet;
        private string recieverZipCode;
        private string recieverCity;
        private string recieverCountry;

        private string senderCompany;
        private string senderStreet;
        private string senderZipCode;
        private string senderCity;
        private string senderCountry;
        private string senderPhoneNumber;
        private string senderURL;

        private string numberOfItems;

        private ObservableCollection<Item> itemList;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public Invoice()
        {
            itemList = new ObservableCollection<Item>();
        }

        /// <summary>
        /// ObservableCollection som används av en ListView som läser av.
        /// </summary>
        public ObservableCollection<Item> ItemList { get => itemList; }

        /// <summary>
        /// Hämtar och ställer in InvoiceDate.
        /// </summary>
        public DateTime InvoiceDate { get => invoiceDate; set => invoiceDate = value; }

        /// <summary>
        /// Hämtar och ställer in DueDate.
        /// </summary>
        public DateTime DueDate { get => dueDate; set => dueDate = value; }

        /// <summary>
        /// Hämtar och ställer in InvoiceNumber.
        /// </summary>
        public int InvoiceNumber { get => invoiceNumber; set => invoiceNumber = value; }

        /// <summary>
        /// Hämtar och ställer in antalet Items i Invoice.
        /// </summary>
        public string NumberOfItems { get => numberOfItems; set => numberOfItems = value; }

        /// <summary>
        /// Hämtar och ställer in motagarens företag.
        /// </summary>
        public string ReceiverCompany { get => recieverCompany; set => recieverCompany = value; }

        /// <summary>
        /// Hämtar och ställer in motagarens representant.
        /// </summary>
        public string ReceiverPerson { get => recieverPerson; set => recieverPerson = value; }

        /// <summary>
        /// Hämtar och ställer in motagarens gata.
        /// </summary>
        public string ReceiverStreet { get => recieverStreet; set => recieverStreet = value; }

        /// <summary>
        /// Hämtar och ställer in motagarens zipkod.
        /// </summary>
        public string ReceiverZipCode { get => recieverZipCode; set => recieverZipCode = value; }

        /// <summary>
        /// Hämtar och ställer in motagarens stad.
        /// </summary>
        public string ReceiverCity { get => recieverCity; set => recieverCity = value; }
        /// <summary>
        /// Hämtar och ställer in motagarens land.
        /// </summary>
        public string ReceiverCountry { get => recieverCountry; set => recieverCountry = value; }

        /// <summary>
        /// Hämtar och ställer in utskickarens företag.
        /// </summary>
        public string SenderCompany { get => senderCompany; set => senderCompany = value; }

        /// <summary>
        /// Hämtar och ställer in utskickarens gata.
        /// </summary>
        public string SenderStreet { get => senderStreet; set => senderStreet = value; }

        /// <summary>
        /// Hämtar och ställer in utskickarens zipkod.
        /// </summary>
        public string SenderZipCode { get => senderZipCode; set => senderZipCode = value; }

        /// <summary>
        /// Hämtar och ställer in utskickarens stad.
        /// </summary>
        public string SenderCity { get => senderCity; set => senderCity = value; }

        /// <summary>
        /// Hämtar och ställer in utskickarens land.
        /// </summary>
        public string SenderCountry { get => senderCountry; set => senderCountry = value; }

        /// <summary>
        /// Hämtar och ställer in utskickarens telefonnummer.
        /// </summary>
        public string SenderPhoneNumber { get => senderPhoneNumber; set => senderPhoneNumber = value; }

        /// <summary>
        /// Hämtar och ställer in utskickarens hemsida.
        /// </summary>
        public string SenderURL { get => senderURL; set => senderURL = value; }
    }
}
