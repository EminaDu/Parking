using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    internal class Parking
    {

        public List<Double> ParkingPlaces { get; set; }

        public double PricePerMin { get; set; }

        public List<Vehicle> Vehicles{ get; set; }

        public Parking()
        {
            ParkingPlaces = new List<double>();
            for(int i = 0; i < ParkingPlaces.Count; i++)
            {
                ParkingPlaces.Add(i);
            }
            PricePerMin = 1.5;
            Vehicles = new List<Vehicle> ();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      
        }
    }
}
