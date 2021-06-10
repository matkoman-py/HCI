using ReservationSystem.Models;
using ReservationSystem.ViewModels;
using ReservationSystem.ViewModels.Administrator;
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
    /// Interaction logic for AdminHomePage.xaml
    /// </summary>
    public partial class AdminHomePage : Window
    {
        public User User { get; set; }
        //public ICommand UpdateViewCommand { get; set; }

        public AdminHomePage(User user)
        {
            InitializeComponent();
            DataContext = new AdminHomePageViewModel(user);
            User = user;
        }
        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            if (((AdminHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(ProfileViewModel))
            {
                HelperModal hm = new HelperModal("/Static/profileHelp.png", "\n\t\t\tPregled profila\n\nNa ovoj stranici su prikazani vaši podaci koje ste uneli prilikom registracije.\nUkoliko želite da promenite neke od tih podataka pritisnite dugme \"Ažuriraj\npodatke\".\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
            if (((AdminHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(DataUpdateViewModel))
            {
                HelperModal hm = new HelperModal("/Static/dataupdateHelp.png", "\n\t\t\tAžuriranje profila\n\nKako bi izmenili podatake sa vašeg profila promenite tekst u željenim poljima\ni pritisnite dugme \"Sačuvaj\". Ukoliko se predomislite i želite da se vratite na\npregled profila bez menjanja vaših podataka pritisnite dugme \"Odustani\".\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
            if (((AdminHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(AdminAssociatesViewModel))
            {
                HelperModal hm = new HelperModal("/Static/AddAssociatesHelp.png", "\n\t\t\tPregled saradnika\n\nNa ovoj stranici prikazana je lista saradnika u sistemu. Ako želite da pretražite\nsaradnike unesite željeni upit u polje za pretragu i pritisnite dugme sa lupom.\nDodavanje novog saradnika se vrši pritiskom na dugme sa plusom a izmena\npritisom dugmeta sa olovkom u redu za željenog saradnika.\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
            if (((AdminHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(AdminFieldsOfWorkViewModel))
            {
                HelperModal hm = new HelperModal("/Static/addfieldofworkHelp.png", "\n\t\t\tPregled delatnosti\n\nNa ovoj stranici prikazana je lista delatnosti u sistemu. Ako želite da pretražite\ntipove delatnosti unesite željeni upit u polje za pretragu i pritisnite dugme\nsa lupom. Dodavanje novog tipa delatnosti se vrši pritiskom na dugme sa\nplusom nakon čeka se u tekstualno polje unosi naziv delatnosti. Izmena se vrši\npritisom dugmeta sa olovkom u redu redu željenog tipa delatnosti nakon\nčega se u isto polje unosi novi naziv delatnosti. Ako želite da delatnosti\ndodelite salu to možete uraditi pritiskom na polje sala pri kreaciji i izmeni,\nnakon čega će se pored delatnosti pojaviti slika stola. Brisanje delatnosti se\nvrši pritiskom na dugme sa kantom u redu željene delatnosti.\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
            if (((AdminHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(AdminPartyTypeViewModel))
            {
                HelperModal hm = new HelperModal("/Static/addpartytypeHelp.png", "\n\t\t\tPregled tipova proslava\n\nNa ovoj stranici prikazana je lista tipova proslava u sistemu. Ako želite da\npretražite  tipove proslava unesite željeni upit u polje za pretragu i pritisnite\ndugme sa lupom. Dodavanje novog tipa proslave se vrši pritiskom na dugme\nsa plusom nakon čeka se u tekstualno polje unosi naziv tipa. Izmena se vrši\npritisom dugmeta sa olovkom u redu redu željenog tipa proslave nakon čega\nse u isto polje unosi novi naziv tipa proslave. Brisanje tipa proslave se vrši\npritiskom na dugme sa kantom u redu željenog tipa.\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
            if (((AdminHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(AdminOrganizersOverviewModel))
            {
                HelperModal hm = new HelperModal("/Static/addorganizersHelp.png", "\n\t\t\tPregled organizatora\n\nNa ovoj stranici prikazana je lista organizatora u sistemu. Ako želite da\npretražite  organizatore unesite željeni upit u polje za pretragu i pritisnite\ndugme sa lupom.Dodavanje novog organizatora se započinje pritiskom na\ndugme sa plusom.\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
            if (((AdminHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(AddOrganizersViewModel))
            {
                HelperModal hm = new HelperModal("/Static/addorganizersdataHelp.png", "\n\t\t\tDodavanje organizatora\n\nKako bi uspešno dodali organizatora potrebno je popuniti sva polja sa\npodacima novog organizatora i pritisnuti dugme sa plusom, nakon čega će se\norganizator dodati u sistem. Ukoliko želite da odustanete od kreiranja\norganizatora pritisnite dugme sa slikom strelice ka levo.\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
            if (((AdminHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(AddAssociatesViewModel))
            {
                HelperModal hm = new HelperModal("/Static/AddAssociatesdataHelp.png", "\n\t\t\tKreiranje saradnika\n\nKako bi uspešno dodali saradnika potrebno je popuniti sva polja se podacima\nnovog saradnika i pritisnuti dugme \"Dodaj\", nakon čega će se saradnik\ndodati u sistem. Dodavanje nove ponude saradniku vrši se pritiskom na\ndugme \"Dodaj ponudu\". Ukoliko želite da odustanete od kreiranja saradnika\npritisnite dugme \"Odustani\".\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
            if (((AdminHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(AddOfferViewModel))
            {
                HelperModal hm = new HelperModal("/Static/addofferHelp.png", "\n\t\t\tKreiranje ponude\n\nKako bi uspešno dodali ponudu potrebno je popuniti sva polja se podacima\nponude i pritisnuti dugme \"Dodaj\", nakon čega će se ponuda dodati u sistem.\nUkoliko želite da odustanete od kreacije ponude pritisnite dugme \"Odustani\".\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
            if (((AdminHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(EditAssociatesViewModel))
            {
                HelperModal hm = new HelperModal("/Static/editAssociateHelp.png", "\n\t\t\tIzmena saradnika\n\nKako bi izmenili saradnika potrebno je izmeniti željena polja i pritisnuti\ndugme \"Izmeni\". Ukoliko želite da odustanete od izmene saradnika pritisnite\ndugme \"Odustani\".\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
            if (((AdminHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(EditOfferViewModel))
            {
                HelperModal hm = new HelperModal("/Static/editOfferHelp.png", "\n\t\t\tIzmena ponude\n\nKako bi izmenili ponudu potrebno je izmeniti željena polja i pritisnuti\ndugme \"Izmeni\". Ukoliko želite da odustanete od izmene ponude pritisnite\ndugme \"Odustani\".\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
            if (((AdminHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(AddRoomViewModel))
            {
                HelperModal hm = new HelperModal("/Static/tablesAdminHelp.png", "\n\t\t\tKreiranje sobe\n\nDa bi ste dodali sto u sobu najpre morate uneti broj stolica koji će sto sadržati\n.Dodavanje stola u sobu vrši se klikom na dugme sa plusom a brisanje stola\ndesnim klikom na sto. Stolovi se pomeraju stiskanjem levog klika miša i\nprevlačenjem na željenu lokaciju u sobi. Kada ste spremni da sačuvate sobu\npritisnite dugme \"Sačuvaj\". Ako želite da se vratite na prošlu stranicu\npritisnite dugme  \"Odustani\".\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
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
            //if (this.Cursor != Cursors.Wait)
            //    Mouse.OverrideCursor = Cursors.Hand;
        }

        private void GridSplitter_MouseLeave(object sender, RoutedEventArgs e)
        {
            //if (this.Cursor != Cursors.Wait)
            //    Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void MenuBar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedOption = ((ListViewItem)(sender as ListView).SelectedItem).Name;
            switch (selectedOption)
            {
                case "AssociateCRUD":
                    AdminHomePageViewModel.ToAssociatesCommand.Execute(User);
                    break;
                case "OrganizersCRUD":
                    AdminHomePageViewModel.ToOrganizersCommand.Execute(User);
                    break;
                case "FieldsOfWorkCRUD":
                    AdminHomePageViewModel.ToFieldsOfWorkCommand.Execute(User);
                    break;
                case "PartyTypeCRUD":
                    AdminHomePageViewModel.ToPartyTypesCommand.Execute(User);
                    break;
                case "MyProfile":
                    AdminHomePageViewModel.ProfileCommand.Execute(User);
                    break;
                default:
                    Application.Current.MainWindow.Show();
                    this.Close();
                    break;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.MainWindow.Show();
        }
    }
}
