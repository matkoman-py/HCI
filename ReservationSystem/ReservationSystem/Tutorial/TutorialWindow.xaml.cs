﻿using ReservationSystem.Models;
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
using System.Windows.Shapes;

namespace ReservationSystem.Tutorial
{
    /// <summary>
    /// Interaction logic for TutorialWindow.xaml
    /// </summary>
    public partial class TutorialWindow : Window
    {
        public User User { get; set; }
        public Window Window { get; set; }

        public TutorialWindow(User user, Window window, Type currentViewModelType)
        {
            InitializeComponent();
            User = user;
            Window = window;
            DataContext = new TutorialViewModel(currentViewModelType);

        }

        private void EndTutorial(object sender, RoutedEventArgs e)
        {
            Window.Show();
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Window.Show();
        }
    }
}
