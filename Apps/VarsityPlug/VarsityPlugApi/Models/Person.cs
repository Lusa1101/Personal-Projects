using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarsityPlug.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ? Name { get; set; }
        public string ? Surname { get; set; }
        public string ? Email { get; set; }
        public string ? Cell { get; set; }
        public string ? Password { get; set; }

        public void SetPassword(string pass)
        {
            Password = pass;
        }
    }

}
