using Microsoft.EntityFrameworkCore;
using Task1Api.Models;

namespace Task1Api.Contexts
{
    public class ClientContext : DbContext
    {
        public ClientContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        {
             
        }

        public DbSet<Client> Clients { get; set; } = null!;

    }
}
