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
    public class OrganizierTask
    {
        [Key]
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        private string Name { get; set; }
        [DataMember]
        private string Description { get; set; }
        [DataMember]
        private List<Offer> SelectedOffers { get; set; }
        [DataMember]
        private bool IsDone { get; set; }
        [DataMember]
        private string Comment { get; set; }
    }
}
