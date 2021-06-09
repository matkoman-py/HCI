using ReservationSystem.Commands;
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
        public ICommand EditRoomCommand { get; set; }
        public ICommand EditOfferCommand { get; set; }
        public Offer Offer { get; set; }

        private string name;
        public string Name 
        {
            get { return name; }
            set 
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private string description;
        public string Description 
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

        private int price;
        public int Price 
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }
        
        private string Mode;

        public EditOfferViewModel(ICommand updateViewCommand, Offer offer, String mode)
        {
            Mode = mode;
            UpdateViewCommand = updateViewCommand;
            BackCommand = new DelegateCommand(goToPastView);
            EditRoomCommand = new DelegateCommand(goToEditRoomView);
            EditOfferCommand = new DelegateCommand(EditOffer);
            Offer = offer;
            Name = Offer.Name;
            Price = Offer.Price;
            Description = Offer.Description;
        }

        private void goToPastView()
        {
            Offer.TablesArrangement = null;
            var pastViewModel = ViewChangeUtils.PastViews.Pop();
            UpdateViewCommand.Execute(pastViewModel);
        }

        private void goToEditRoomView()
        {
            ViewChangeUtils.PastViews.Push(this);
            UpdateViewCommand.Execute(new EditRoomViewModel(UpdateViewCommand, Offer));
        }

        private void SaveRoom(ProjectDatabase db, TablesArrangement currentTableArr) 
        {
            
            if (currentTableArr == null) 
            {
                return;
            }

            var dbTableArr = db.TablesArrangements
                .Include("Tables")
                .Where(tableArr => tableArr.Id == Offer.TablesArrangementId)
                .FirstOrDefault();

            List<Table> tablesToDelete = new List<Table>(dbTableArr.Tables);

            foreach (var table in tablesToDelete)
            {
                db.Tables.Remove(table);
            }


            foreach (var table in currentTableArr.Tables)
            {
                table.Id = 0;
                var newTable = db.Tables.Add(table);
                dbTableArr.Tables.Add(newTable);
            }

            Offer.TablesArrangement = dbTableArr;
            
            db.Entry(Offer.TablesArrangement).State = EntityState.Modified;
        }

        private TablesArrangement GetEditedTablesArrangement() 
        {
            try
            {
                return Offer.TablesArrangement;
            }
            catch (ObjectDisposedException e)
            {
                return null;
            }
            
        }

        private void EditOffer()
        {
            if (Mode == "Add")
            {
                Offer.Name = Name;
                Offer.Description = Description;
                Offer.Price = Price;
                UpdateViewCommand.Execute(ViewChangeUtils.PastViews.Pop());
            }
            using (var db = new ProjectDatabase())
            {
                try
                {
                    var tarr = GetEditedTablesArrangement();
                    Offer.TablesArrangement = null;
                    
                    db.Entry(Offer).State = EntityState.Modified;
                    
                    Offer.Name = Name;
                    Offer.Description = Description;
                    Offer.Price = Price;

                    if (Offer.IsRoom) 
                    {
                        SaveRoom(db, tarr);
                    }

                    db.SaveChanges();
                    UpdateViewCommand.Execute(ViewChangeUtils.PastViews.Pop());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Can't update offer!");
                }

            }
        }
    }
}
