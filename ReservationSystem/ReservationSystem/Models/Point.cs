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
    public class Point
    {
        [Key]
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        private int X { get; set; }
        [DataMember]
        private int Y { get; set; }
    }
}
