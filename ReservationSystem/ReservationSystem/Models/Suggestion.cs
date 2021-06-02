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
        public int Id { get; set; }
        [DataMember]
        public List<OrganizierTask> Tasks { get; set; }
        [DataMember]
        public string Comment { get; set; }
        [DataMember]
        public PartyRequest PartyRequest { get; set; }

        public Suggestion()
        {

        }

        public Suggestion(List<OrganizierTask> tasks, string comment, PartyRequest partyRequest)
        {
            Tasks = tasks;
            Comment = comment;
            PartyRequest = partyRequest;
        }
    }
}
