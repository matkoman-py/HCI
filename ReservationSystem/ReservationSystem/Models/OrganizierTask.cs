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
        public List<Offer> SelectedOffers { get; set; }
        [DataMember]
        public bool IsDone { get; set; }
        [DataMember]
        public string Comment { get; set; }

        public OrganizierTask()
        {

        }

        public OrganizierTask(string name, string description, List<Offer> selectedOffers, bool isDone, string comment)
        {
            Name = name;
            Description = description;
            SelectedOffers = selectedOffers;
            IsDone = isDone;
            Comment = comment;
            UserApproval = userApproval;
        }
    }
}
