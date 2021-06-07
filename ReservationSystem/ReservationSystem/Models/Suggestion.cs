////using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Models
{
    public enum AnsweredType
    {
        Odbijen, Prihvacen, Neobradjen, Neprihvacen
    }
    public class Suggestion
    {
        [Key]
        public int Id { get; set; }
        
        
        public virtual List<OrganizierTask> OrganizierTasks { get; set; }

        public AnsweredType Answered { get; set; }
        public string Comment { get; set; }
        public double Price { get; set; }
        
        [ForeignKey("PartyRequest")]
        public int PartyRequestId { get; set; }
        public virtual PartyRequest PartyRequest { get; set; }

        public Suggestion()
        {

        }

        public Suggestion(List<OrganizierTask> tasks, string comment, PartyRequest partyRequest)
        {
            OrganizierTasks = tasks;
            Comment = comment;
            PartyRequest = partyRequest;
            Answered = AnsweredType.Neobradjen;
            Price = 0;

            foreach (OrganizierTask task in tasks)
            {
                foreach (Offer offer in task.Offers)
                {
                    Price += offer.Price;
                }
            }
        }
    }
}
