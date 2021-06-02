using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Models
{
    [DataContract]
    public class TablesArrangement
    {
        [Key]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public List<Table> Tables { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Image { get; set; }

        public TablesArrangement(List<Table> tables, string description, string image)
        {
            Tables = tables;
            Description = description;
            Image = image;
        }
    }
}
