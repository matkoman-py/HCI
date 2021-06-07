using ReservationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem
{
    public interface IMainWindow
    {
        BaseViewModel SelectedViewModel { get; set; }
    }
}
