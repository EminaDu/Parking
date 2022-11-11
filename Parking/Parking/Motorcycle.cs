using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    internal class Motorcycle:Vehicle
    {
        public string Brand { get; set; }


        public Motorcycle()
        {
            Brand = GenerateBrand();
            SizeInParkingPlace = 0.5; 

        }

        private string GenerateBrand()
        {
            Random rnd=new Random();
            string[] brands = new string[] { "Yamaha", "Suzuki", "BMW", "Harley", "Ducati" };

            return brands[rnd.Next(0, brands.Length)];
        }

        public override void Details()
        {
            
        }

    }
}
