using ReservationSystem.Commands;
using ReservationSystem.Models;
using ReservationSystem.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReservationSystem.ViewModels
{
    public class TableArrangementViewModel : BaseViewModel
    {
        public static ICommand RemoveGuestListCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand UpdateViewCommand { get; set; }
        public Offer SelectedOffer { get; set; }
        public OrganizierTask OrganizierTask { get; set; }
        public TablesArrangement TablesArrangement { get; set; }
        public Suggestion Suggestion { get; set; }
        public ObservableCollection<Guest> Guests { get; set; }

        private ProjectDatabase db = new ProjectDatabase();

        public TableArrangementViewModel(ICommand updateViewCommand, Offer selectedOffer, OrganizierTask organizierTask)
        {
            UpdateViewCommand = updateViewCommand;
            RemoveGuestListCommand = new DelegateCommand(RemoveGuestList);
            BackCommand = new DelegateCommand(GoBack);
            SaveCommand = new DelegateCommand(Save);
            SelectedOffer = selectedOffer;
            OrganizierTask = organizierTask;
            Suggestion = GetSuggestionWithGuests(organizierTask);
            CopyTableArrangement();
            Guests = new ObservableCollection<Guest>(Suggestion.PartyRequest.Guests);
        }

        private Suggestion GetSuggestionWithGuests(OrganizierTask organizierTask) 
        {

               return db.Suggestions
                    .Include("PartyRequest.Guests")
                    .Where(sug => sug.Id == organizierTask.SuggestionId)
                    .FirstOrDefault();
        }

        private void GoBack() 
        {
            UpdateViewCommand.Execute(new ActiveTaskOverviewViewModel(UpdateViewCommand, OrganizierTask));
        }

        private void Save()
        { 

            for (int i = 0; i < TablesArrangement.Tables.Count; i++)
            {
                TablesArrangement.Tables[i] = db.Tables.Add(TablesArrangement.Tables[i]);
                TablesArrangement.Tables[i].Guests = GetTableGuests(db, TablesArrangement.Tables[i]);
            }

            db.TablesArrangements.Add(TablesArrangement);
            OrganizierTask.TablesArrangement = TablesArrangement;
            var organizierTaskToSave = db.OrganizierTasks.Find(OrganizierTask.Id);
            organizierTaskToSave.TablesArrangement = OrganizierTask.TablesArrangement;

            var offerToSave = db.Offers.Find(SelectedOffer.Id);
            organizierTaskToSave.Offers.Add(offerToSave);
            db.SaveChanges();

            OrganizierTask.Offers = new List<Offer>(organizierTaskToSave.Offers);
            UpdateViewCommand.Execute(new ActiveTaskOverviewViewModel(UpdateViewCommand, OrganizierTask));
        }

        private List<Guest> GetTableGuests(ProjectDatabase db, Table table) 
        {
            List<Guest> guests = new List<Guest>();
            foreach (var guest in table.Guests) 
            {
                guests.Add(db.Guests.Find(guest.Id));
            }
            return guests;
        }

        private Object RemoveGuestList(Object obj) 
        {
            Guest guest = (Guest)obj;
            Guests.Remove(guest);
            return guest;
        }

        private void CopyTableArrangement() 
        {
            TablesArrangement OriginalTablesArrangement = null; 
            {
                OriginalTablesArrangement = db.TablesArrangements
                    .Include("Tables")
                    .Include("Tables.TableCoordinates")
                    .Where(tarr => tarr.Id == SelectedOffer.TablesArrangementId)
                    .FirstOrDefault();
            }
            TablesArrangement = new TablesArrangement();
            foreach (var originalTable in OriginalTablesArrangement.Tables) 
            {
                var originalTableCoordinates = originalTable.TableCoordinates;
                Point coordiantes = new Point() { X = originalTableCoordinates.X, Y = originalTableCoordinates.Y };
                var newTable = new Table() { TableCoordinates = coordiantes, NumberOfSeats = originalTable.NumberOfSeats};
                TablesArrangement.Tables.Add(newTable);
            }
        }
    }
}
