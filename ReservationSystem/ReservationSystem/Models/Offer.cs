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
        public string Id { get; set; }
        [DataMember]
        private Associate Associate { get; set; }
        [DataMember]
        private int Price { get; set; }
        [DataMember]
        private string Description { get; set; }
        [DataMember]
        private string Image { get; set; }

    }
}
