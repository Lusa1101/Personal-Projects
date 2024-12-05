using Microsoft.AspNetCore.Mvc;
using System.Text;
using VarsityPlug.Models;
using VarsityPlugApi.Contexts;

namespace VarsityPlugApi.Controllers
{
    [ApiController]
    [Route("Controllers/[Controller]/[action]")]
    public class SellerController : ControllerBase
    {
        public VPContext vpContext { get; set; }
        Random random = new Random();
        public SellerController(VPContext _vpContext)
        {
            this.vpContext = _vpContext;
        }

        //Get all the products
        [HttpGet]
        public IEnumerable<Seller> GetAll()
        {
            return this.vpContext.SELLER.ToList();
        }

        //Get product
        [HttpGet("{id}")]
        public Seller Get(int id)
        {
            return this.vpContext.SELLER.First(p => p.SellerId == id);
        }

        //Create product
        [HttpPost]
        public void Create([FromBody] Seller seller)
        {
            bool check = true;

            while(!check)
            {
                try
                {
                    seller.SellerId = random.Next(240000, 999999);
                    this.vpContext.SELLER.Add(seller);
                }
                catch
                {
                    continue;
                }
                check = false;
            }

            this.vpContext.SaveChanges();
        }

        //Delete product
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Seller temp = this.Get(id);
            this.vpContext.SELLER.Remove(temp);
            this.vpContext.SaveChanges();
        }
    }
}
