using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VarsityPlug.Models;

namespace VarsityPlug.Page
{
    public partial class ProductPage : ContentPage
    {
        List<Product> products = new List<Product>()
            {
                new Product {Name="Mash RAM", Description="16GB DDR4 SO-DIMM", Category="Electronics", SubCategory="Computers",
                    ProductID="828", SellerID=330033, Price=1099.99, Quantity=10, SoldQuantity=3},
                new Product {Name="Mash Hard-drive", Description="1TB SSD", Category="Electronics", SubCategory="Computers",
                    ProductID="822", SellerID=330033, Price=3599.99, Quantity=5, SoldQuantity=0},
                new Product {Name="Mash Monitor", Description="24\" Screen Full HD Flat Screen", Category="Electronics", SubCategory="Computers",
                    ProductID="872", SellerID=330033, Price=2099.99, Quantity=7, SoldQuantity=3},
                new Product {Name="Mash MAC RAM", Description="16GB MAC DDR4 SO-DIMM", Category="Electronics", SubCategory="Computers",
                    ProductID="888", SellerID=330033, Price=1699.99, Quantity=17, SoldQuantity=5},
                new Product {Name="Kushu", Description="Medium-sized Kushu with unique art.", Category="Arts", SubCategory="Sculptures",
                    ProductID="292", SellerID=220022, Price=99.99, Quantity=20, SoldQuantity=7},
                new Product {Name="Purple Haze", Description="Premium marijuana per gram", Category="Health", SubCategory="Medicine",
                    ProductID="298", SellerID=220022, Price=69.99, Quantity=55, SoldQuantity=7}
            };

        List<ProductDiscount> discounts = new List<ProductDiscount>()
        {
            new ProductDiscount {ProductID=828, Discount=399.99},
            new ProductDiscount {ProductID=872, Discount=1099.99},
            new ProductDiscount {ProductID=292, Discount=30}
        };

        List<SellerProduct> sp = new List<SellerProduct>()
            {
                new SellerProduct { ItemName="Exodus Cheese", ItemPrice=149.99, InStock=79, IsAvailable=true, NumberOFSales=21, Proportion=45.87, Ratings=4},
                new SellerProduct { ItemName="Kushu", ItemPrice=99.99, InStock=0, IsAvailable=false, NumberOFSales=3, Proportion=12.6, Ratings=3},
                new SellerProduct { ItemName="Purple Haze", ItemPrice=69.99, InStock=34, IsAvailable=true, NumberOFSales=21, Proportion=85.87, Ratings=5}

            };

        string _username;
        public ProductPage(SellerProduct product)
        {
            InitializeComponent();

            //Handing the variables in the Product Page values
            Product product1 = new Product();
            foreach(Product prod in products)
            {
                foreach (SellerProduct prod1 in sp)
                    if (prod.Name == prod1.ItemName)
                    {
                        product1 = prod;
                        break;
                    } 
            }

            prodName.Placeholder = product.ItemName;
            prodDescription.Placeholder = product1.Description;
            prodPrice.Placeholder = $"R {product.ItemPrice}";
            
            foreach(ProductDiscount discount in discounts)
                if(Int32.Parse(product1.ProductID) == discount.ProductID)
                {
                    prodDiscount.Placeholder = $"R {discount.Discount}";
                    break;
                }

            prodQty.Placeholder = product.InStock.ToString();
        }
        void Data()
        {
            List<string> list = new List<string>();

            for (int i = 0; i < 4; i++)
                list.Add("chopper.jpeg");

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

            //itemImages.ItemsSource = list;

            //itemInfo.ItemsSource = items;
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
