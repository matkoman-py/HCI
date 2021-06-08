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
using System.Windows.Shapes;

namespace ReservationSystem.Views
{
    /// <summary>
    /// Interaction logic for TaskOverview.xaml
    /// </summary>
    public partial class TaskOverview : UserControl
    {
        public TaskOverview()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Offer myValue = (Offer)((Button)sender).Tag;
            TaskOverviewViewModel.ToGoOffer = myValue;
            TaskOverviewViewModel.OfferReviewCommand.Execute(null);
        }
    }
}
