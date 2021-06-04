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

    public enum PartyType { Birthday, Anniversary, Other}

    public enum RequestState { Pending, Rejected, Accepted }

    [DataContract]
    public class PartyRequest
    {
        [Key]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public PartyType PartyType { get; set; }
        [DataMember]
        public int Budget { get; set; }
        [DataMember]
        public string Place { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string Time { get; set; }
        [DataMember]
        public int Capacity { get; set; }
        [DataMember]
        public bool IsBudgetFlexible { get; set; }
        [DataMember]
        public string PartyTheme { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public RequestState RequestState { get; set; }
        [DataMember]
        public int CreatorId { get; set; }
        [DataMember]
        public int OrganiserId { get; set; }
        public PartyRequest()
        {

        }

        public PartyRequest(PartyType partyType, int budget, string place, string time,DateTime date, int capacity, bool isBudgetFlexible, string partyTheme, string description, RequestState requestState, int creatorId)
        {
            PartyType = partyType;
            Budget = budget;
            Place = place;
            Time = time;
            Capacity = capacity;
            IsBudgetFlexible = isBudgetFlexible;
            PartyTheme = partyTheme;
            Description = description;
            Date = date;
            RequestState = requestState;
            CreatorId = creatorId;
        }


    }
}
