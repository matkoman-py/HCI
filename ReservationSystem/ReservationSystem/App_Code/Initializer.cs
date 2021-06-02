using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.App_Code
{
    public class Initializer
    {
        public static void AppInitialize()
        {
            Console.WriteLine("Pocetak");
            using (var db = new ProjectDatabase())
            {

            }

        }
    }
}
