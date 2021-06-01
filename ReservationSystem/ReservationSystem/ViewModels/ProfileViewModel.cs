﻿using ReservationSystem.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReservationSystem.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        public ICommand UpdateViewCommand { get; set; }
        public ICommand UserHomePageCommand
        {
            get; set;
        }
        public ICommand DataUpdateCommand
        {
            get; set;
        }
        
        public ProfileViewModel(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
            UserHomePageCommand = new DelegateCommand(UserHomePage);
            DataUpdateCommand = new DelegateCommand(DataUpdate);
        }


        public void UserHomePage()
        {
            UpdateViewCommand.Execute("UserHomePage");
        }

        public void DataUpdate()
        {
            UpdateViewCommand.Execute("DataUpdate");
        }
    }
}