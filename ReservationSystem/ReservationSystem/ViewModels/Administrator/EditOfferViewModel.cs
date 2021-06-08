﻿using ReservationSystem.Commands;
using ReservationSystem.Models;
using ReservationSystem.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReservationSystem.ViewModels.Administrator
{
    public class EditOfferViewModel : BaseViewModel
    {
        private ICommand UpdateViewCommand;
        public ICommand BackCommand { get; set; }
        public ICommand EditOfferCommand { get; set; }
        public Offer Offer { get; set; }

        public EditOfferViewModel(ICommand updateViewCommand, Offer offer)
        {
            UpdateViewCommand = updateViewCommand;
            BackCommand = new DelegateCommand(goToPastView);
            EditOfferCommand = new DelegateCommand(EditOffer);
            Offer = offer;
        }

        private void goToPastView()
        {
            var pastViewModel = ViewChangeUtils.PastViews.Pop();
            UpdateViewCommand.Execute(pastViewModel);
        }

        private void EditOffer()
        {
            using (var db = new ProjectDatabase())
            {
                try
                {
                    db.Entry(Offer).State = EntityState.Modified;
                    db.SaveChanges();
                    UpdateViewCommand.Execute(new EditAssociatesViewModel(UpdateViewCommand, Offer.Associate));
                }
                catch
                {
                    Console.WriteLine("Can't update offer!");
                }

            }
        }
    }
}