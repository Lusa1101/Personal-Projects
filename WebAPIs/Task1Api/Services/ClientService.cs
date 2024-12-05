using Task1Api.Models;

namespace Task1Api.Services
{
    public static class ClientService
    {
        static List<Client> Clients { get; }
        static int nextId = 375;

        static ClientService() 
        {
            Clients = new List<Client>
            {
                new Client {Client_Id = 373, Name = "Tshepo", Address = "Devland", Phone_Number = 0672349876},
                new Client { Client_Id = 374, Name = "Omphulusa", Address = "Diepkloof", Phone_Number = 0783887879 }
            };
        }

        public static List<Client> GetAll() => Clients;

        public static Client? Get(int id) => Clients.FirstOrDefault(c => c.Client_Id == id);

        public static void Add(Client client)
        {
            client.Client_Id = nextId++;
            Clients.Add(client);
        }

        public static void Update(Client client)
        {
            var index = Clients.FindIndex(c => c.Client_Id == client.Client_Id);
            if (index == -1)
                return;

            Clients[index] = client;
        }

        public static void Delete(int id)
        {
            var client = Clients.FirstOrDefault(c => c.Client_Id == id);
            if (client == null)
            return;

            Clients.Remove(client);
        }

        //function to create unique IDs
        
    }

}
