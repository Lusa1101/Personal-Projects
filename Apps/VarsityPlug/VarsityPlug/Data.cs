using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

using VarsityPlug.Models;

namespace VarsityPlug
{
    public class Dataset
    {
        List<int> ids = new List<int>();
        

        public List<Person> users = new List<Person>()
            {
                new Person { Id = 202244400, Cell="0783887879", Email="202244400@keyaka.ul.ac.za", Name="Omphulusa", Surname="Mashau", Password="omphu"},
                new Person { Id = 202212346, Cell="0781237890", Email="202212346@keyaka.ul.ac.za", Name="Ndivhuwo", Surname="Mashau", Password="ndivhu"},
                new Person { Id = 202112347, Cell = "0835080100", Email = "elisa@gmail.com", Name = "Elisa", Surname = "Senoko", Password="elisa" },
                new Person { Id = 202112348, Cell = "0735037777", Email = "tshii@gmail.com", Name = "Tshifhiwa", Surname = "Senoko", Password="tshifhi"},
                new Person { Id = 201867389, Cell = "0723678888", Email = "dee@yahoo.com", Name = "Dakalo", Surname = "Mashau", Password="Daki" }
            };

        public List<Buyer> buyers = new List<Buyer>()
            {
                new Buyer {ID=202212345, BuyerID=12345},
                new Buyer {ID=202212346, BuyerID=12346},
                new Buyer { ID = 202112347, BuyerID = 12347 },
                new Buyer { ID = 202112348, BuyerID = 12344 },
                new Buyer { ID = 201867389, BuyerID = 12348 }
            };

        public List<Seller> sellers = new List<Seller>()
            {
                new Seller {ID=201867389, SellerId=330033},
                new Seller {ID=202212346, SellerId=220022}
            };

        public List<Product> products = new List<Product>()
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


        public List<ProductRating> ratings = new List<ProductRating>()
            {
                new ProductRating {ProductID=298, BuyerID=12347, RatingID=298001, Ratings=4},
                new ProductRating {ProductID=298, BuyerID=12345, RatingID=298002, Ratings=3},
                new ProductRating {ProductID=298, BuyerID=12348, RatingID=298003, Ratings=3},
                new ProductRating {ProductID=822, BuyerID=12345, RatingID=822002, Ratings=3},
                new ProductRating {ProductID=822, BuyerID=12344, RatingID=822003, Ratings=5},
                new ProductRating {ProductID=872, BuyerID=12344, RatingID=872001, Ratings=5},
                new ProductRating {ProductID=872, BuyerID=12345, RatingID=872002, Ratings=4},
                new ProductRating {ProductID=292, BuyerID=12347, RatingID=292001, Ratings=2},
                new ProductRating {ProductID=292, BuyerID=12345, RatingID=292002, Ratings=4},
                new ProductRating {ProductID=828, BuyerID=12344, RatingID=828002, Ratings=4},
                new ProductRating {ProductID=828, BuyerID=12347, RatingID=828001, Ratings=3},
                new ProductRating {ProductID=828, BuyerID=12346, RatingID=828004, Ratings=5}
            };

        public List<Order> orders = new List<Order>();
        public List<Cart> cart = new List<Cart>();
        public List<ProductImage> images = new List<ProductImage>();
        public List<ProductReview> reviews = new List<ProductReview>();

        public Dataset()
        {
                        
        }

        public List<Product> ReturnProducts()
        {
            return products; 
        }
        public List<Person> ReturnUsers()
        {
            return users;
        }
        public List<ProductRating> ReturnRatings()
        {
            return ratings;
        }
        public List<Seller> ReturnSellers()
        {
            return sellers;
        }
        public List<Buyer> ReturnBuyers()
        {
            return buyers;
        }
        public List<Cart> ReturnCart()
        {
            return cart;
        }
        public List<ProductReview> ReturnReviews()
        {
            return reviews;
        }
        public List<ProductImage> ReturnImages()
        {
            return images;
        }
        public void AddUser(Person person)
        {
            users.Add(person);
        }
        public void AddImage(ProductImage image)
        {
            images.Add(image);
        }
        public void AddReview(ProductReview review)
        {
            reviews.Add(review);
        }
        public void AddSeller(Seller seller) 
        {
            sellers.Add(seller);
        }
        public void AddBuyer(Buyer buyer)
        {
            buyers.Add(buyer);
        }
        public void AddProduct(Product product)
        {
            products.Add(product);
        }
        public void AddRating(ProductRating rating)
        {
            ratings.Add(rating);
        }
        public void AddToCart(Cart c)
        {
            cart.Add(c);
        }




        public int IDGenerator()
        {
            Random rand = new Random();
            return rand.Next(10000, 99999);
        }
    }

}
