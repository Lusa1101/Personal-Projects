using BusinessManager.Models;
using System;
using System.Collections.Generic;
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

        public async void DisplayMessage(string header, string msg)
        {
            //await DisplayAlert($"{header}", $"{msg}", "Okay");
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
            return Convert.ToInt32(value);
        }

        public bool BoolConverter(string value)
        {
            return Convert.ToBoolean(value);
        }

        public int ReturnIndex(string code)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < code.Length; i++)
            {
                if (Char.IsDigit(code[i]))
                    for (int j = i; j < code.Length; j++)
                        stringBuilder.Append(code[j]);

                break;
            }

            return IntegerConverter(stringBuilder.ToString());
        }

    }
}
