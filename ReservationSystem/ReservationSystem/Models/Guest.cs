using System.ComponentModel.DataAnnotations;

namespace ReservationSystem.Models
{
    public class Guest
    {
        private string v1;
        private string v2;

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Guest()
        {
        }

        public Guest(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
    }
}