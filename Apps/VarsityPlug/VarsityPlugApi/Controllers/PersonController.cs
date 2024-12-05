using Microsoft.AspNetCore.Mvc;
using VarsityPlug.Models;
using VarsityPlugApi.Service;
using VarsityPlugApi.Contexts;

namespace VarsityPlugApi.Controllers
{
    [ApiController]
    [Route("Controllers/[Controller]/[action]")]
    public class PersonController : ControllerBase
    {
        public VPContext vpContext {  get; set; }
        public PersonController(VPContext _vpContext) 
        { 
            this.vpContext = _vpContext;
        }

        [HttpGet]
        public IEnumerable <Person> GetAll()
        {
            return vpContext.PERSON.ToList();
        }
        
        //Get person
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return this.vpContext.PERSON.First(person => person.Id == id);
        }

        //Create account
        [HttpPost]
        public void Create([FromBody] Person person)
        {

            this.vpContext.PERSON.Add(person);
            this.vpContext.SaveChanges();
        }

        //Update person info
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] Person person)
        {
            Person existingPerson = this.Get(id);
            existingPerson.Cell = person.Cell;
            this.vpContext.SaveChanges();
        }

        //Delete account
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Person person = this.Get(id);
            this.vpContext.PERSON.Remove(person);
            this.vpContext.SaveChanges();
        }
    }
}
