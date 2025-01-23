using BusinessManager.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager
{
    public class Functions
    {
        Data data = new Data();

        public List<String> ReturnNameArray(List<Product_Category> productCategories)
        {
            List<String> strings = new List<String>();

            foreach (Product_Category productCategory in productCategories)
            {
                if (productCategory.Name != null)
                    strings.Add(productCategory.Name);
            }

            return strings;
        }
        public List<String> ReturnNameArray(List<Product_Subcategory> productSubcategories)
        {
            List<String> strings = new List<String>();

            foreach (Product_Subcategory productSubcategory in productSubcategories)
            {
                if (productSubcategory.Name != null)
                    strings.Add(productSubcategory.Name);
            }

            return strings;
        }

        public List<(string Name, decimal Price)> ReturnProduct(List<Product> products, List<Stock> stocks)
        {
            List<(string Name, decimal Price)> list = new ();

            foreach (Product product in products)
            {
                foreach (Stock stock in stocks)
                {
                    if (product.Product_id == stock.Product_id && product.Name is not null)
                        list.Add((product.Name, stock.Unit_price));
                }
            }

            return list; 
        }

        public List<(string Name, decimal Price)> ReturnProduct(List<Product> products, List<Stock> stocks, List<Packaging> packagings)
        {
            List<(string Name, decimal Price)> list = new();

            foreach (Product product in products)
            {
                foreach (Stock stock in stocks)
                {
                    foreach (Packaging packaging in packagings)
                    {
                        if (product.Product_id == stock.Product_id && packaging.Stock_id == stock.Stock_id && product.Name is not null)
                            list.Add((product.Name, stock.Unit_price));
                    }
                }
            }

            return list;
        }

        public string CodeGenerator(string type, int number)
        {
            StringBuilder code = new StringBuilder();

            switch(type.ToLower())
            {
                case "product":
                    code.Append("PR");
                    break;
                case "subcategory":
                    code.Append("SC");
                    break;
                case "category":
                    code.Append("C");
                    break;
                case "package":
                    code.Append("P");
                    break;
                case "packaging":
                    code.Append("PK");
                    break;
                default:
                    code.Append("NULL");
                    break;
            }

            if (code.ToString() == "NULL")
                return null;

            code.Append((number + 1).ToString());

            return code.ToString();
        }

        public int GetLastId(List<Product_Category> categories)
        {
            string code="";

            if (!categories.IsNullOrEmpty())
            {
                code = categories[0].Category_id;

                foreach (Product_Category category in categories)
                {
                    if (ReturnIndex(code) < ReturnIndex(category.Category_id)) 
                        code = category.Category_id;
                }
            }

            return ReturnIndex(code);
        }

        public int GetLastId(List<Product_Subcategory> subcategories)
        {
            string code = "";

            Debug.WriteLine(subcategories.Count);

            if (!subcategories.IsNullOrEmpty())
            {
                if (subcategories[0].Subcategory_id != null)
                    code = subcategories[0].Subcategory_id;

                foreach (Product_Subcategory subcategory in subcategories)
                {
                    if (ReturnIndex(code) < ReturnIndex(subcategory.Subcategory_id))
                        code = subcategory.Subcategory_id;
                }
            }

            return ReturnIndex(code);
        }

        public int GetLastId(List<Package> packages)
        {
            string code = "1";

            if (!packages.IsNullOrEmpty())
            {
                code = packages[0].Package_id;

                foreach (Package package in packages)
                {
                    if (ReturnIndex(code) < ReturnIndex(package.Package_id))
                        code = package.Package_id;
                }
            }

            return ReturnIndex(code);
        }

        public int GetLastId(List<Invoice> invoices)
        {
            int code = 1;

            if (!invoices.IsNullOrEmpty())
            {
                code = invoices[0].Invoice_id;

                foreach (Invoice invoice in invoices)
                {
                    if (code < invoice.Invoice_id)
                        code = invoice.Invoice_id;
                }
            }

            return code;
        }

        public int GetLastId(List<Invoice_Line> lines)
        {
            int code = 1;

            if (!lines.IsNullOrEmpty())
            {
                code = lines[0].Invoice_id;

                foreach (Invoice_Line line in lines)
                {
                    if (code < line.Line_id)
                        code = line.Line_id;
                }
            }

            return code;
        }

        public int GetLastId(List<Packaging> packagings)
        {
            string code = "";

            if (!packagings.IsNullOrEmpty())
            {
                code = packagings[0].Packaging_id;

                foreach (Packaging packaging in packagings)
                {
                    if (ReturnIndex(code) < ReturnIndex(packaging.Packaging_id))
                        code = packaging.Packaging_id;
                }
            }

            return ReturnIndex(code);
        }

        public int GetLastId(List<Essential> essentials)
        {
            int code = 1;

            if (!essentials.IsNullOrEmpty())
            {
                code = essentials[0].Essential_id;

                foreach (Essential essential in essentials)
                {
                    if (code < essential.Essential_id)
                        code = essential.Essential_id;
                }
            }

            return code;
        }

        public int GetLastId(List<Stock> stocks)
        {
            int code = 1;

            if (!stocks.IsNullOrEmpty())
            {
                code = stocks[0].Stock_id;

                foreach (Stock stock in stocks)
                {
                    if (code < stock.Stock_id)
                        code = stock.Stock_id;
                }
            }

            return code;
        }

        public decimal DecimalConverter(string temp)
        {
            if (temp.Contains(","))
                temp = temp.Replace(",", ".");

            var culture = CultureInfo.InvariantCulture;
            return decimal.Parse(temp, culture);
            // return Convert.ToDecimal(temp);
        }

        public int IntegerConverter(string value)
        {
            int number = -1;

            try
            {
                number = int.Parse(value);
            }
            catch (FormatException ex)
            {
                Debug.WriteLine("Failed to convert int: " + ex.Message);
            }

            return number;
        }

        public bool BoolConverter(string value)
        {
            bool result = false;

            try
            {
                result = bool.Parse(value);
            }
            catch (FormatException ex)
            {
                Debug.WriteLine("Failed to convert bool: " + ex.Message);
            }

            return result;
        }

        public int ReturnIndex(string code)
        {
            string stringBuilder = "";

            for (int i = 0; i < code.Length; i++)
            {
                if (char.IsDigit(code[i]))
                {
                    for (int j = i; j < code.Length; j++)
                    {
                        stringBuilder += code[j];
                    }

                    break;
                }
            }

            return IntegerConverter(stringBuilder.ToString());
        }

        public bool CheckEntry(Entry entry)
        {
            if (entry.Text != null && entry.Text.Length > 1)
                return true;

            return false;
        }

        public void EntryToNull(Entry entry)
        {
            entry.Text = null;
        }

        public bool CheckEntryLength(Editor entry, int max)
        {
            if (entry.Text != null && entry.Text.Length < max)
                return true;
            else if (entry.Text == null)
                return true;
            return false;
        }
        public bool CheckEntryLength(Entry entry, int max)
        {
            if (entry.Text != null && entry.Text.Length < max)
                return true;
            else if (entry.Text == null)
                return true;
            return false;
        }
    }
}
