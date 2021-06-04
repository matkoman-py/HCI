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
        
        public int Id { get; set; }
        
        public PartyType PartyType { get; set; }
        
        public int Budget { get; set; }
        
        public string Place { get; set; }
        
        public DateTime Time { get; set; }
        
        public int Capacity { get; set; }
        
        public bool IsBudgetFlexible { get; set; }
        
        public string PartyTheme { get; set; }
        
        public string Description { get; set; }
        
        public RequestState RequestState { get; set; }

        
        public int CreatorId { get; set; }
        
        public int OragnizatorId { get; set; }
        public PartyRequest()
        {

        }

        public PartyRequest(PartyType partyType, int budget, string place, DateTime time, int capacity, bool isBudgetFlexible, string partyTheme, string description, RequestState requestState, int creatorId)
        {
            PartyType = PartyType;
            Budget = budget;
            Place = place;
            Time = time;
            Capacity = capacity;
            IsBudgetFlexible = isBudgetFlexible;
            PartyTheme = partyTheme;
            Description = description;
            RequestState = requestState;
            CreatorId = creatorId;
        }


    }
}
