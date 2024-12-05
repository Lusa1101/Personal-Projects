using Microsoft.AspNetCore.Mvc;
using VarsityPlug.Models;
using VarsityPlugApi.Contexts;

namespace VarsityPlugApi.Controllers
{
    [ApiController]
    [Route("Controllers/[Controller]/[action]")]
    public class CartController : ControllerBase
    {
        public VPContext vpContext { get; set; }
        public CartController(VPContext _vpContext)
        {
            this.vpContext = _vpContext;
        }

        //Get all the items belonging to the buyer
        [HttpGet]
        public IEnumerable<Cart> GetAll(int buyerID)
        {
            return this.vpContext.CART.Where(item => item.BuyerId == buyerID).ToList();
        }

        //Get item
        [HttpGet("{id}")]
        public Cart Get(string prodID, int buyerID)
        {
            return this.vpContext.CART.First(item => item.ProductId == prodID && item.BuyerId == buyerID);
        }

        //Add product to cart
        [HttpPost]
        public void Create([FromBody] Cart item)
        {
            item.Quantity = 1;
            this.vpContext.CART.Add(item);
            this.vpContext.SaveChanges();
        }

        //Update item's quantaty
        [HttpPut("{id}")]
        public void Update(string prodID, int buyerID, int qty)
        {
            Cart existingItem = this.Get(prodID, buyerID);
            existingItem.Quantity = qty;
            this.vpContext.SaveChanges();
        }

        //Delete item from the cart
        [HttpDelete("{id}")]
        public void Delete(string prodID, int buyerID)
        {
            Cart item = this.Get(prodID, buyerID);
            this.vpContext.CART.Remove(item);
            this.vpContext.SaveChanges();
        }
    }
}
