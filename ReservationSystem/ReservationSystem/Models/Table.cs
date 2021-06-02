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
        public int Id { get; set; }
        [DataMember]
        public int NumberOfSeats { get; set; }
        [DataMember]
        public Point TableCoordinates { get; set; }

        public Table(int numberOfSeats, Point tableCoordinates)
        {
            NumberOfSeats = numberOfSeats;
            TableCoordinates = tableCoordinates;
        }
    }
}
