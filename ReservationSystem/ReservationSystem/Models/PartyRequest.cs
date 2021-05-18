using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Models
{

    public enum PartyType { Birthday, Anniversary, Other}

    public enum RequestState { Pending, Rejected, Accepted }


    public class PartyRequest
    {
        private PartyType PartyType { get; set; }
        private int Budget { get; set; }
        private String Place { get; set; }
        private DateTime Time { get; set; }
        private int Capacity { get; set; }
        private bool IsBudgetFlexible { get; set; }
        private String PartyTheme { get; set; }
        private String Description { get; set; }
        private RequestState RequestState { get; set; }

    }
}
