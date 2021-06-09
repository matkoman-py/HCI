using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Utils
{
    public class CsvToGuestsConverter
    {
        public static List<Guest> CsvToGuests(string path) 
        {
            List<Guest> guests = new List<Guest>();
            using (StreamReader reader = File.OpenText(path)) 
            {
                var line = "";
                while ((line = reader.ReadLine()) != null) 
                {
                    var parts = line.Trim().Split(',');
                    guests.Add(new Guest(parts[0], parts[1]));
                }
            }
            return guests;
        }
    }
}
