using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Models
{

    public enum FieldOfWork { Restaurant, Catering, Music, Other }

    public class Associate
    {
        private String Name { get; set; }
        private String Address { get; set; }
        private String Description { get; set; }
        private FieldOfWork FieldOfWork { get; set; }
        private TablesArrangement TablesArrangement { get; set; }

    }
}
