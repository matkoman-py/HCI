using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace ReservationSystem.Models
{

    public enum FieldOfWork { Restaurant, Catering, Music, Other }

    [DataContract]
    public class Associate
    {
        [Key]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public FieldOfWork FieldOfWork { get; set; }
        [DataMember]
        public TablesArrangement TablesArrangement { get; set; }

        public Associate()
        {

        }

        public Associate(string name, string address, string description, FieldOfWork fieldOfWork, TablesArrangement tablesArrangement)
        {
            Name = name;
            Address = address;
            Description = description;
            FieldOfWork = fieldOfWork;
            TablesArrangement = tablesArrangement;
        }

    }
}
