﻿using ReservationSystem.ViewModels;
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
                
                HelperModal hm = new HelperModal("/Static/LoginHelp.png", "\tProzor za logovanje\n Unesite vaše korisničko ime i šifru i pritisnite \"Uloguj se\" dugme\n Ako niste registrovani pritisnite \"Registruj se\"");
                hm.ShowDialog();

            }
            if (((MainViewModel)DataContext).SelectedViewModel.GetType() == typeof(RegistrationViewModel))
            {
                
                HelperModal hm = new HelperModal("/Static/registrationHelp.png", "opsi");
                hm.ShowDialog();
            }
        }
    }
}