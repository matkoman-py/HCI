﻿using ReservationSystem.Commands;
using ReservationSystem.Models;
using ReservationSystem.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace ReservationSystem.ViewModels.Administrator
{
    public class AddAssociatesViewModel : BaseViewModel
    {
        private ICommand UpdateViewCommand;
        public ICommand AddAssociatesCommand { get; set; }
        public ICommand AddOfferCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public Associate Associate { get; set; }
        public List<FieldOfWork> FieldOfWorkOptions { get; set; }

        public AddAssociatesViewModel(ICommand updateViewCommand)
        {
            Setup(updateViewCommand);
            Associate = new Associate();
        }

        public AddAssociatesViewModel(ICommand updateViewCommand, Associate associate)
        {
            Setup(updateViewCommand);
            Associate = associate;
        }

        private void Setup(ICommand updateViewCommand) 
        {
            UpdateViewCommand = updateViewCommand;
            using (var db = new ProjectDatabase()) 
            {
                FieldOfWorkOptions = db.FieldsOfWork.ToList();
            }
            AddAssociatesCommand = new DelegateCommand(AddAssociates);
            AddOfferCommand = new DelegateCommand(AddOffer);
            DeleteCommand = new DelegateCommand(Delete);
            BackCommand = new DelegateCommand(() => UpdateViewCommand.Execute(new AdminAssociatesViewModel(UpdateViewCommand)));
        }

        private void AddOffer()
        {
            ViewChangeUtils.PastViews.Push(this);
            UpdateViewCommand.Execute(new AddOfferViewModel(UpdateViewCommand, Associate));
        }

        private void AddAssociates() 
        {
            using (var db = new ProjectDatabase())
            {
                try
                {
                    db.FieldsOfWork.Attach(Associate.FieldOfWork);
                    db.Associates.Add(Associate);
                    db.SaveChanges();
                    UpdateViewCommand.Execute(new AdminAssociatesViewModel(UpdateViewCommand));
                }
                catch
                {
                    Console.WriteLine("Can't add associate!");
                }

            }
        }
        private Object Delete(Object offer)
        {
            var offerToDelete = (Offer)offer;
            Associate.Offers.Remove(Associate.Offers.Where(offerTemp => offerTemp.Id == offerToDelete.Id).First());
            Associate.Offers = new List<Offer>(Associate.Offers);

            return this;
        }
    }
}