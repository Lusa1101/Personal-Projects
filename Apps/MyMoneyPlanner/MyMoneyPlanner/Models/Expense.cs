using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MyMoneyPlanner.Models
{
    [Table("expense")]
    public class Expense
    {
        [PrimaryKey, AutoIncrement]
        public int expense_id { get; set; }

        public decimal actual_amount { get; set; } = 0;
        public decimal planned_amount { get; set; } = 0;

        [MaxLength(50)]
        public string? title { get; set; }

        [Unique, MaxLength(50)]
        public string? subtitle { get; set; }

        DateTime create_date { get; set; }
        DateTime modified_date { get; set; }

        public void SetCreateDate()
        {
            create_date = DateTime.Now;
        }

        public void SetModifiedDate()
        {
            modified_date = DateTime.Now;
        }

    }
}
