using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VarsityPlug.Models;

namespace VarsityPlug
{
    public partial class CartPage : ContentPage
    {
        string _username;
        Connect data = new Connect();
        public CartPage(string username)
        {
            InitializeComponent();
            _username = username;

            Cart();
        }

        void Cart()
        {
            List<Cart> items = data.ReturnCartItems(Int32.Parse(_username));
            List<CartItem1>tempItems = new List<CartItem1>();
            List<Product> products = new List<Product>();
            List<Seller> sellers = new List<Seller>();
            List<Person> people = new List<Person>();
            Product product;
            Seller seller;
            Person person;

            foreach (var item in items)
            {
                if(item.ProductId != null)
                {
                    product = data.ReturnProduct(item.ProductId);
                    products.Add(product);

                    seller = data.ReturnSeller(product.SellerID);
                    


                    if( !people.Exists(p => p.Id == seller.ID))
                    {
                        person = data.ReturnPerson(seller.ID.ToString());
                        people.Add(person);
                        sellers.Add(seller);

                        tempItems.Add(new CartItem1
                        {
                            ProductName = product.Name,
                            SellerName = person.Name,
                            TotalPrice = product.Price
                        });
                    }
                }
            }

            cartBySeller.ItemsSource = tempItems;
        }

        async void OnCartSeller(object sender, SelectionChangedEventArgs e)
        {
            await Navigation.PushAsync(new CartSeller());
        }

        async void OnCart(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CartPage(_username));
        }

        async void OnProfile(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }

        async void OnChangeMode(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Switch Mode To:", "Cancel", null,
                "Seller", "Buyer");

            if (action == "Seller")         //Have t check if user has a SellerID
                await Navigation.PushAsync(new SellerHomePage());
            else if (action == "Buyer")
                await Navigation.PushAsync(new HomePage(_username));
        }

        async void OnHomePage(object sender, TappedEventArgs e)
        {
            await Navigation.PushAsync(new HomePage(_username));
        }
    }
}
