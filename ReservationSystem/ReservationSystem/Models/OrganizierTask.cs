using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Models
{
    public enum UserApproval
    {
        Neobradjen, Odbijen, Prihvacen
    }
    public class OrganizierTask
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Offer> Offers { get; set; }
        public bool IsDone { get; set; }
        public string Comment { get; set; }
        public int SuggestionId { get; set; }
        public virtual Suggestion Suggestion { get; set; }
        public UserApproval UserApproval { get; set; }
        public int? TablesArrangementId { get; set; }
        public TablesArrangement TablesArrangement { get; set; }

        public int SelectedOfferId { get; set; }
        public OrganizierTask()
        {

        }

        public OrganizierTask(string name, string description, List<Offer> selectedOffers, bool isDone, string comment, UserApproval userApproval)
        {
            Name = name;
            Description = description;
            Offers = selectedOffers;
            IsDone = isDone;
            Comment = comment;
            UserApproval = userApproval;
        }
    }
}
