using Microsoft.AspNetCore.Mvc;
using System.Text;
using VarsityPlug.Models;
using VarsityPlugApi.Contexts;

namespace VarsityPlugApi.Controllers
{
    [ApiController]
    [Route("Controllers/[Controller]/[action]")]
    public class BuyerController : ControllerBase
    {
        public VPContext vpContext { get; set; }
        Random random = new Random();
        public BuyerController(VPContext _vpContext)
        {
            this.vpContext = _vpContext;
        }

        //Get all the products
        [HttpGet]
        public IEnumerable<Buyer> GetAll()
        {
            return this.vpContext.BUYER.ToList();
        }

        //Get product
        [HttpGet("{id}")]
        public Buyer Get(int id)
        {
            return this.vpContext.BUYER.First(p => p.BuyerID == id);
        }

        //Create product
        [HttpPost]
        public void Create([FromBody] Buyer buyer)
        {
            bool check = true;

            while (!check)
            {
                try
                {
                    buyer.BuyerID = random.Next(11111111, 99999999);
                    this.vpContext.BUYER.Add(buyer);
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
            Buyer temp = this.Get(id);
            this.vpContext.BUYER.Remove(temp);
            this.vpContext.SaveChanges();
        }
    }
}
