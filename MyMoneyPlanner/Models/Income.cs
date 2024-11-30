using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MyMoneyPlanner.Models
{
    [Table("income")]
    public class Income
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public decimal Planned_amount { get; set; } = 0;
        public decimal Actual_amount { get; set; } = 0;

        [MaxLength(50)]
        public string? Title { get; set; }

        DateTime Create_date { get; set; }
        DateTime Modified_date {  get; set; } 

        public void create_date()
        {
            Create_date = DateTime.Now;
        }

        public void modified_date()
        {
            Modified_date = DateTime.Now; 
        }

        //New 
        [Unique, MaxLength(50)]
        public string? Subtitle { get; set; }

        [NotNull, MaxLength(1)]
        public string? Type { get; set; }
    }
}
