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
    public class Offer
    {
        [Key]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public Associate Associate { get; set; }
        [DataMember]
        public int Price { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Image { get; set; }

        public Offer(Associate associate, int price, string description, string image)
        {
            Associate = associate;
            Price = price;
            Description = description;
            Image = image;
        }

    }
}
