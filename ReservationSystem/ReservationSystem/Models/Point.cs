using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Models
{
    [DataContract]
    public class Point : AbstractModel
    {
        [Key]
        public int Id { get; set; }
        private double x;
        public double X 
        {
            get { return x; }
            set 
            {
                x = value;
                OnPropertyChanged("X");
            }
        }
        private double y;
        public double Y 
        {
            get { return y; }
            set
            {
                y = value;
                OnPropertyChanged("Y");
            }
        }

        public Point()
        {

        }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
