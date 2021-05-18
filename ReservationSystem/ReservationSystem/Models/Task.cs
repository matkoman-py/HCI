using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Models
{
    public class Task
    {
        private String Name { get; set; }
        private String Description { get; set; }
        private List<Offer> SelectedOffers { get; set; }
        private bool IsDone { get; set; }
        private String Comment { get; set; }
    }
}
