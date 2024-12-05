//Model
using System;
using SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoneyManager.Models
{
    //[Table("union")]
    public class Union
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Unique, MaxLength(100), NotNull]
        public string? Title { get; set; }

        [Unique, MaxLength(100)]
        public string? Subtitle { get; set; }

        //I for income and E for expense
        [NotNull]
        public char? Type { get; set; }

        public decimal Actual_amount { get; set; } = decimal.Zero;
        public decimal Planned_amount { get; set; } = decimal.Zero;

        private DateTime Create_date { get; set; }
        public void create_date()
        {
            Create_date = DateTime.Now;
        }

        private DateTime Modified_date { get; set; }
        public void modified_date()
        {
            Modified_date = DateTime.Now;
        }
    }
}