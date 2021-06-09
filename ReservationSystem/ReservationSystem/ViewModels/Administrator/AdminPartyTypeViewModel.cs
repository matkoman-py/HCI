using ReservationSystem.Commands;
using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ReservationSystem.ViewModels.Administrator
{
    public class AdminPartyTypeViewModel : BaseViewModel
    {
        private ICommand UpdateViewCommand;
        public ICommand AddPartyTypeCommand { get; set; }
        public ICommand ToEditPartyTypeCommand { get; set; }
        public ICommand EditPartyTypeCommand { get; set; }
        public ICommand CancelEditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        private ObservableCollection<PartyType> partyTypes;
        public ObservableCollection<PartyType> PartyTypes
        {
            get { return partyTypes; }
            set
            {
                partyTypes = value;
                OnPropertyChanged("PartyTypes");
            }
        }
        public string SearchQuery { get; set; }

        private string newPartyTypeName;
        public string NewPartyTypeName
        {
            get { return newPartyTypeName; }
            set
            {
                newPartyTypeName = value;
                OnPropertyChanged("NewPartyTypeName");
            }
        }
        private PartyType partyTypeToEdit;
        public PartyType PartyTypeToEdit
        {
            get { return partyTypeToEdit; }
            set
            {
                partyTypeToEdit = value;
                OnPropertyChanged("PartyTypeToEdit");
            }
        }
        private bool isInEditMode;
        public bool IsInEditMode
        {
            get { return isInEditMode; }
            set
            {
                isInEditMode = value;
                OnPropertyChanged("IsInEditMode");
            }
        }

        public AdminPartyTypeViewModel(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
            AddPartyTypeCommand = new DelegateCommand(AddPartyType);
            ToEditPartyTypeCommand = new DelegateCommand(SwitchToEditMode);
            EditPartyTypeCommand = new DelegateCommand(EditPartyType);
            CancelEditCommand = new DelegateCommand(CancelEditMode);
            DeleteCommand = new DelegateCommand(Delete);
            SearchCommand = new DelegateCommand(Search);
            Search();
        }

        private ObservableCollection<PartyType> getPartyTypes()
        {
            using (var db = new ProjectDatabase())
            {
                return new ObservableCollection<PartyType>(db.PartyTypes.ToList());
            }
        }

        private void Search()
        {
            if (String.IsNullOrEmpty(SearchQuery))
            {
                PartyTypes = getPartyTypes();
            }
            else
            {
                using (var db = new ProjectDatabase())
                {
                    var results = db.PartyTypes.Where(type => type.Name.Contains(SearchQuery)).ToList();
                    PartyTypes = new ObservableCollection<PartyType>(results);
                }
            }
        }

        private void AddPartyType()
        {
            if (string.IsNullOrEmpty(NewPartyTypeName.Trim())){
                MessageBox.Show("Morate uneti ime za vrstu proslave!");
                return;
            }
            using (var db = new ProjectDatabase())
            {
                PartyType partyType = new PartyType { Name = NewPartyTypeName };
                db.PartyTypes.Add(partyType);
                db.SaveChanges();
                NewPartyTypeName = "";
                PartyTypes.Add(partyType);
            }
        }

        private void EditPartyType()
        {
            using (var db = new ProjectDatabase())
            {
                try
                {
                    db.Entry(PartyTypeToEdit).State = EntityState.Modified;
                    PartyTypeToEdit.Name = NewPartyTypeName;
                    db.SaveChanges();
                    CancelEditMode();
                }
                catch
                {
                    Console.WriteLine("Can't update type of work!");
                }
            }
        }

        private void CancelEditMode()
        {
            IsInEditMode = false;
            NewPartyTypeName = "";
        }

        private Object SwitchToEditMode(Object partyType)
        {
            IsInEditMode = true;
            PartyTypeToEdit = (PartyType)partyType;
            NewPartyTypeName = PartyTypeToEdit.Name;
            return this;
        }

        private Object Delete(Object partyType)
        {
            using (var db = new ProjectDatabase())
            {
                try
                {
                    var partyTypeToDelete = (PartyType)partyType;
                    partyTypeToDelete = db.PartyTypes.Where(type => type.Id == partyTypeToDelete.Id).FirstOrDefault();
                    Console.WriteLine(partyTypeToDelete.Id);
                    Console.WriteLine(partyTypeToDelete.Name);
                    db.PartyTypes.Remove(partyTypeToDelete);
                    db.SaveChanges();
                    PartyTypes.Remove(partyType as PartyType);
                }
                catch
                {
                    Console.WriteLine("Can't delete type!");
                }
            }
            return this;
        }

    }

}
