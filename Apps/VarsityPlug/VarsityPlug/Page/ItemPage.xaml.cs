using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VarsityPlug.Models;

namespace VarsityPlug.Page
{
    public partial class ItemPage : ContentPage
    {
        List<string> list = new List<string>();

        List<ItemReview> items = new List<ItemReview>()
            {
                new ItemReview {Name="Omphu", Review="I really enjoyed using the product. " +
                        "My family loves it as well. I really recommend it"},
                new ItemReview {Name="Ompile", Review="I really enjoyed using the product. " +
                        "My family loves it as well. I really recommend it"},
                new ItemReview {Name="Thendo", Review="I really enjoyed using the product. " +
                        "My family loves it as well. I really recommend it"},
                new ItemReview {Name="Rotshidzwa", Review="I really enjoyed using the product. " +
                        "My family loves it as well. I really recommend it"},
                new ItemReview {Name="Uhone", Review="I really enjoyed using the product. " +
                        "My family loves it as well. I really recommend it"},
            };

        List<Seller> sellers = new List<Seller>()
        {
            new Seller {ID=201867389, SellerId=330033},
            new Seller {ID=202212346, SellerId=220022}
        };

        List<Person> users = new List<Person>()
            {
                new Person {Id=202212345, Cell="0783887879", Email="mashau@gmail.com", Name="Omphu", Surname="Mashau"},
                new Person {Id=202212346, Cell="0781237890", Email="ndii@gmail.com", Name="Ndivhuwo", Surname="Mashau"},
                new Person {Id=202112347, Cell="0835080100", Email="elisa@gmail.com", Name="Elisa", Surname="Senoko"},
                new Person {Id=202112348, Cell="0735037777", Email="tshii@gmail.com", Name="Tshifhiwa", Surname="Senoko"},
                new Person {Id=201867389, Cell="0723678888", Email="dee@yahoo.com", Name="Dakalo", Surname="Mashau"}
            };

        Product _product;
        string _username;
        Connect data = new Connect();

        public ItemPage(string username, Product product)
        {
            InitializeComponent();

            _product = product;
            _username = username;

            Data();

            //PAssing the product information to the item page

            itemName.Text = product.Name;
            itemDescription.Text = product.Description;
            
            foreach(Seller seller in sellers)
                if(seller.SellerId == product.SellerID)
                     foreach(Person person in users)
                         if(seller.ID == person.Id)
                         {
                            sellerName.Text = person.Name;
                             break;
                         }

            itemPrice.Text = $"R{product.Price}";
        }

        void OnAddToCart(object sender, EventArgs e)
        {
            Cart item = new Cart();
            item.ProductId = _product.ProductID;
            item.BuyerId = Int32.Parse(_username);
            item.Quantity = 1;

            data.AddItemToCart(item);

            DisplayAlert("Add item to cart", "Successfully added.", "Okay");
        }

        void Data()
        {
            //itemImages.ItemsSource = list;

            itemInfo.ItemsSource = items;        
        }

        void OnRefresh(object sender, EventArgs e)
        {
            Data();
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
 