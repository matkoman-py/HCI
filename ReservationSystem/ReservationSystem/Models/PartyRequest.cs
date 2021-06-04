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
        private PartyType birthday;
        private int v1;
        private string v2;
        private DateTime dateTime;
        private int v3;
        private bool v4;
        private string v5;
        private string v6;
        private RequestState accepted;
        private int v7;

        [Key]
        
        public int Id { get; set; }
        
        public PartyType PartyType { get; set; }
        
        public int Budget { get; set; }
        
        public string Place { get; set; }

        public DateTime Date { get; set; }
                
        public int Capacity { get; set; }
        
        public bool IsBudgetFlexible { get; set; }
        
        public string PartyTheme { get; set; }
        
        public string Description { get; set; }
        
        public RequestState RequestState { get; set; }

        public int CreatorId { get; set; }
        public int OrganiserId { get; set; }
        public PartyRequest()
        {

        }

        public PartyRequest(PartyType partyType, int budget, string place, DateTime date, int capacity, bool isBudgetFlexible, string partyTheme, string description, RequestState requestState, int creatorId)
        {
            PartyType = partyType;
            Budget = budget;
            Place = place;
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
