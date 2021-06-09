using System.ComponentModel.DataAnnotations;

namespace ReservationSystem.Models
{
    public class Guest
    {   
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Guest()
        {
        }

        public Guest(int id, string name, string surname)
        {
            Id = id;
            Name = name;
            Surname = surname;
        }
    }
}