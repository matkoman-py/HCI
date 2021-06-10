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

    public enum Role { Customer, Organizier, Administrator}

    public class User
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        
        public DateTime Birthday { get; set; }
        [Required]
        public Role Role { get; set; }
        public string PhoneNumber { get; set; }

        public User()
        {

        }

        public User(string username, string password, string email, string name, string surname, DateTime birthday, Role role)
        {
            Username = username;
            Password = password;
            Email = email;
            Name = name;
            Surname = surname;
            Birthday = birthday;
            Role = role;
        }

        public User(User user)
        {
            Username = user.Username;
            Password = user.Password;
            Email = user.Email;
            Name = user.Name;
            Surname = user.Surname;
            Birthday = user.Birthday;
            Role = user.Role;
        }
    }
}
