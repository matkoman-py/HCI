using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Models
{

    public enum Role { Customer, Organizier, Administrator}

    public class User
    {
        private String Username { get; set; }
        private String Password { get; set; }
        private String Email { get; set; }
        private String Name { get; set; }
        private String Surname { get; set; }
        private DateTime Birthday { get; set; }
        private Role Role { get; set; }

    }
}
