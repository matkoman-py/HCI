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
    public class Suggestion
    {
        [Key]
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        private List<OrganizierTask> Tasks { get; set; }
        [DataMember]
        private string Comment { get; set; }
        [DataMember]
        private PartyRequest Request { get; set; }  
    }
}
