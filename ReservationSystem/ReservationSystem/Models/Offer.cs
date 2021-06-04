using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Models
{
    public class Offer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int AssociateId { get; set; }
        public virtual Associate Associate { get; set; }

        public int OrganizierTaskId { get; set; }
        public virtual OrganizierTask OrganizierTask { get; set; }

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
