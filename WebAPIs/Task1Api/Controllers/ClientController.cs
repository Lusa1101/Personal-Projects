using Microsoft.AspNetCore.Mvc;
using Task1Api.Models;
using Task1Api.Services;
using Task1Api.Contexts;

namespace Task1Api.Controllers;

[ApiController]
[Route("api/[Controller]/[action]")]

public class ClientController : ControllerBase
    {
        //Add for the DB
        public ClientContext clientContext { get; set; }

        //Added @ClientContext _clientContext for DB
        public ClientController(ClientContext _clientContext) 
        {
            this.clientContext = _clientContext;
        }


        //@Client is the model
        [HttpGet]
        public IEnumerable<Client> GetAll()
        {
            return this.clientContext.Clients.ToList();
        }

        [HttpGet("{id}")]
        public Client GetById(int id)
        {
        return this.clientContext.Clients.First(client => client.Client_Id == id);
        }
        /*
        public ActionResult<Client> Get(int id)
        {
            var client = ClientService.Get(id);

            if(client == null)
                return NotFound();

            return client;
        }
        */

        [HttpPost]
        public void AddNewClient([FromBody] Client client)
        {
            this.clientContext.Clients.Add(client);
            this.clientContext.SaveChanges();
        }

        /*
        public IActionResult Create(Client client)
        {
            ClientService.Add(client);
        return CreatedAtAction(nameof(GetById), new { id = client.Client_Id }, client); 
        }
        */

        [HttpPut("{id}")]
        public void EditClient(int id, [FromBody] Client client)
        {
            if (id != client.Client_Id)
                return;// BadRequest();  

            Client existingClient = this.GetById(id);
              
            existingClient.Address = client.Address;

            this.clientContext.SaveChanges();
        }

        /*
        public IActionResult Update(int id, Client client)
        {
            if(id != client.Client_Id)
                return BadRequest();

            var existingClient = ClientService.Get(id);
            if(existingClient == null)
                return NotFound();

            ClientService.Update(client);

            return NoContent();
        }
        */

        [HttpDelete]
        public void DeleteClient(int Id)
        {
            Client client = this.GetById(Id);

            if (client == null)
                return;

            this.clientContext.Clients.Remove(client);

            this.clientContext.SaveChanges();
        }
    }

