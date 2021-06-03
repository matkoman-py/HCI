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
    
    public class Suggestion
    {
        [Key]
        public int Id { get; set; }
        
        public List<OrganizierTask> Tasks { get; set; }
        
        public string Comment { get; set; }
        
        [ForeignKey("PartyRequest")]
        public int PartyRequestId { get; set; }
        public virtual PartyRequest PartyRequest { get; set; }

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
