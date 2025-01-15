using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessManager.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;

namespace BusinessManager
{
    class Connect
    {
        public Connect() { }

        private string connectionString = "Server=LAPTOP-HHQOVSI1\\SQLEXPRESS;Database=BusinessManager;User ID=Tom;Password=tomtom; TrustServerCertificate=True";

        SqlConnection connection;

        Functions functions = new Functions();

        public void ReturnConnection(SqlConnection conn)
        {
            try
            {
                conn = new SqlConnection(this.connectionString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
            }
        }

        string Insert(string query)
        {
            StringBuilder result = new StringBuilder();
            try
            {
                connection = new SqlConnection(this.connectionString);
            }
            catch (Exception ex)
            {
                return $"{ex.Message}";
            }
            using (connection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Connection.Open();
                    int res = cmd.ExecuteNonQuery();
                    result.Append(res);
                }
                catch (Exception ex)
                {
                    result.Append(ex.Message);
                }
            }

            return result.ToString();
        }



        public string InsertProduct(Product product)
        {
            string query = $"INSERT INTO Product(Product_id, Name, Description, Subcategory_Id) VALUES ('{product.Product_id}', '{product.Name}', '{product.Description}', '{product.Subcategory_id}')";
            return Insert(query);
        }

        public string InsertCategory(Product_Category category)
        {
            string query = $"INSERT INTO Product_CATEGORY (Category_id, Name) VALUES ('{category.Category_id}', '{category.Name}');";
            return Insert(query);
        }

        public string InsertSubcategory(Product_Subcategory subcategory)
        {
            string query = $"INSERT INTO Product_SUBCATEGORY (Subcategory_id, Category_id, Name) VALUES ('{subcategory.Subcategory_id}', '{subcategory.Category_id}', '{subcategory.Name}');";
            return Insert(query);
        }

        public string InsertStock(Stock stock)
        {
            string query = $"INSERT INTO Stock (Stock_id, Product_id, Cost_per_unit, Total_units, Unit_price, Needs_Packaging, Is_available) VALUES ('{stock.Stock_id}', '{stock.Product_id}', {stock.Cost_per_unit}, {stock.Total_units}, {stock.Unit_price}, {stock.Needs_Packaging}, {stock.Is_available})";
            return Insert(query);
        }

        public string InsertEssential(Essential essential)
        {
            string query = $"INSERT INTO Essential (essential_id, name) VALUES ({essential.Essential_id}, '{essential.Name}')";
            return Insert(query);
        }

        public string InsertExpense(Expense expense)
        {
            string query = $"INSERT INTO EXPENSE (expense_id, type, name, amount) VALUES ({expense.Expence_id}, '{expense.Type}', '{expense.Name}', {expense.Amount})";
            return Insert(query);
        }

        public string InsertInvoice(Invoice invoice)
        {
            string query = $"INSERT INTO INVOICE (invoice_id, customer_id) VALUES ({invoice.Invoice_id}, {invoice.Customer_id})";
            return Insert(query);
        }

        public string InsertInvoiceLine(Invoice_Line line)
        {
            string query = $"INSERT INTO INVOICE_LINE (line_id, invoice_id, quantity, discount) VALUES ({line.Line_id}, {line.Invoice_id}, {line.Quantity}, {line.Discount})";
            return Insert(query);
        }

        public string InsertPackage(Package package)
        {
            string query = $"INSERT INTO Package (package_id, name, size, cost, quantity) VALUES ('{package.Package_id}', '{package.Name}','{package.Size}', '{package.Cost}', {package.Quantity})";
            return Insert(query);
        }

        public string InsertPackaging(Packaging packaging)
        {
            string query = $"INSERT INTO Packaging (packaging_id, package_id, stock_id, quantity, unit_price) VALUES ('{packaging.Packaging_id}', '{packaging.Package_id}', {packaging.Stock_id}, {packaging.Quantity}, {packaging.Unit_price})";
            return Insert(query);
        }

        public string InsertProductImage(Product_Image product_Image)
        {
            string query = $"INSERT INTO Product_image (product_id, image) VALUES ('{product_Image.Product_id}', {product_Image.Image})";
            return Insert(query);
        }

        public string InsertStockReceipt(Stock_Receipt stock_Receipt)
        {
            string query = $"INSERT INTO Stock_Receipt (Stock_id, image) VALUES ({stock_Receipt.Stock_id}, {stock_Receipt.Image})";
            return Insert(query);
        }

        public List<Product_Subcategory> ReturnSubcategories ()
        {
            try
            {
                connection = new SqlConnection(this.connectionString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                return new List<Product_Subcategory>();
            }
            using (connection)
            {
                try
                {
                    string query = "Select subcategory_id, category_id, name from Product_Subcategory Order By subcategory_id";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Product_Subcategory> list = new List<Product_Subcategory>();
                        while (reader.Read())
                        {
                            Product_Subcategory subcategory = new Product_Subcategory();
                            subcategory.Subcategory_id = String.Format("{0}", reader[0]);
                            subcategory.Category_id = String.Format ("{0}", reader[1]);
                            subcategory.Name = String.Format ("{0}", reader[2]);

                            list.Add(subcategory);
                        }

                        return list;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return new List<Product_Subcategory>();
                }
            }
        }

        public List<Product_Category> ReturnCategories()
        {
            try
            {
                connection = new SqlConnection(this.connectionString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                return new List<Product_Category>();
            }
            using (connection)
            {
                try
                {
                    string query = "Select category_id, name from Product_Category Order By category_id";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Product_Category> list = new List<Product_Category>();
                        while (reader.Read())
                        {
                            Product_Category category = new Product_Category();
                            category.Category_id = String.Format("{0}", reader[0]);
                            category.Name = String.Format("{0}", reader[1]);

                            list.Add(category);
                        }

                        foreach(Product_Category category1 in list)
                            Debug.WriteLine(category1.Category_id + ": " + category1.Name);

                        return list;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return new List<Product_Category>();
                }
            }
        }

        public List<Product> ReturnProducts()
        {
            try
            {
                connection = new SqlConnection(this.connectionString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                return new List<Product>();
            }
            using (connection)
            {
                try
                {
                    string query = "Select product_id, name, description, subcategory_id  from Product Order By product_id";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Product> list = new List<Product>();
                        while (reader.Read())
                        {
                            Product product = new Product();
                            product.Product_id = String.Format("{0}", reader[0]);
                            product.Name = String.Format("{0}", reader[1]);
                            product.Description = String.Format("{0}", reader[2]);
                            product.Subcategory_id = String.Format("{0}", reader[3]);

                            list.Add(product);
                        }

                        return list;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return new List<Product>();
                }
            }
        }

        public List<Stock> ReturnStocks()
        {
            try
            {
                connection = new SqlConnection(this.connectionString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                return new List<Stock>();
            }
            using (connection)
            {
                try
                {
                    string query = "Select stock_id, product_id, cost_per_unit, total_units, unit_price, needs_packaging, is_available from stock order by stock_id";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Stock> list = new List<Stock>();
                        while (reader.Read())
                        {
                            Stock stock = new Stock();
                            stock.Stock_id = functions.IntegerConverter(String.Format("{0}", reader[0]));
                            stock.Product_id = String.Format("{0}", reader[1]);
                            stock.Cost_per_unit = functions.DecimalConverter(String.Format("{0}", reader[2]));
                            stock.Total_units = functions.IntegerConverter(String.Format("{0}", reader[3]));
                            stock.Unit_price = functions.DecimalConverter(String.Format("{0}", reader[4]));
                            stock.Needs_Packaging = functions.BoolConverter(String.Format("{0}", reader[5]));
                            stock.Is_available = functions.BoolConverter(String.Format("{0}", reader[6]));

                            list.Add(stock);
                        }

                        return list;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return new List<Stock>();
                }
            }
        }

        public List<Invoice> ReturnInvoices()
        {
            try
            {
                connection = new SqlConnection(this.connectionString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                return new List<Invoice>();
            }
            using (connection)
            {
                try
                {
                    string query = "Select invoice_id, customer_id from Invoice Order By Invoice_id";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Invoice> list = new List<Invoice>();
                        while (reader.Read())
                        {
                            Invoice invoice = new Invoice();
                            invoice.Invoice_id = functions.IntegerConverter(String.Format("{0}", reader[0]));
                            invoice.Customer_id = functions.IntegerConverter(String.Format("{0}", reader[1]));

                            list.Add(invoice);
                        }

                        return list;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return new List<Invoice>();
                }
            }
        }

        public List<Invoice_Line> ReturnInvoiceLines()
        {
            try
            {
                connection = new SqlConnection(this.connectionString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                return new List<Invoice_Line>();
            }
            using (connection)
            {
                try
                {
                    string query = "Select line_id, invoice_id, stock_id, quantity, discount from Invoice_Line Order By Line_id";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Invoice_Line> list = new List<Invoice_Line>();
                        while (reader.Read())
                        {
                            Invoice_Line line = new Invoice_Line();
                            line.Line_id = functions.IntegerConverter(String.Format("{0}", reader[0]));
                            line.Invoice_id = functions.IntegerConverter(String.Format("{0}", reader[1]));
                            line.Stock_id = functions.IntegerConverter(String.Format("{0}", reader[2]));
                            line.Quantity = functions.IntegerConverter(String.Format("{0}", reader[3]));
                            line.Discount = functions.DecimalConverter(String.Format("{0}", reader[4]));

                            list.Add(line);
                        }

                        return list;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return new List<Invoice_Line>();
                }
            }
        }

        public List<Essential> ReturnEssentials()
        {
            try
            {
                connection = new SqlConnection(this.connectionString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                return new List<Essential>();
            }
            using (connection)
            {
                try
                {
                    string query = "Select essential_id, name  from Essential Order By essential_id";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Essential> list = new List<Essential>();
                        while (reader.Read())
                        {
                            Essential essential = new Essential();
                            essential.Essential_id = functions.IntegerConverter(String.Format("{0}", reader[0]));
                            essential.Name = String.Format("{0}", reader[1]);

                            list.Add(essential);
                        }

                        return list;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return new List<Essential>();
                }
            }
        }

        public List<Expense> ReturnExpenses()
        {
            try
            {
                connection = new SqlConnection(this.connectionString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                return new List<Expense>();
            }
            using (connection)
            {
                try
                {
                    string query = "Select expense_id, name, type, amount from Expense Order By expense_id";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Expense> list = new List<Expense>();
                        while (reader.Read())
                        {
                            Expense expense = new Expense();
                            expense.Expence_id = functions.IntegerConverter(String.Format("{0}", reader[0]));
                            expense.Name = String.Format("{0}", reader[1]);
                            expense.Type = String.Format("{0}", reader[2]);
                            expense.Amount = functions.DecimalConverter(String.Format("{0}", reader[3]));

                            list.Add(expense);
                        }

                        return list;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return new List<Expense>();
                }
            }
        }

        public List<Package> ReturnPackages()
        {
            try
            {
                connection = new SqlConnection(this.connectionString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                return new List<Package>();
            }
            using (connection)
            {
                try
                {
                    string query = "Select package_id, name, size, quantity, cost from Package Order By package_id";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Package> list = new List<Package>();
                        while (reader.Read())
                        {
                            Package package = new Package();
                            package.Package_id = String.Format("{0}",reader[0]);
                            package.Name = String.Format("{0}", reader[1]);
                            package.Size = String.Format("{0}", reader[2]);
                            package.Quantity = functions.IntegerConverter(String.Format("{0}", reader[3]));
                            package.Cost = functions.DecimalConverter(String.Format("{0}", reader[4]));

                            list.Add(package);
                        }

                        return list;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return new List<Package>();
                }
            }
        }

        public List<Packaging> ReturnPackagings()
        {
            try
            {
                connection = new SqlConnection(this.connectionString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                return new List<Packaging>();
            }
            using (connection)
            {
                try
                {
                    string query = "Select Packaging_id, Stock_id, Package_id, Quantity, Unit_price from Packaging Order By Packaging_id";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Packaging> list = new List<Packaging>();
                        while (reader.Read())
                        {
                            Packaging packaging = new Packaging();
                            packaging.Packaging_id = String.Format("{0}", reader[0]);
                            packaging.Package_id = String.Format("{0}", reader[1]);
                            packaging.Stock_id = functions.IntegerConverter(String.Format("{0}", reader[2]));
                            packaging.Quantity = functions.IntegerConverter(String.Format("{0}", reader[3]));
                            packaging.Unit_price = functions.DecimalConverter(String.Format("{0}", reader[4]));

                            list.Add(packaging);
                        }

                        return list;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return new List<Packaging>();
                }
            }
        }

    }
}
