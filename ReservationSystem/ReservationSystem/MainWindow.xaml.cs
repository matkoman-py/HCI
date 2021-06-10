using ReservationSystem.ViewModels;
using ReservationSystem.Views;
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

namespace ReservationSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel();
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            
            if(((MainViewModel)DataContext).SelectedViewModel.GetType() == typeof(LoginViewModel))
            {
                
                HelperModal hm = new HelperModal("/Static/LoginHelp.png", "\n\t\t\tProzor za logovanje\n\n Da bi ste se ulogovali unesite vaše korisničko ime i šifru i potom pritisnite \n\"Uloguj se\" dugme. Ako još uvek niste registrovani pritisnite \"Registruj se\" \nkako bi kreirali vaš profil.\n");
                hm.ShowDialog();

            }
            if (((MainViewModel)DataContext).SelectedViewModel.GetType() == typeof(RegistrationViewModel))
            {
                
                HelperModal hm = new HelperModal("/Static/registrationHelp.png", "\n\t\t\tProzor za registraciju\n\n Da bi ste se uspešno registrovali morate popuniti sva polja sa vašim ličnim\n podacima potom pritisnite \"Registruj se\"dugme. Ako neki od unetih podataka\nnisu ispravni ispravite ih i pokušajte ponovo. Ukoliko želite da se vratite na\nstranicu za logovanje pritisnite dugme \"Nazad\".\n");
                hm.ShowDialog();
            }
        }
    }
}