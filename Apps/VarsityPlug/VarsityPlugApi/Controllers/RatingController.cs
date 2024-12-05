using Microsoft.AspNetCore.Mvc;
using System.Text;
using System;
using VarsityPlug.Models;
using VarsityPlugApi.Contexts;

namespace VarsityPlugApi.Controllers
{
    [ApiController]
    [Route("Controllers/[Controller]/[action]")]
    public class RatingController : ControllerBase
    {
        public VPContext vpContext { get; set; }
        Random random = new Random();
        public RatingController(VPContext _vpContext)
        {
            this.vpContext = _vpContext;
        }

        private string RatingIDGen()
        {
            StringBuilder sb = new StringBuilder();
            int nextImageID = random.Next(1011101, 9999999);
            sb.Append("RAT");
            sb.Append(nextImageID.ToString());
            return sb.ToString();
        }

        //Get all the ratings belonging to the product
        [HttpGet]
        public IEnumerable<ProductRating> GetAll(string prodID)
        {
            return this.vpContext.PRODUCTRATING.Where(rating => rating.ProductID == prodID).ToList();
        }

        //Get item
        [HttpGet("{id}")]
        public ProductRating Get(string id)
        {
            return this.vpContext.PRODUCTRATING.First(rating => rating.RatingID == id);
        }

        //Add product to cart
        [HttpPost]
        public void Create([FromBody] ProductRating rating)
        {
            bool check = true;

            while(!check)
            {
                try
                {
                    rating.RatingID = RatingIDGen();
                    this.vpContext.PRODUCTRATING.Add(rating);
                }
                catch
                {
                    continue;
                }
                check = false;
            }

            this.vpContext.SaveChanges();
        }

        //Update item's quantaty
        [HttpPut("{id}")]
        public void Update(string ratingID, int rating)
        {
            ProductRating existingRating = this.Get(ratingID);
            existingRating.Ratings = rating;
            this.vpContext.SaveChanges();
        }

        //Delete item from the cart
        [HttpDelete("{id}")]
        public void Delete(string ratingID)
        {
            ProductRating item = this.Get(ratingID);
            this.vpContext.PRODUCTRATING.Remove(item);
            this.vpContext.SaveChanges();
        }
    }
}
