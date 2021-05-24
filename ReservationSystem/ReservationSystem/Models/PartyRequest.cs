using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Models
{

    public enum PartyType { Birthday, Anniversary, Other}

    public enum RequestState { Pending, Rejected, Accepted }

    [DataContract]
    public class PartyRequest
    {
        [Key]
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        private PartyType PartyType { get; set; }
        [DataMember]
        private int Budget { get; set; }
        [DataMember]
        private string Place { get; set; }
        [DataMember]
        private DateTime Time { get; set; }
        [DataMember]
        private int Capacity { get; set; }
        [DataMember]
        private bool IsBudgetFlexible { get; set; }
        [DataMember]
        private string PartyTheme { get; set; }
        [DataMember]
        private string Description { get; set; }
        [DataMember]
        private RequestState RequestState { get; set; }

    }
}
