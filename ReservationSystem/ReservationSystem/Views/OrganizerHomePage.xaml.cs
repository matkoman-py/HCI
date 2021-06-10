﻿using ReservationSystem.Models;
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
        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            if (((OrganizerHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(ProfileViewModel))
            {
                HelperModal hm = new HelperModal("/Static/profileHelp.png", "\n\t\t\tPregled profila\n\nNa ovoj stranici su prikazani vaši podaci koje ste uneli prilikom registracije.\nUkoliko želite da promenite neke od tih podataka pritisnite dugme \"Ažuriraj\npodatke\".\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
            if (((OrganizerHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(DataUpdateViewModel))
            {
                HelperModal hm = new HelperModal("/Static/dataupdateHelp.png", "\n\t\t\tAžuriranje profila\n\nKako bi izmenili podatake sa vašeg profila promenite tekst u željenim poljima\ni pritisnite dugme \"Sačuvaj\". Ukoliko se predomislite i želite da se vratite na\npregled profila bez menjanja vaših podataka pritisnite dugme \"Odustani\".\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
            if (((OrganizerHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(PartyRequestTypeSelectionViewModel))
            {
                HelperModal hm = new HelperModal("/Static/requesttypeselection.png", "\n\t\t\tOdabir tipa proslave\n\nOdaberite tip proslava koje želite da pregledate pritiskom na određeno\ndugme.\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
            if (((OrganizerHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(RequestsOverviewViewModel))
            {
                HelperModal hm = new HelperModal("/Static/pendingrequestViewHelp.png", "\n\t\t\tPregled proslava\n\nKako bi videli detaljniji prikaz proslave pritisnite dugme \"Vidi više\". Ukoliko\nželite da se vratite na prethodnu stranicu pritisnite dugme \"Nazad\".\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
            if (((OrganizerHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(AcceptedSuggestionViewModel))
            {
                HelperModal hm = new HelperModal("/Static/activeRequestsHelp.png", "\n\t\t\tPregled prihvaćenih proslava\n\nKako bi videli detaljniji prikaz proslave pritisnite dugme \"Vidi više\".\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
            if (((OrganizerHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(AssociateOverviewViewModel))
            {
                HelperModal hm = new HelperModal("/Static/associatesOverviewHelp.png", "\n\t\t\tPregled saradnika\n\nOva stranica prikazuje listu saradnika u sistemu. Ako želite da dodate novog\nsaradnika pritisnite dugme \"Dodaj novog saradnika\". Ako želite saradniku da\ndodate novu ponudu izaberite saradnika iz tabele i potom pritisnite dugme\n\"Kreiraj novu ponudu za saradnika\".\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
            if (((OrganizerHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(CreateNewAssociateViewModel))
            {
                HelperModal hm = new HelperModal("/Static/addassociateHelp.png", "\n\t\t\tKreiranje saradnika\n\nUnesite željene podatke u odgovarajuća polja, zatim pritisnite dugme \"Kreiraj\nsaradnika\". Ako želite da odustanete od kreiranja saradnika pritisnite dugme\n\"Odustani\"\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
            if (((OrganizerHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(CreateNewOfferViewModel))
            {
                HelperModal hm = new HelperModal("/Static/addoffettoAssociate.png", "\n\t\t\tKreiranje ponude\n\nUnesite željene podatke u odgovarajuća polja, zatim pritisnite dugme \"Dodaj\".\nAko želite da odustanete od kreiranja ponude pritisnite dugme \"Odustani\"\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
            if (((OrganizerHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(AcceptedRequestOverviewViewModel))
            {
                HelperModal hm = new HelperModal("/Static/acceptedRequestHelp.png", "\n\t\t\tPregled prihvaćenog zahteva\n\nOva stranica detaljnije prikazuje prihvaćeni zahtev. Ako želite da vidite \npredlog za zahtev pritisnite dugme \"Pregled predloga\". Ako želite da se\nvratite na prošlu stranicu pritisnite dugme \"Nazad\".\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
            if (((OrganizerHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(SuggestionOverviewOrganizerViewModel))
            {
                HelperModal hm = new HelperModal("/Static/acceptedrequestsuggestionHelp.png", "\n\t\t\tPregled predloga\n\nOva stranica predstavlja detaljan pregled predloga za proslavu. Ako želite da\nvidite više informacija o zadacima od kojih se predlog sastoji pritisnite dugme\nsa imenom zadatka koji želite da vidite. Ako želite da se vratite na prošlu\nstranicu pritisnite dugme \"Nazad\".\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
            if (((OrganizerHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(ResolvedTaskOverviewViewModel))
            {
                HelperModal hm = new HelperModal("/Static/resolvedtaskoverviewHelp.png", "\n\t\t\tPregled zadatka\n\nOva stranica predstavlja detaljan pregled zadatka. Ako želite da vidite više \ninformacija o ponudama za predlog pritisnite dugme sa imenom ponude\nkoji želite da vidite. Ako želite da se vratite na prošlu stranicu pritisnite dugme\n\"Nazad\".\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
            if (((OrganizerHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(OfferReviewOrganizerViewModel))
            {
                HelperModal hm = new HelperModal("/Static/offerHelp.png", "\n\t\t\tPregled ponude\n\nOva stranica predstavlja detaljan pregled ponude. Ako želite da se vratite na\nprošlu stranicu pritisnite dugme \"Nazad\".\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
            if (((OrganizerHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(PendingRequestOverview))
            {
                HelperModal hm = new HelperModal("/Static/pendingreqHelp.png", "\n\t\t\tDetaljan pregled zahteva\n\nOva stranica prikazuje sve informacije o neobrađenom zahtevu. Da bi kreirali\npredlog za zahtev pritisnite dugme \"Kreiraj predlog\". Ako želite da odbijete\nzahtev pritisnite dugme \"Odbij zahtev\". Ako želite da se vratite na prošlu\nstranicu pritisnite dugme \"Nazad\".\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
            if (((OrganizerHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(CreateSuggestionViewViewModel))
            {
                HelperModal hm = new HelperModal("/Static/createSuggestionHelp.png", "\n\t\t\tKreiranje predloga\n\nKako bi kreirali novi predlog prvo morate napraviti zadatke za predlog. Da bi\nkreirali zadatak pritisnite dugme \"Novi zadatak\". Kada ste spremni da završite\nvaš predlog i prihvatite zahtev pritisnite dugme \"Prihvati zahtev\". Ako želite\nda prekinete kreiranje predloga pritisnite dugme \"Odustani\".\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
            if (((OrganizerHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(CreateTaskViewModel))
            {
                HelperModal hm = new HelperModal("/Static/createTaskHelp.png", "\n\t\t\tKreiranje zadatka\n\nDa bi ste uspešno kreirali novi zadatak za vaš predlog popunite sva polja i\npritisnite dugme \"Kreiraj\". Ako želite da se vratite na prošlu stranicu pritisnite\ndugme \"Nazad\".\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
            if (((OrganizerHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(ActiveRequestOverviewViewModel))
            {
                HelperModal hm = new HelperModal("/Static/activereqOverview.png", "\n\t\t\tDetaljan pregled zahteva\n\nOva stranica prikazuje sve informacije o aktivnom zahtevu. Ako želite da vidite\npredlog za ovu proslavu pritisnite dugme \"Pregled predloga\". Ako želite da se\nvratite na prošlu stranicu pritisnite dugme \"Nazad\".\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
            if (((OrganizerHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(SuggestionOverviewViewModel))
            {
                HelperModal hm = new HelperModal("/Static/activeReqSuggHelp.png", "\n\t\t\tPregled predloga\n\nPre nego što pošaljete ponudu najpre morate odgovoriti na svaki zadatak.\nKako bi odgovorili na zadatak pritisnite dugme sa imenom tog zadatka. Ako\nželite da se vratite na prošlu stranicu pritisnite dugme \"Nazad\".\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
            ////////////////////////////////////////////////////////////
            if (((OrganizerHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(ActiveTaskOverviewViewModel))
            {
                HelperModal hm = new HelperModal("/Static/activetaskhelp.png", "\n\t\t\tPregled zadatka\n\nDa bi se zatatak smatrao rešenim mora mu se dodeliti ponuda. Ponuda se\ndodeljuje tako što iz tabele pritiskom na red sa željenom ponudom i potom\npritiskom na dugme \"Dodaj\". Ako želite da se vratite na prošlu stranicu\npritisnite dugme \"Nazad\".\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
            if (((OrganizerHomePageViewModel)DataContext).SelectedViewModel.GetType() == typeof(DenyRequestViewViewModel))
            {
                HelperModal hm = new HelperModal("/Static/denyReqHelp.jpg", "\n\t\t\tOdbijanje zahteva\n\nAko ste sigurni da želite da odbijete zahtev pritisnite dugme \"Odustani\".\n Ako želite da se vratite na prošlu stranicu pritisnite dugme \"Nazad\".\n");
                hm.Topmost = true;
                hm.ShowDialog();
            }
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
                    OrganizerHomePageViewModel.AcceptedSuggestionOverviewCommand.Execute(User);
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
