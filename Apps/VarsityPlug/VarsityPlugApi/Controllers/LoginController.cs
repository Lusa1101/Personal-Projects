using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VarsityPlug.Models;
using VarsityPlugApi.Contexts;

namespace VarsityPlugApi.Controllers
{
    [ApiController]
    [Route("Controllers/[Controller]/[action]")]
    public class LoginController : ControllerBase
    {
        public VPContext vpContext { get; set; }

        public LoginController(VPContext _vpContext) 
        {
            this.vpContext = _vpContext;
        }

        [HttpGet]
        public int Authorize(int id, string password)
        {
            Person? person = this.vpContext.PERSON.First(person => person.Id == id);
            if (person.Password == password)
                return 1;
            else return 0;
        }

        [HttpPost]
        public int Register(Person person)
        {
            try
            {
                this.vpContext.PERSON.Add(person);
            }
            catch
            {
                return 0;
            }
            return 1;
        }

    }
}
