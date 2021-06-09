using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Models
{
    public class Table : AbstractModel
    {
        [Key]
        public int Id { get; set; }
        public int NumberOfSeats { get; set; }
        public int takenNumberOfSeats;
        public int TakenNumberOfSeats 
        {
            get { return takenNumberOfSeats; } 
            set 
            {
                takenNumberOfSeats = value;
                OnPropertyChanged("TakenNumberOfSeats");
            }
        }

        private bool hasCollision;
        public bool HasCollision 
        {
            get { return hasCollision; }
            set 
            {
                hasCollision = value;
                OnPropertyChanged("HasCollision");
            } 
        }

        private Point tableCoordinates;
        public Point TableCoordinates {
            get
            {
                return tableCoordinates;
            }
            set
            {
                tableCoordinates = value;
                OnPropertyChanged("TableCoordinates");
            }
        }
        private List<Guest> guests;
        public virtual List<Guest> Guests 
        {
            get 
            {
                return guests;
            }
            set 
            {
                guests = value;
                OnPropertyChanged("Guests");
            }
        }

        private bool isFull;
        public virtual bool IsFull
        {
            get
            {
                return isFull;
            }
            set
            {
                isFull = value;
                OnPropertyChanged("IsFull");
            }
        }

        public Table()
        {
            Guests = new List<Guest>();
        }

        public Table(int numberOfSeats, Point tableCoordinates)
        {
            NumberOfSeats = numberOfSeats;
            TableCoordinates = tableCoordinates;
        }
    }
}
