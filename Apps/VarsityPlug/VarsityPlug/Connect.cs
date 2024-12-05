using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using VarsityPlug.Models;

namespace VarsityPlug
{
    class Connect
    {
        string dbName = "VarsityPlug";
        string serverName = @"LAPTOP-HHQOVSI1\\SQLEXPRESS";
        string username = "Tom";
        string password = "tomtom";
        string connStr = "Data Source=LAPTOP-HHQOVSI1\\SQLEXPRESS;Initial Catalog=VarsityPlug;Integrated Security=True;Trust Server Certificate=True";

        private string connectionString = "Server=LAPTOP-HHQOVSI1\\SQLEXPRESS;Database=VarsityPlug;User ID=Tom;Password=tomtom; TrustServerCertificate=True";
        string queryString = "SELECT * FROM PERSON;";
        SqlConnection conn;

                //Initializer
        public Connect()
        {
            
        }

        //Functions
        public void AddUser(Person person)
        {
            try
            {
                conn = new SqlConnection(this.connectionString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to connect.\n" + ex.Message);
                throw;
            }
            using (conn)
            {
                string query = @$"INSERT INTO PERSON VALUES ({person.Id}, '{person.Name}', '{person.Surname}', '{person.Email}', '{person.Cell}', '{person.Password}', GETDATE());";
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Connection.Open();
                    int result = cmd.ExecuteNonQuery();

                    Debug.WriteLine("\nInsert" + result);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("\nInserting failed: " + ex.Message);
                }

            }
        }

        public void AddItemToCart(Cart item)
        {
            try
            {
                conn = new SqlConnection(this.connectionString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to connect.\n" + ex.Message);
                throw;
            }
            using (conn)
            {
                string query = @$"INSERT INTO Cart VALUES ({item.ProductId}, {item.BuyerId}, {item.Quantity}, GETDATE());";
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Connection.Open();
                    int result = cmd.ExecuteNonQuery();

                    Debug.WriteLine("\nInsert" + result);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("\nInserting failed: " + ex.Message);
                }

            }
        }

        public Person ReturnPerson(string username)
        {
            List<Person> temp = new List<Person>();
            Person person = new Person();

            try
            {
                conn = new SqlConnection(this.connectionString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to connect.\n" + ex.Message);
                throw;
            }
            using (conn)
            {
                string query = $"SELECT Id, Name, Surname, Cell, Password FROM PERSON WHERE Id={Int32.Parse(username)};";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Debug.WriteLine(String.Format("{0}, {1}", reader[0], reader[4]));

                        //Filling up the temp with people info
                        person.Id = Int32.Parse(String.Format("{0}", reader[0]));
                        person.Name = String.Format("{0}", reader[1]);
                        person.Surname = String.Format("{0}", reader[2]);
                        person.Cell = String.Format("{0}", reader[3]);
                        person.Password = String.Format("{0}", reader[4]);

                        temp.Add(person);
                    }
                }
            }

            return person;
        }

        public List<Person> ReturnPeople()
        {
            List<Person> temp = new List<Person>(); 
            Person person = new Person();

            try
            {
                conn = new SqlConnection(this.connectionString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to connect.\n" + ex.Message);
                throw;
            }
            using (conn)
            {
                string query = "SELECT Id, Name, Surname, Cell, Password FROM PERSON;";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Debug.WriteLine(String.Format("{0}, {1}", reader[0], reader[4]));

                        //Filling up the temp with people info
                        person.Id = Int32.Parse(String.Format("{0}", reader[0]));
                        person.Name = String.Format("{0}", reader[1]);
                        person.Surname = String.Format("{0}", reader[2]);
                        person.Cell = String.Format("{0}", reader[3]);
                        person.Password = String.Format("{0}", reader[4]);

                        temp.Add( person );
                    }
                }
            }

            return temp;
        }

        public List<Cart> ReturnCartItems(int buyerid)
        {
            List<Cart> temp = new List<Cart>();
            Cart item = new Cart();

            try
            {
                conn = new SqlConnection(this.connectionString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to connect.\n" + ex.Message);
                throw;
            }
            using (conn)
            {
                string query = $"SELECT * FROM CART WHERE BUYERID = {buyerid};";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Debug.WriteLine(String.Format("{0}, {1}", reader[0], reader[1]));

                        //Filling up the temp with people info
                        item.ProductId = String.Format("{0}", reader[0]);
                        item.BuyerId = Int32.Parse(String.Format("{0}", reader[1]));
                        item.Quantity = Int32.Parse(String.Format("{0}", reader[2]));

                        temp.Add(item);
                    }
                }
            }

            return temp;
        }

        public List<Product> ReturnProducts(int sellerId)
        {
            List<Product> temp = new List<Product>();
            Product product = new Product();

            try
            {
                conn = new SqlConnection(this.connectionString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to connect.\n" + ex.Message);
                throw;
            }
            using (conn)
            {
                string query = $"SELECT * FROM Product WHERE SellerId = {sellerId};";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Debug.WriteLine(String.Format("{0}, {1}", reader[0], reader[4]));

                        //Filling up the temp with people info
                        product.ProductID = String.Format("{0}", reader[0]);
                        product.SellerID = Int32.Parse(String.Format("{0}", reader[1]));
                        product.Name = String.Format("{0}", reader[2]);
                        product.Description = String.Format("{0}", reader[3]);
                        product.Price = Double.Parse(String.Format("{0}", reader[4]));
                        product.SubCategory = String.Format("{0}", reader[5]);

                        temp.Add(product);
                    }
                }
            }

            return temp;
        }

        public Product ReturnProduct(string productId)
        {
            List<Product> temp = new List<Product>();
            Product product = new Product();

            try
            {
                conn = new SqlConnection(this.connectionString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to connect.\n" + ex.Message);
                throw;
            }
            using (conn)
            {
                string query = $"SELECT * FROM Product WHERE ProductId = '{productId}';";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Debug.WriteLine(String.Format("{0}, {1}", reader[0], reader[1]));

                        //Filling up the temp with people info
                        product.ProductID = String.Format("{0}", reader[0]);
                        product.SellerID = Int32.Parse(String.Format("{0}", reader[1]));
                        product.Name = String.Format("{0}", reader[2]);
                        product.Description = String.Format("{0}", reader[3]);
                        product.Price = Double.Parse(String.Format("{0}", reader[4]));
                        product.SubCategory = String.Format("{0}", reader[5]);

                        //temp.Add(product);
                    }
                }
            }

            return product;
        }

        public Seller ReturnSeller(int sellerId)
        {
            List<Seller> temp = new List<Seller>();
            Seller seller = new Seller();

            try
            {
                conn = new SqlConnection(this.connectionString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to connect.\n" + ex.Message);
                throw;
            }
            using (conn)
            {
                string query = $"SELECT * FROM Seller WHERE SellerId = {sellerId};";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Debug.WriteLine(String.Format("{0}, {1}", reader[0], reader[4]));

                        //Filling up the temp with people info
                        seller.ID = Int32.Parse(String.Format("{0}", reader[0]));
                        seller.SellerId = Int32.Parse(String.Format("{0}", reader[1]));

                        //temp.Add(product);
                    }
                }
            }

            return seller;
        }

        public void CreateConnection()
        {
            try
            {
                conn = new SqlConnection(this.connectionString);
            }
            catch(Exception ex) 
            {
                Debug.WriteLine("Failed to connect.\n" + ex.Message);
                throw;
            }
            using (conn)
            {
                SqlCommand cmd = new SqlCommand(this.queryString, conn);
                cmd.Connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader()) 
                {
                    while(reader.Read())
                    {
                        Debug.WriteLine(String.Format("{0}, {1}", reader[0], reader[1]));
                    }
                }
            }
        }
    }
}
