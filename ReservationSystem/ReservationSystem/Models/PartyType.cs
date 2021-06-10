using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Models
{
    public class PartyType : AbstractModel
    {
        [Key]
        public int Id { get; set; }
        private string name;
        public string Name 
        {
            get { return name; }
            set 
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public PartyType() { }

        public PartyType(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
