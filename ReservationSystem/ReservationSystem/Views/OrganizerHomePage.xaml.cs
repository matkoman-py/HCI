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
    /// Interaction logic for OrganizerHomePage.xaml
    /// </summary>
    public partial class OrganizerHomePage : Window
    {
        public User User { get; set; }

        public OrganizerHomePage(User user)
        {
            InitializeComponent();
            DataContext = new OrganizerHomePageViewModel(user);
            User = user;
        }

        private void GridSplitter_MouseEnter(object sender, RoutedEventArgs e)
        {
            if (this.Cursor != Cursors.Wait)
                Mouse.OverrideCursor = Cursors.Hand;
        }

        private void GridSplitter_MouseLeave(object sender, RoutedEventArgs e)
        {
            if (this.Cursor != Cursors.Wait)
                Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void MenuBar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedOption = ((ListViewItem)(sender as ListView).SelectedItem).Name;
            switch (selectedOption)
            {
                case "PartyRequests":
                    OrganizerHomePageViewModel.PartyRequestsSelectionTypeCommand.Execute(User);
                    break;
                case "AssociatesOverview":
                    OrganizerHomePageViewModel.AssociateOverviewCommand.Execute(User);
                    break;
                case "ActiveParties":
                    //ovde ga bacas na ono sto je mateja pravio poslednje
                    break;
                case "Profile":
                    OrganizerHomePageViewModel.ProfileCommand.Execute(User);
                    break;
                default:
                    Application.Current.MainWindow.Show();
                    this.Close();
                    break;
            }
        }
    }
}
