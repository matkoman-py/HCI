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
        public string Id { get; set; }
        [DataMember]
        private string Name { get; set; }
        [DataMember]
        private string Address { get; set; }
        [DataMember]
        private string Description { get; set; }
        [DataMember]
        private FieldOfWork FieldOfWork { get; set; }
        [DataMember]
        private TablesArrangement TablesArrangement { get; set; }

    }
}
