using ReservationSystem.Commands;
using ReservationSystem.Models;
using ReservationSystem.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace ReservationSystem.ViewModels.Administrator
{
    class AddRoomViewModel : BaseViewModel
    {
        private ICommand UpdateViewCommand;
        public ICommand AddTableCommand { get; set; }
        public static ICommand RemoveTableCommand { get; set; }
        public static ICommand SaveTablesCommand { get; set; }
        public static ICommand CancelCommand { get; set; }
        private Offer Offer { get; set; }
        private Associate associate;
        
        private int newNumberOfSeats { get; set; }
        public int NewNumberOfSeats 
        {
            get { return newNumberOfSeats; }
            set
            {
                newNumberOfSeats = value;
                OnPropertyChanged("NewNumberOfSeats");
            }
        }
        public ObservableCollection<Table> Tables
        {
            get;
            set;
        }

        public AddRoomViewModel(ICommand updateViewCommand, Associate associate, Offer offer)
        {
            UpdateViewCommand = updateViewCommand;
            AddTableCommand = new DelegateCommand(AddTable);
            RemoveTableCommand = new DelegateCommand(RemoveTable);
            SaveTablesCommand = new DelegateCommand(SaveTables);
            CancelCommand = new DelegateCommand(Cancel);
            Offer = offer;
            this.associate = associate;
            Tables = new ObservableCollection<Table>();
            Console.WriteLine(Tables.Count);
        }

        private Object RemoveTable(Object obj) 
        {
            var table = (Table)obj;
            Tables.Remove(table);
            return null;
        }

        private bool CheckIfTablesCollide(Table a, Table b) 
        {
            Point aCoordinatesLeft = a.TableCoordinates;
            Point aCoordinatesRight = new Point() { X = aCoordinatesLeft.X + 70, Y = aCoordinatesLeft.Y + 70 };
            Point bCoordinatesLeft = b.TableCoordinates;
            Point bCoordinatesRight = new Point() { X = bCoordinatesLeft.X + 70, Y = bCoordinatesLeft.Y + 70 };

            if (aCoordinatesLeft.X >= bCoordinatesRight.X || bCoordinatesLeft.X >= aCoordinatesRight.X) 
            {
                return false;
            }

            if (aCoordinatesLeft.Y >= bCoordinatesRight.Y || bCoordinatesLeft.Y >= aCoordinatesRight.Y)
            {
                return false;
            }

            return true;
        }

        private bool CheckAllTablesForCollisions() 
        {
            bool flag = false;
            for (int i = 0; i < Tables.Count - 1; ++i) 
            {
                for (int j = i + 1; j < Tables.Count; ++j)
                {
                    if (CheckIfTablesCollide(Tables.ElementAt(i), Tables.ElementAt(j)))
                    {
                        flag = true;
                        Tables.ElementAt(i).HasCollision = true;
                        Tables.ElementAt(j).HasCollision = true;
                    }
                }
            }
            return flag;
        }

        private void ResetCollsionStates() 
        {
            foreach(var table in Tables)
            {
                table.HasCollision = false;
            }
        }

        private void SaveTables() 
        {
            ResetCollsionStates();
            if (CheckAllTablesForCollisions())
            {
                Console.WriteLine("Neka poruka za sutra!!!");
                return;
            }
            else 
            {
                try
                {
                    using (var db = new ProjectDatabase())
                    {
                        var tabelAr = new TablesArrangement() { Tables = Tables.ToList() };
                        foreach (var table in tabelAr.Tables) 
                        {
                            db.Tables.Add(table);
                        }
                        tabelAr = db.TablesArrangements.Add(tabelAr);
                        Offer.TablesArrangement = tabelAr;
                        Offer.AssociateId = associate.Id;
                        Offer = db.Offers.Add(Offer);

                        db.SaveChanges();
                    }
                    associate.Offers.Add(Offer);
                    UpdateViewCommand.Execute(new EditAssociatesViewModel(UpdateViewCommand, associate));
                }
                catch 
                {
                    Console.WriteLine("sve radi");
                }
                   
            }
        }

        public void AddTable() 
        {
            if (NewNumberOfSeats <= 0)
            {
                MessageBox.Show("Morate uneti broj koji je veci od 0!");
                return;
            }
            var table = new Table()
            {
                TableCoordinates = new Point(0, 0),
                NumberOfSeats = NewNumberOfSeats,
                TakenNumberOfSeats = 0,
            };
            Tables.Add(table);
            NewNumberOfSeats = 0;
        }

        private void Cancel() 
        {
            var pastViewModel = ViewChangeUtils.PastViews.Pop();
            UpdateViewCommand.Execute(pastViewModel);
        }
    }
}
