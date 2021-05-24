using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Models
{

    public enum Role { Customer, Organizier, Administrator}

    [DataContract]
    public class User
    {
        [Key]
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        private string Username { get; set; }
        [DataMember]
        private string Password { get; set; }
        [DataMember]
        private string Email { get; set; }
        [DataMember]
        private string Name { get; set; }
        [DataMember]
        private string Surname { get; set; }
        [DataMember]
        private DateTime Birthday { get; set; }
        [DataMember]
        private Role Role { get; set; }

    }
}
