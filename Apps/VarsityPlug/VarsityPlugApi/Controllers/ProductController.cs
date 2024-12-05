using Microsoft.AspNetCore.Mvc;
using System.Text;
using VarsityPlug.Models;
using VarsityPlugApi.Contexts;

namespace VarsityPlugApi.Controllers
{
    [ApiController]
    [Route("Controllers/[Controller]/[action]")]
    public class ProductController : ControllerBase
    {
        public VPContext vpContext { get; set; }
        Random random = new Random();
        public ProductController(VPContext _vpContext)
        {
            this.vpContext = _vpContext;
        }

        private string ProdIDGen()
        {
            StringBuilder sb = new StringBuilder();
            int nextProdId = random.Next(100001, 999999);
            sb.Append("PR");
            sb.Append(nextProdId.ToString());
            return sb.ToString();
        }

        //Get all the products
        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return this.vpContext.PRODUCT.ToList();
        }

        //Get product
        [HttpGet("{id}")]
        public Product Get(string id)
        {
            return this.vpContext.PRODUCT.First(p => p.ProductID == id);
        }

        //Create product
        [HttpPost]
        public void Create([FromBody] Product product)
        {
            bool check = true;

            while (!check)
            {
                try
                {
                    product.ProductID = ProdIDGen();
                    this.vpContext.PRODUCT.Add(product);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    continue;
                }
                check = false;
            }
            this.vpContext.SaveChanges();
        }

        //Update product info
        [HttpPut]
        public void Update(string id, Product product)
        {
            Product temp = this.Get(id);
            //temp.Description = product.Description;
            temp.Price = product.Price;
            this.vpContext.SaveChanges();
        }

        //Delete product
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            Product temp = this.Get(id);
            this.vpContext.PRODUCT.Remove(temp);
            this.vpContext.SaveChanges();
        }
    }
}
