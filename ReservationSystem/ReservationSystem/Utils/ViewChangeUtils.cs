using ReservationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Utils
{
    public class ViewChangeUtils
    {
        private static Stack<BaseViewModel> pastViews;
        public static Stack<BaseViewModel> PastViews 
        {
            get 
            {
                if (pastViews == null) 
                {
                    pastViews = new Stack<BaseViewModel>();
                }
                return pastViews;
            }
            set 
            {
                pastViews = value;
            }
        }
    }
}
