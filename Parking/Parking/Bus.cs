using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    internal class Bus:Vehicle
    {

        public int NumberOfPassengers { get; set; } 

        public Bus()
        {
            Random rnd = new Random();
            NumberOfPassengers = rnd.Next(12,81);
            SizeInParkingPlace = 2;
        }

        public override void Details()
        {
            Console.WriteLine("Plats " + VehiclePosition[0] + "-" + VehiclePosition [1] + " Buss " + RegistrationNumber + " " + VehicleColor + " " + NumberOfPassengers);
        }
    }
}
