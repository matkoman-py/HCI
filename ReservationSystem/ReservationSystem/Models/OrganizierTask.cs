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
    [DataContract]
    public class OrganizierTask
    {
        [Key]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public virtual List<Offer> Offers { get; set; }
        [DataMember]
        public bool IsDone { get; set; }
        [DataMember]
        public string Comment { get; set; }

        public int SuggestionId { get; set; }
        public virtual Suggestion Suggestion { get; set; }
        public UserApproval UserApproval { get; set; }
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
