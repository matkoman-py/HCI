using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Models
{
    public class Offer : AbstractModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int AssociateId { get; set; }
        public virtual Associate Associate { get; set; }
        public virtual List<OrganizierTask> OrganizierTasks { get; set; }
        public int? TablesArrangementId { get; set; }
        public virtual TablesArrangement TablesArrangement { get; set; }
        private bool isRoom;
        public bool IsRoom 
        {
            get { return isRoom; }
            set 
            { 
                isRoom = value;
                OnPropertyChanged("IsRoom");
            }
        }

        public Offer()
        {

        }

        public Offer(Associate associate, string name, int price, string description, string image)
        {
            Name = name;
            Associate = associate;
            Price = price;
            Description = description;
            Image = image;
        }


    }
}
