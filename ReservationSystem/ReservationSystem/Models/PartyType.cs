using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Models
{
    public class PartyType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public PartyType() { }

        public PartyType(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
