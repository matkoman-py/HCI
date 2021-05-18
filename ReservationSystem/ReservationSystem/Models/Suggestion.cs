using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Models
{
    public class Suggestion
    {
        private List<Task> Tasks { get; set; }
        private String Comment { get; set; }
        private PartyRequest Request { get; set; }  
    }
}
