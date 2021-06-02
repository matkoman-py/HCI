﻿using System;
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
        public int Id { get; set; }
        [DataMember]
        public  string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public DateTime Birthday { get; set; }
        [DataMember]
        public Role Role { get; set; }

        public User(string username, string password, string name, string surname, DateTime birthday, Role role)
        {
            Username = username;
            Password = password;
            Name = name;
            Surname = surname;
            Birthday = birthday;
            Role = role;
        }
    }
}
