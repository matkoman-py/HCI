using ReservationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Models
{
    public class DataContainerDto
    {
        public string Path { get; set; }
        public BaseViewModel Bvm { get; set; }

        public DataContainerDto(string path, BaseViewModel bvm)
        {
            Path = path;
            Bvm = bvm;
        }
    }
}
