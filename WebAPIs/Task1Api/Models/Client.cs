using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task1Api.Models
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Client_Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int Phone_Number {  get; set; }
    }
}
