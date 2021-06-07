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
    /// Interaction logic for UserHomePage.xaml
    /// </summary>
    public partial class UserHomePage : Window
    {

        //private static Grid Container;

        public User User { get; set; }
        //public ICommand UpdateViewCommand { get; set; }

        public UserHomePage(User user)
        {
            InitializeComponent();
            DataContext = new UserHomePageViewModel(user);
            User = user;
        }
        /*    Container = this.UserHomePageContainer;
        }

        public void changeView(UserControl userControl)
        {
            Container.Children.Clear();
            Container.Children.Add(userControl);
        }

        public static Grid getCurrentView()
        {
            return Container;
        }*/

        private void hideMenuButton_Click(object sender, RoutedEventArgs e)
        {
            hideMenuButton.Visibility = Visibility.Collapsed;
            showMenuButton.Visibility = Visibility.Visible;
        }

        private void showMenuButton_Click(object sender, RoutedEventArgs e)
        {
            showMenuButton.Visibility = Visibility.Collapsed;
            hideMenuButton.Visibility = Visibility.Visible;
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
                case "ScheduledParties":
                    //FuturePartiesViewModel futurePartiesViewModel = new FuturePartiesViewModel(User);
                    UserHomePageViewModel.FuturePartiesCommand.Execute(User);
                    break;
                case "PartySuggestions":
                    UserHomePageViewModel.NewSuggestionsCommand.Execute(User);
                    break;
                case "PendingRequests":
                    UserHomePageViewModel.PendingRequestsCommand.Execute(User);
                    break;
                case "PreviousParties":
                    UserHomePageViewModel.PreviousPartiesCommand.Execute(User);
                    break;
                case "MyProfile":
                    UserHomePageViewModel.ProfileCommand.Execute(User);
                    break;
                default:
                    Application.Current.MainWindow.Show();
                    this.Close();
                    break;
            }
        }
    }
}
