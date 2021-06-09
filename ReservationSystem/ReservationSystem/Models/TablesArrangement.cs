using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Models
{
    public class TablesArrangement : AbstractModel
    {
        [Key]
        public int Id { get; set; }
        public virtual List<Table> Tables { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public TablesArrangement()
        {

        }

        public TablesArrangement(List<Table> tables, string description, string image)
        {
            Tables = tables;
            Description = description;
            Image = image;
        }
    }
}
