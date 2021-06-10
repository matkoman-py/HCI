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
            //if (this.Cursor != Cursors.Wait)
            //    Mouse.OverrideCursor = Cursors.Hand;
        }

        private void GridSplitter_MouseLeave(object sender, RoutedEventArgs e)
        {
            //Console.WriteLine("LEave");
            //if (this.Cursor != Cursors.Wait)
            //    Mouse.OverrideCursor = Cursors.Arrow;
        }
        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (((UserHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(ProfileViewModel))
            {
                HelperModal hm = new HelperModal("/Static/profileHelp.png", "\n\t\t\tPregled profila\n\nNa ovoj stranici su prikazani vaši podaci koje ste uneli prilikom registracije.\nUkoliko želite da promenite neke od tih podataka pritisnite dugme \"Ažuriraj\npodatke\".\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
            else if (((UserHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(DataUpdateViewModel))
            {
                HelperModal hm = new HelperModal("/Static/dataupdateHelp.png", "\n\t\t\tAžuriranje profila\n\nKako bi izmenili podatake sa vašeg profila promenite tekst u željenim poljima\ni pritisnite dugme \"Sačuvaj\". Ukoliko se predomislite i želite da se vratite na\npregled profila bez menjanja vaših podataka pritisnite dugme \"Odustani\".\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
            else if (((UserHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(RequesCreationViewModel))
            {
                HelperModal hm = new HelperModal("/Static/requestcreationHelp.png", "\n\t\t\tKreiranje zahteva za proslavu\n\nKako bi uspešno kreirali zahtev za proslavu popunite sva polja na ovoj\nstranici u zavisnosti od vaših želja i potreba. Nakon uspešnog ispunjavanja\nsvih polja pređite na stranicu za odabir organizatora vaše proslave pritiskom\nna dugme \"Kreiraj zahtev\". Ako želite da ubacite goste na vašu proslavu\npritisnite dugme \"Ubaci goste\".\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
            else if (((UserHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(ChooseOrganisatorPageViewModel))
            {
                HelperModal hm = new HelperModal("/Static/chooseorganisierHelp.png", "\n\t\t\tOdabir organizatora\n\nKako bi dovršili vaš zahtev morate klikom na red iz tabele odabrati\norganizatora vaše proslave. Nakon što ste kliknuli na željenog organizatora\nred u tabeli u kojoj se on nalazi će promeniti boju. Ako ste sigurni u vaš\nodabir pritisnite dugme \"Završi zahtev\" da sačuvate vašu proslavu. Ukoliko\nželite da pretražite listu organizatora jednostavno popunite polje iznad liste\ni pritisnite \"Pretraži\" dugme.\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
            else if (((UserHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(PendingRequestsViewModel))
            {
                HelperModal hm = new HelperModal("/Static/pendingrequestovervirewHelp.jpg", "\n\t\t\tZahtevi na čekanju\n\nZahtevi za proslave na ovoj stranici još uvek čekaju na obradu. Svaka kartica\nprikazuje osnovne informacije o određenom zahtevu za proslavu. Za detaljniji\nprikaz proslave pritisnitedugme \"Vidi više\".\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
            else if (((UserHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(PreviousPartiesViewModel))
            {
                HelperModal hm = new HelperModal("/Static/previouspartyHelp.png", "\n\t\t\tIstorija zahteva\n\nZahtevi za proslave na ovoj stranici su već prošli. Svaka kartica prikazuje\nosnovne informacije o određenom zahtevu za proslavu. Za detaljniji prikaz\nproslave pritisnite dugme \"Vidi više\".\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
            else if (((UserHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(RequestOverviewViewModel))
            {
                HelperModal hm = new HelperModal("/Static/moreinfoHelp.png", "\n\t\t\tDetaljan pregled zahteva\n\nNa ovoj stranici možete videti sve informacije vezane za izabrani zahtev.\nUkoliko je zahtev obradjen takođe će te videti i predlog za proslavu, pritisnite\ndugme sa nazivom predloga ako želite da vidite predlog koji odgovara\nizabranoj proslavi. Ako želite da sevratite na prethodnu stranicu pritisnite\ndugme \"Nazad\".\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
            else if (((UserHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(RequestViewViewModel))
            {
                HelperModal hm = new HelperModal("/Static/requestViewHelp.png", "\n\t\t\tPregled predloga\n\nNa ovoj stranici možete videti zadatke od kojih se sastoji predlog za proslavu\nkao i njihov status. Pritiskom na dugme sa imenom zadatka prelazi se na\nstranicu za detaljniji prikaz zadatka. Ukoliko je zahtev za proslavu obrađen ali i\ndalje nije dat odgovor na predlog na dnu ekrana će se prikazati i dugme\n\"Pošalji odgovor na predlog\". Pre nego što pritisnete ovo dugme morate prvo\nodgovoriti na svaki od prethodno pomenutih zadataka. Pritiskom na ovo\ndugme prihvatate/odbijate predlog i proslava prelazi u aktivno stanje. Ako pri\npredaji želite da ostavite komentar samo unesite željeni tekst u polje komentar neposredno iznad dugmeta.\nAko želite da se vratite na prethodnu stranicu pritisnite dugme \"Nazad\".\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
            else if (((UserHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(NewSuggestionsViewModel))
            {
                HelperModal hm = new HelperModal("/Static/suggestionsViewHelp.png", "\n\t\t\tZahtevi sa novim predlozima\n\nNa ovoj stranici prikazuju se zahtevi za proslave sa novim predlozima. Svaka\nkartica prikazuje osnovne informacije o određenom zahtevu za proslavu. Za\ndetaljniji prikaz proslave pritisnite dugme \"Vidi više\".\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
            else if (((UserHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(TaskOverviewViewModel))
            {
                HelperModal hm = new HelperModal("/Static/taskOverviewHelp.png", "\n\t\t\tPregled predloga\n\nNa ovoj stranici možete videti naziv, opis, komentar kao i ponude za zadatak\nkoji ste odabrali. Pritiskom na dugme možete videti detaljniji prikaz određene\nponude. Ako je zadatak na koji ste izabrali neobradjen na dnu stranice će vam\nbiti prikazani dugmići \"Odbij\" i \"Prihvati\" pritiskom na neki od ova dva\ndugmića status zadatka se menja u odbijen/prihvaćen i prelazi se na\nprethodnu stranicu.Ako želite da se vratite na prethodnu stranicu pritisnite\ndugme \"Nazad\".\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
            else if (((UserHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(OfferReviewPageViewModel))
            {
                HelperModal hm = new HelperModal("/Static/offerOverviewHelp.png", "\n\t\t\tPregled ponude\n\nNa ovoj stranici možete videti cenu, opis kao i ime saradnika koji je kreirao\nponudu. Ako želite da se vratite na prethodnu stranicu pritisnite dugme\n\"Nazad\".\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }//upcomingHelp
            else if (((UserHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(FuturePartiesViewModel))
            {
                HelperModal hm = new HelperModal("/Static/upcomingHelp.png", "\n\t\t\tPredstojeće proslave\n\nNa ovoj stranici prikazuju se proslave koje tek treba da se održe.\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
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
                case "CreateNewRequest":
                    UserHomePageViewModel.RequestCreationCommand.Execute(User);
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

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.MainWindow.Show();
        }
    }
}
