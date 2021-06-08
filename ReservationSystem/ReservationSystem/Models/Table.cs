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
        public int TakenNumberOfSeats { get; set; }

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

        public Table()
        {

        }

        public Table(int numberOfSeats, Point tableCoordinates)
        {
            NumberOfSeats = numberOfSeats;
            TableCoordinates = tableCoordinates;
        }
    }
}
