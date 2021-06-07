using ReservationSystem.Commands;
using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace ReservationSystem.ViewModels.Administrator
{
    public class AdminFieldsOfWorkViewModel : BaseViewModel
    {

        private ICommand UpdateViewCommand;
        public ICommand AddFieldOfWorkCommand { get; set; }
        public ICommand ToEditFieldOfWorkCommand { get; set; }
        public ICommand EditFieldOfWorkCommand { get; set; }
        public ICommand CancelEditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        private ObservableCollection<FieldOfWork> fieldsOfWork;
        public ObservableCollection<FieldOfWork> FieldsOfWork 
        {
            get { return fieldsOfWork; }
            set 
            {
                fieldsOfWork = value;
                OnPropertyChanged("FieldsOfWork");
            }
        }
        public string SearchQuery { get; set; }

        private string newFieldOfWorkName;
        public string NewFieldOfWorkName 
        {
            get { return newFieldOfWorkName; }
            set 
            {
                newFieldOfWorkName = value;
                OnPropertyChanged("NewFieldOfWorkName");
            }
        }
        private FieldOfWork fieldOfWorkToEdit;
        public FieldOfWork FieldOfWorkToEdit
        {
            get { return fieldOfWorkToEdit; }
            set
            {
                fieldOfWorkToEdit = value;
                OnPropertyChanged("FieldOfWorkToEdit");
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

        public AdminFieldsOfWorkViewModel(ICommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
            AddFieldOfWorkCommand = new DelegateCommand(AddFieldOfWork);
            ToEditFieldOfWorkCommand = new DelegateCommand(SwitchToEditMode);
            EditFieldOfWorkCommand = new DelegateCommand(EditFieldOfWork);
            CancelEditCommand = new DelegateCommand(CancelEditMode);
            DeleteCommand = new DelegateCommand(Delete);
            SearchCommand = new DelegateCommand(Search);
            Search();
        }

        private ObservableCollection<FieldOfWork> getFieldsOfWork()
        {
            using (var db = new ProjectDatabase())
            {
                return new ObservableCollection<FieldOfWork>(db.FieldsOfWork.ToList());
            }
        }

        private void Search()
        {
            Console.WriteLine(String.IsNullOrEmpty(SearchQuery));
            if (String.IsNullOrEmpty(SearchQuery))
            {
                FieldsOfWork = getFieldsOfWork();
            }
            else 
            {
                using (var db = new ProjectDatabase())
                {
                    var results = db.FieldsOfWork.Where(field => field.Name.Contains(SearchQuery)).ToList();
                    FieldsOfWork = new ObservableCollection<FieldOfWork>(results);
                }
            }
        }

        private void AddFieldOfWork()
        {
            using (var db = new ProjectDatabase())
            {
                FieldOfWork fieldOfWork = new FieldOfWork { Name = NewFieldOfWorkName };
                db.FieldsOfWork.Add(fieldOfWork);
                db.SaveChanges();
                NewFieldOfWorkName = "";
                FieldsOfWork.Add(fieldOfWork);
            }
        }

        private void EditFieldOfWork() 
        {
            using (var db = new ProjectDatabase())
            {
                try
                {
                    db.Entry(FieldOfWorkToEdit).State = EntityState.Modified;
                    FieldOfWorkToEdit.Name = NewFieldOfWorkName;
                    db.SaveChanges();
                    CancelEditMode();
                }
                catch
                {
                    Console.WriteLine("Can't update field of work!");
                }
            }
        }

        private void CancelEditMode() 
        {
            IsInEditMode = false;
            NewFieldOfWorkName = "";
        }

        private Object SwitchToEditMode(Object fieldOfWork) 
        {
            IsInEditMode = true;
            FieldOfWorkToEdit = (FieldOfWork)fieldOfWork;
            NewFieldOfWorkName = FieldOfWorkToEdit.Name;
            return this;
        }

        private Object Delete(Object fieldOfWork) 
        {
            using (var db = new ProjectDatabase())
            {
                try
                {
                    var fieldOfWorkToDelete = (FieldOfWork)fieldOfWork;
                    fieldOfWorkToDelete = db.FieldsOfWork.Where(field => field.Id == fieldOfWorkToDelete.Id).FirstOrDefault();
                    Console.WriteLine(fieldOfWorkToDelete.Id);
                    Console.WriteLine(fieldOfWorkToDelete.Name);
                    db.FieldsOfWork.Remove(fieldOfWorkToDelete);
                    db.SaveChanges();
                    FieldsOfWork.Remove(fieldOfWork as FieldOfWork);
                }
                catch
                {
                    Console.WriteLine("Can't delete field of work!");
                }
            }
            return this;
        }

    }
}
