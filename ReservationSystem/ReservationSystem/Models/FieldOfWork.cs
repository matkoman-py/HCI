using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Models
{
    public class FieldOfWork : AbstractModel
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

        private bool hasRoom;
        public bool HasRoom
        {
            get { return hasRoom; }
            set
            {
                hasRoom = value;
                OnPropertyChanged("HasRoom");
            }
        }
    }
}
