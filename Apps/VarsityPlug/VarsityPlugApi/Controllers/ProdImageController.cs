using Microsoft.AspNetCore.Mvc;
using VarsityPlug.Models;
using VarsityPlugApi.Service;
using VarsityPlugApi.Contexts;
using System.Text;

namespace VarsityPlugApi.Controllers
{
    [ApiController]
    [Route("Controllers/[Controller]/[action]")]
    public class ProdImageController : ControllerBase
    {
        public VPContext vpContext { get; set; }
        Random random = new Random();


        public ProdImageController(VPContext _vpContext)
        {
            this.vpContext = _vpContext;
        }

        private string ImageIDGen()
        {
            StringBuilder sb = new StringBuilder();
            int nextImageID = random.Next(1001, 9999);
            sb.Append("PR");
            sb.Append(nextImageID.ToString());
            return sb.ToString();
        }

        //Get all the images belonging to the product
        [HttpGet]
        public IEnumerable<ProductImage> GetAll(string prodID)
        {
            return this.vpContext.PRODUCTIMAGE.Where(image => image.ProductID == prodID).ToList();
        }

        //Get image
        [HttpGet("{id}")]
        public ProductImage Get(string id)
        {
            return this.vpContext.PRODUCTIMAGE.First(image => image.ImageID == id);
        }

        //Create account
        [HttpPost]
        public void Create([FromBody] ProductImage image)
        {
            bool check = true;

            while (!check)
            {
                try
                {
                    image.ImageID = ImageIDGen();
                    this.vpContext.PRODUCTIMAGE.Add(image);
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

        //Update person info
        [HttpPut("{id}")]
        public void Update(string id, [FromBody] ProductImage image)
        {
            ProductImage existingImage = this.Get(id);
            existingImage.Title = image.Title;
            this.vpContext.SaveChanges();
        }

        //Delete account
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            ProductImage person = this.Get(id);
            this.vpContext.PRODUCTIMAGE.Remove(person);
            this.vpContext.SaveChanges();
        }
    }
}
