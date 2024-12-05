using Microsoft.AspNetCore.Mvc;
using System.Text;
using System;
using VarsityPlug.Models;
using VarsityPlugApi.Contexts;

namespace VarsityPlugApi.Controllers
{
    [ApiController]
    [Route("Controllers/[Controller]/[action]")]
    public class ReviewController : ControllerBase
    {
        public VPContext vpContext { get; set; }
        Random random = new Random();
        public ReviewController(VPContext _vpContext)
        {
            this.vpContext = _vpContext;
        }

        private string ReviewIDGen()
        {
            StringBuilder sb = new StringBuilder();
            int nextImageID = random.Next(1011101, 9999999);
            sb.Append("REV");
            sb.Append(nextImageID.ToString());
            return sb.ToString();
        }

        //Get all the ratings belonging to the product
        [HttpGet]
        public IEnumerable<ProductReview> GetAll(string prodID)
        {
            return this.vpContext.PRODUCTREVIEW.Where(review => review.ProductID == prodID).ToList();
        }

        //Get item
        [HttpGet("{id}")]
        public ProductReview Get(string id)
        {
            return this.vpContext.PRODUCTREVIEW.First(review => review.ReviewID == id);
        }

        //Add product to cart
        [HttpPost]
        public void Create([FromBody] ProductReview review)
        {
            bool check = true;

            while (!check)
            {
                try
                {
                    review.ReviewID = ReviewIDGen();
                    this.vpContext.PRODUCTREVIEW.Add(review);
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
        public void Update(string reviewID, string descr)
        {
            ProductReview existingReview = this.Get(reviewID);
            existingReview.Description = descr;
            this.vpContext.SaveChanges();
        }

        //Delete item from the cart
        [HttpDelete("{id}")]
        public void Delete(string reviewID)
        {
            ProductReview review = this.Get(reviewID);
            this.vpContext.PRODUCTREVIEW.Remove(review);
            this.vpContext.SaveChanges();
        }
    }
}
