using BusinessManager.Views;
using BusinessManager.Models;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.Collections.ObjectModel;

namespace BusinessManager
{
    public partial class MainPage : ContentPage
    {
        Connect database = new Connect();
        Functions functions = new Functions();
        
        List<Invoice> Invoices = new();
        List<Invoice_Line> Lines = new();

        public MainPage()
        {
            InitializeComponent();

            //PrintLists();
        }

        void OnRefreshTotal(object sender, EventArgs e)
        {
            
        }

        private void PrintLists()
        { 
            Invoices = database.ReturnInvoices();
            Lines = database.ReturnInvoiceLines();

            StringBuilder sb = new StringBuilder();
            sb.Append("Invoices: ");
            foreach (Invoice invoice in Invoices)
                sb.Append($"{invoice.Invoice_id}\n");

            sb.Append("\nInvoice Lines: \n");
            foreach (Invoice_Line line in Lines)
                sb.Append($"{line.Invoice_id}: {line.Line_id} | {line.Stock_id}\n");

            label.Text = sb.ToString();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            

            
        }

        
    }

}
