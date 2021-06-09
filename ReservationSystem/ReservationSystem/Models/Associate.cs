using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace ReservationSystem.Models
{
    public class Associate : AbstractModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int FieldOfWorkId { get; set; }
        public FieldOfWork FieldOfWork { get; set; }
        private ICollection<Offer> offers;
        public virtual ICollection<Offer> Offers 
        {
            get { return offers; }
            set 
            {
                offers = value;
                OnPropertyChanged("Offers");
            }
        }

        public Associate()
        {
            Offers = new List<Offer>();
        }

        public Associate(string name, string address, string description, FieldOfWork fieldOfWork)
        {
            Name = name;
            Address = address;
            Description = description;
            FieldOfWork = fieldOfWork;
        }

    }
}
