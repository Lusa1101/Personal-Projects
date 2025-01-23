using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessManager.Models;
using Microsoft.Maui.Controls.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.ComponentModel;
using BusinessManager.ViewModels;
using System.Collections.ObjectModel;

//Hi from Feat/adding-mvvm

namespace BusinessManager.Popups
{
    partial class InvoiceSummaryPage : Popup
    {
        Connect database = new();
        Functions functions = new();

        private InvoiceSummaryViewModel viewModel;

        List<Invoice> Invoices = new();
        List<Invoice_Line> Lines = new();
        List<DisplayProduct> Products = new();

        public InvoiceSummaryPage(List<DisplayProduct> products, decimal invoiceTotal)
        {
            InitializeComponent();

            Invoices = database.ReturnInvoices();
            Lines = database.ReturnInvoiceLines();
            Products = products;

            //Update popup information 
            collection.ItemsSource = products;
            total.Text = invoiceTotal.ToString("#.00");            
        }

        void OnSubmitInvoice(object sender, EventArgs e)
        {
            GenerateInvoice();

            //Disable button
            submitButton.IsEnabled = false;
        }

        void OnCloseInvoiceSummary(object sender, EventArgs e)
        {
            Close();
        }

        void GenerateLines(int invoice_id)
        {
            int line_id = 1;
            StringBuilder sb = new StringBuilder();

            if(!Lines.IsNullOrEmpty()) 
                line_id = functions.GetLastId(Lines) + 1;

            foreach(DisplayProduct product in Products)
            {
                Invoice_Line line = new();
                line.Line_id = line_id;
                line.Stock_id = product.Stock_id;
                line.Invoice_id = invoice_id;
                line.Quantity = 2;

                //Lines.Add(line);
                string result = database.InsertInvoiceLine(line);
                sb.Append($"{line.Line_id} : {result}\n");
                line_id++;
            }

            //Check the lines
            Debug.WriteLine( sb.ToString() );

            Close();
        }

        void GenerateInvoice()
        {            
            ///Create the invoice_id
            Invoice invoice = new();
            int invoice_id = 2;
            if (!Invoices.IsNullOrEmpty())
                invoice_id = functions.GetLastId(Invoices) + 1;
            invoice.Invoice_id = invoice_id;
            string invoiceResult = database.InsertInvoice(invoice);

            //Add products from the invoice line
            if (invoiceResult == "1")
            {
                Debug.WriteLine(invoice.Invoice_id);
                GenerateLines(invoice_id);
            }
            else
                Debug.WriteLine($"Failed to insert invoice.\n {invoiceResult}");
        }
    }
}
