using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

/// <summary>
/// Haase
/// </summary>
namespace Assignment6
{
    /// <summary>
    /// Klass som hanterar laddning av en textfil.
    /// </summary>
    class InvoiceLoader
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        public InvoiceLoader()
        {

        }

        /// <summary>
        /// Laddar en vald textfil och returnerar en passande Invoice.
        /// </summary>
        /// <param name="file">Vald textfil.</param>
        /// <returns>En passande invoice.</returns>
        public Invoice Load(string file)
        {
            
            if(!File.Exists(file))
            {
                throw new Exception("File not found.");
            }
            FileStream fs = new FileStream(file, FileMode.Open);
            StreamReader reader = new StreamReader(fs);
            Invoice invoice = new Invoice();
            try
            {
                invoice.InvoiceNumber = int.Parse(reader.ReadLine());
                invoice.InvoiceDate = DateTime.Parse(reader.ReadLine());
                invoice.DueDate = DateTime.Parse(reader.ReadLine());
                invoice.ReceiverCompany = reader.ReadLine();
                invoice.ReceiverPerson = reader.ReadLine();
                invoice.ReceiverStreet = reader.ReadLine();
                invoice.ReceiverZipCode = reader.ReadLine();
                invoice.ReceiverCity = reader.ReadLine();
                invoice.ReceiverCountry = reader.ReadLine();

                int iterations = int.Parse(reader.ReadLine());
                for(int i = 0; i < iterations; i++)
                {
                    Item item = new Item();
                    item.Description = reader.ReadLine();
                    item.Quantity = int.Parse(reader.ReadLine());
                    item.UnitPrice = double.Parse(reader.ReadLine().Replace('.', ','));
                    item.TaxPercentage = int.Parse(reader.ReadLine());
                    item.SetTotals();
                    invoice.ItemList.Add(item);
                }
                invoice.SenderCompany = reader.ReadLine();
                invoice.SenderStreet = reader.ReadLine();
                invoice.SenderZipCode = reader.ReadLine();
                invoice.SenderCity = reader.ReadLine();
                invoice.SenderCountry = reader.ReadLine();
                invoice.SenderPhoneNumber = reader.ReadLine();
                invoice.SenderURL = reader.ReadLine();
            }
            catch(Exception e)
            {
                // Fångar och kastar Exception direkt igen så att MainWindow kan göra
                // en MessageBox med informationen om vad som gick fel.
                throw e;
            }
            finally
            {
                reader.Close();
            }
            return invoice;
        }
    }
}
