﻿using System;
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
        public string Id { get; set; }
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

        [DataMember]
        public string UserApproval { get; set; }

        public OrganizierTask(string name, string description, List<Offer> offers, bool isDone, string comment, string userApproval)
        {
            Name = name;
            Description = description;
            SelectedOffers = offers;
            IsDone = isDone;
            Comment = comment;
            UserApproval = userApproval;
        }
    }
}
