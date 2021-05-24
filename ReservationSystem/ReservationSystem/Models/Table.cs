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
    public class Table
    {
        [Key]
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        private int NumberOfSeats { get; set; }
        [DataMember]
        private Point TableCoordinates { get; set; }
    }
}
