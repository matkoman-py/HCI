using ReservationSystem.Models;
using ReservationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReservationSystem.Views
{
    /// <summary>
    /// Interaction logic for PrendingRequestsOverview.xaml
    /// </summary>
    public partial class PendingRequestsOverview : UserControl
    {
        public PendingRequestsOverview()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PartyRequest myValue = (PartyRequest)((Button)sender).Tag;
            PendingRequestsViewModel.SelectedRequest = myValue;
            PendingRequestsViewModel.OfferReviewCommand.Execute(null);
        }
    }
}
